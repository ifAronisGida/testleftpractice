using System;
using System.Globalization;

namespace UiObjects.TestSettings
{
    /// <summary>
    /// This class contains strings dependant of the current system language.
    /// </summary>
    public static class TcSystemLanguageSpecific
    {
        private const string ENGLISH = "eng";
        private const string GERMAN = "deu";
        private const string HUNGARIAN = "hun";

        /// <summary>
        /// Enumeration of the supported languages.
        /// </summary>
        public enum Languages { German, English, Hungarian }

        /// <summary>
        /// Gets the current system language.
        /// </summary>
        /// <value>
        /// The system language.
        /// </value>
        /// <exception cref="Exception">SystemLanguageSpecific.SystemLanguage: Language " + CultureInfo.CurrentUICulture.DisplayName + " is not used for the Autotests</exception>
        public static Languages SystemLanguage
        {
            get
            {
                switch( CultureInfo.CurrentUICulture.ThreeLetterISOLanguageName )
                {
                    case ENGLISH:
                        return Languages.English;
                    case GERMAN:
                        return Languages.German;
                    case HUNGARIAN:
                        return Languages.Hungarian;
                    default:
                        throw new Exception( "SystemLanguageSpecific.SystemLanguage: Language " + CultureInfo.CurrentUICulture.DisplayName + " is not used for the Autotests" );
                }
            }
        }

        /// <summary>
        /// Gets the title of open file dialogs.
        /// </summary>
        /// <value>
        /// The title in the different languages.
        /// </value>
        /// <exception cref="Exception">SystemLanguageSpecific.SystemLanguage: Language " + CultureInfo.CurrentUICulture.DisplayName + " is not used for the Autotests</exception>
        public static string Open
        {
            get
            {
                switch( SystemLanguage )
                {
                    case Languages.German:
                        return "Ö&ffnen";
                    case Languages.English:
                        return "&Open";
                    case Languages.Hungarian:
                        return "&Megnyitás";
                    default:
                        throw new Exception( "SystemLanguageSpecific.SystemLanguage: Language " + CultureInfo.CurrentUICulture.DisplayName + " is not used for the Autotests" );
                }
            }
        }

        /// <summary>
        /// Gets the caption of the cancel button depending on the current system language.
        /// </summary>
        /// <value>
        /// The cancel.
        /// </value>
        /// <exception cref="Exception">SystemLanguageSpecific.SystemLanguage: Language " + CultureInfo.CurrentUICulture.DisplayName + " is not used for the Autotests</exception>
        public static string Cancel
        {
            get
            {
                switch( SystemLanguage )
                {
                    case Languages.German:
                        return "Abbrechen";
                    case Languages.English:
                        return "Cancel";
                    case Languages.Hungarian:
                        return "Mégse";
                    default:
                        throw new Exception( "SystemLanguageSpecific.SystemLanguage: Language " + CultureInfo.CurrentUICulture.DisplayName + " is not used for the Autotests" );
                }
            }
        }
    }
}
