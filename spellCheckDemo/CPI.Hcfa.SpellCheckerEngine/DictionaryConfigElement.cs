using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace CPI.Hcfa.SpellChecker
{
    public class DictionaryConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("languageCode")]
        public string LanguageCode
        {
            get
            {
                return this["languageCode"] as string;
            }
        }

        [ConfigurationProperty("affFile")]
        public string AffFile
        {
            get
            {
                return this["affFile"] as string;
            }
        }

        [ConfigurationProperty("dicFile")]
        public string DicFile
        {
            get
            {
                return this["dicFile"] as string;
            }
        }
    }
}
