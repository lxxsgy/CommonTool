using System;
using System.Collections.Generic;
using System.Text;

namespace CPI.Hcfa.SpellChecker
{
    public class SpellCheckResult
    {
        private string sourceWords = string.Empty;

        /// <summary>
        /// 要检查的文本
        /// </summary>
        public string SourceWords
        {
            get { return sourceWords; }
        }

        private string resultWords = string.Empty;
        /// <summary>
        /// 检查后的文本
        /// </summary>
        public string ResultWords
        {
            get { return resultWords; }
        }

        /// <summary>
        /// 错误单词数
        /// </summary>
        public int BadWordCount
        {
            get { return badWords.Count; }
        }

        private bool correct = false;

        /// <summary>
        /// 是否更正
        /// </summary>
        public bool Correct
        {
            get { return correct; }
        }

        private IList<BadWord> badWords = null;

        /// <summary>
        /// 自定义构造器
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
