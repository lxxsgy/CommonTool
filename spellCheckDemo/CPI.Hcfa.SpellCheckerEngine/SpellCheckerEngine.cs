using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using NHunspell;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace CPI.Hcfa.SpellChecker
{
    public class  SpellCheckerEngine : IDisposable
    {
        private SpellEngine spellEngine;

        private DictionaryLanguageType language = DictionaryLanguageType.EN_US;

        private const string DictionaryConfigName = "{0}_DictionaryConfig";

        private bool showSpellCheckkerDialog = true;

        /// <summary>
        /// 是否显示拼写检查窗口
        /// </summary>
        public bool ShowSpellCheckkerDialog
        {
            get { return showSpellCheckkerDialog; }
            set { showSpellCheckkerDialog = value; }
        }

        private Point? location = null;

        /// <summary>
        /// 获取或者设定拼写检查窗口的位置(屏幕坐标)
        /// </summary>
        public Point? Location
        {
            get { return location; }
            set 
            { 
                location = value; 
            }
        }

        private bool topMost = true;

        /// <summary>
        /// 窗口是否总在最前面
        /// </summary>
        public bool TopMost
        {
            get { return topMost; }
            set { topMost = value; }
        }
        
        static SpellCheckerEngine()
        {
            Hunspell.NativeDllPath = AppDomain.CurrentDomain.BaseDirectory + "\\";
        }

        public SpellCheckerEngine(DictionaryLanguageType language)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", ""));

            if (configuration == null)
            {
                throw new Exception("The dictionary configuration setting is missing.");
            }

            string configName = string.Format(DictionaryConfigName, language.ToString().ToLower());

            DictionaryConfigSectionHandler dictionaryConfig = configuration.GetSection(configName) as DictionaryConfigSectionHandler;

            if (dictionaryConfig == null || dictionaryConfig.DictionaryConfigSettings.Count == 0)
            {
                throw new Exception("The dictionary configuration setting is missing.");
            }

            spellEngine = new SpellEngine();

            foreach (DictionaryConfigElement dicConfig in dictionaryConfig.DictionaryConfigSettings)
            {
                LanguageConfig enConfig = new LanguageConfig();
                enConfig.LanguageCode = dicConfig.LanguageCode;
                enConfig.HunspellAffFile = Hunspell.NativeDllPath + dicConfig.AffFile;
                enConfig.HunspellDictFile = Hunspell.NativeDllPath + dicConfig.DicFile;
                spellEngine.AddLanguage(enConfig);
            }

            this.language = language;
        }

        ~SpellCheckerEngine()
        {
            this.Dispose();
            spellEngine = null;
        }

        internal IList<BadWord> SpellCheck(string input)
        {
            IList<BadWord> badWords = new List<BadWord>();
            if (!string.IsNullOrEmpty(input))
            {
                MatchCollection matchs = Regex.Matches(input, "[A-Za-z']+", RegexOptions.IgnoreCase);
                foreach (Match match in matchs)
                {
                    if(!spellEngine[language.ToString()].Spell(match.Value))
                    {
                        BadWord word = new BadWord(match.Value,match.Index);
                        badWords.Add(word);
                    }
                }
            }
            return badWords;
        }

        internal IList<string> Suggest(string word)
        {
            return spellEngine[language.ToString()].Suggest(word);
        }

        public SpellCheckResult Spell(string input)
        {
            SpellFactory spellFactory = spellEngine[language.ToString()];
            if (spellFactory == null)
            {
                return new SpellCheckResult(input, null, null,false);
            }

            IList<BadWord> badWords = SpellCheck(input);

            if (showSpellCheckkerDialog && badWords.Count > 0)
            {
                SpellCheckerDialog dialog = new SpellCheckerDialog(this, input);
                dialog.TopMost = this.topMost;
                if (location.HasValue)
                {
                    dialog.StartPosition = FormStartPosition.Manual;
                    dialog.Location = this.Location.Value;
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return new SpellCheckResult(input, dialog.result, badWords, true);
                }
            }  
            return new SpellCheckResult(input, null, badWords, false);
        }

        #region IDisposable Members

        public void Dispose()
        {
            IDisposable dispose = spellEngine as IDisposable;
            if (dispose != null)
            {
                dispose.Dispose();
            }
        }

        #endregion
    }
}
