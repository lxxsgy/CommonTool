using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace CPI.Hcfa.SpellChecker
{
    public class DictionaryConfigElementCollection : ConfigurationElementCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new DictionaryConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DictionaryConfigElement)element).LanguageCode;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }
    }
}
