using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Services
{
    public static class Settings
    {
        // Password Settings
        public const int PasswordMinLength = 8;
        public static bool PasswordIsUniqueCharsRequired = false;
        public static bool PasswordIsNumberRequired = false;
        public static bool PasswordIsUppercaseRequired = false;
        public static int PasswordMinRequiredUppercaseLetters = 1;
        public static bool PasswordIsLowercaseRequired = false;
        public static int PasswordMinRequiredLowercaseLetters = 1;

    }
}
