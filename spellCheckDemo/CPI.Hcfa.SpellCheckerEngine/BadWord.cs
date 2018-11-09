using System;
using System.Collections.Generic;
using System.Text;

namespace CPI.Hcfa.SpellChecker
{
    public class BadWord
    {
        private string word = string.Empty;

        public string Word
        {
            get { return word; }
            set { word = value; }
        }

        private int index = 0;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public int Length
        {
            get { return word.Length; }
        }

        public BadWord(string word, int index)
        {
            this.word = word;
            this.index = index;
        }

        public bool Equals(BadWord obj)
        {
            if (obj != null && this.word.Equals(obj.word) && this.index == obj.index)
            {
                return true;
            }
            return false;
        }

    }
}
