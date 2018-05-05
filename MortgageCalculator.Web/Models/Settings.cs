using System;
using System.Web.Configuration;

namespace MortgageCalculator.Web.Models
{
    public static class Settings
    {
        private const string APP_SETTING_ERROR_MESSAGE = "Invalid or missing appSetting, ";

        public static string GetStringFromAppSetting(string appSettingName)
        {
            string setting = WebConfigurationManager.AppSettings[appSettingName] as string;
            if (String.IsNullOrEmpty(setting))
            {
                throw new Exception(APP_SETTING_ERROR_MESSAGE + appSettingName);
            }
            return setting;
        }

        public static string BaseUrl
        {
            get { return GetStringFromAppSetting("BaseUrl"); }

        }
    }
}