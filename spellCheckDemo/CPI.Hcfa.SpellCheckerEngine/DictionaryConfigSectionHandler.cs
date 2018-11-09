using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace CPI.Hcfa.SpellChecker
{
    public class DictionaryConfigSectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("dictionaryConfigSettings",IsDefaultCollection=true)]
        public DictionaryConfigElementCollection DictionaryConfigSettings
        {
            get
            {
                return this["dictionaryConfigSettings"] != null ? this["dictionaryConfigSettings"] as DictionaryConfigElementCollection : new DictionaryConfigElementCollection();
            }
        }
    }
}
