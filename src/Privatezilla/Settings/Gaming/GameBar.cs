﻿using Microsoft.Win32;

namespace Privatezilla.Setting.Gaming
{
    internal class DisableGameBar : SettingBase
    {
        private const string GameBarKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\GameDVR";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Disable Game Bar features";
        }

        public override string Info()
        {
            return "This setting will disable the Windows Game Recording and Broadcasting.";
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(GameBarKey, "AllowGameDVR", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(GameBarKey, "AllowGameDVR", DesiredValue, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

        public override bool UndoSetting()
        {
            try
            {
                Registry.SetValue(GameBarKey, "AllowGameDVR", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}