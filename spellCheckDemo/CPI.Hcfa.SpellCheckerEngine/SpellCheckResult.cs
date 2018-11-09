using System;
using System.Collections.Generic;
using System.Text;

namespace CPI.Hcfa.SpellChecker
{
    public class SpellCheckResult
    {
        private string sourceWords = string.Empty;

        /// <summary>
        /// Ҫ�����ı�
        /// </summary>
        public string SourceWords
        {
            get { return sourceWords; }
        }

        private string resultWords = string.Empty;
        /// <summary>
        /// ������ı�
        /// </summary>
        public string ResultWords
        {
            get { return resultWords; }
        }

        /// <summary>
        /// ���󵥴���
        /// </summary>
        public int BadWordCount
        {
            get { return badWords.Count; }
        }

        private bool correct = false;

        /// <summary>
        /// �Ƿ����
        /// </summary>
        public bool Correct
        {
            get { return correct; }
        }

        private IList<BadWord> badWords = null;

        /// <summary>
        /// �Զ��幹����
        /// </summary>
        /// <param name="sourceWords"></param>
        /// <param name="resultWords"></param>
        /// <param name="badWordCount"></param>
        public SpellCheckResult(string sourceWords, string resultWords, IList<BadWord> badWords, bool correct)
        {
            this.sourceWords = sourceWords;
            this.resultWords = resultWords;
            this.badWords = badWords;
            if (badWords != null)
            {
                this.badWords = new List<BadWord>();
            }
            else
            {
                this.badWords = badWords;
            }
            this.correct = correct;
        }
    }
}
