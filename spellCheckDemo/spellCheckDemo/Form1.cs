using CPI.Hcfa.SpellChecker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPI.Hcfa.SpellChecker;

namespace spellCheckDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          

        }

        public class SpellChecker
        {
            static Dictionary<DictionaryLanguageType, SpellCheckerEngine> spellEngines = new Dictionary<DictionaryLanguageType, SpellCheckerEngine>();
            public static void Check(string DictionaryLanguage, Control entryControl)
            {
                if (!string.IsNullOrEmpty(DictionaryLanguage))
                {
                    DictionaryLanguageType dicLanguage = (DictionaryLanguageType)Enum.Parse(typeof(DictionaryLanguageType), DictionaryLanguage);
                    if (!spellEngines.ContainsKey(dicLanguage))
                    {
                        spellEngines.Add(dicLanguage, new SpellCheckerEngine(dicLanguage));
                    }
                    SpellCheckerEngine engine = spellEngines[dicLanguage];
                    SpellCheckResult result = engine.Spell(entryControl.Text);
                    if (result.Correct)
                    {
                        entryControl.Text = result.ResultWords;
                    }
                }
            }

            //public static void Check(GridViewWithKeyDown grid)
            //{
            //    if (grid.CurrentCell == null) return;
            //    string language = grid.Fields[grid.CurrentCell.ColumnIndex].DictionaryLanguage;
            //    string input = "";
            //    if (grid.EditingControl != null)
            //    {
            //        input = grid.EditingControl.Text;
            //    }
            //    else
            //    {
            //        input = grid.CurrentCell.Value != null ? grid.CurrentCell.Value.ToString() : "";
            //    }
            //    if (!string.IsNullOrEmpty(language))
            //    {
            //        DictionaryLanguageType dicLanguage = (DictionaryLanguageType)Enum.Parse(typeof(DictionaryLanguageType), language);
            //        if (!spellEngines.ContainsKey(dicLanguage))
            //        {
            //            spellEngines.Add(dicLanguage, new SpellCheckerEngine(dicLanguage));
            //        }
            //        SpellCheckerEngine engine = spellEngines[dicLanguage];
            //        SpellCheckResult result = engine.Spell(input);
            //        if (result.Correct)
            //        {
            //            grid[grid.CurrentCell.ColumnIndex, grid.CurrentCell.RowIndex].Selected = true;
            //            grid.EditingControl.Text = result.ResultWords;
            //        }
            //    }
           // }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            SpellChecker.Check("EN_US", textBox1);
        }
    }
}
