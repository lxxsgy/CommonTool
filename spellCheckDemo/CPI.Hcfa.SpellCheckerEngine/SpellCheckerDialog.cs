using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NHunspell;

namespace CPI.Hcfa.SpellChecker
{
    public partial class SpellCheckerDialog : Form
    {
        public string result = null;
        private string input = null;
        private SpellCheckerEngine spellEngine = null;

        private Font heightLightFont = null;
        private Color heightLightColor = Color.Red;

        private IList<BadWord> currentBadWords = new List<BadWord>();
        private BadWord currentBadWord = null;

        private IList<string> ignoreWords = new List<string>();

        private IList<BadWord> ignoreBadWords = new List<BadWord>();

        private bool allowRichTextBoxChange = true;

        public SpellCheckerDialog(SpellCheckerEngine spellEngine, string input)
        {
            InitializeComponent();

            ControlBindEscEvent(this);

            allowRichTextBoxChange = false;
            this.spellEngine = spellEngine;
            this.input = input;
            this.richTextBox1.Text = input;
            heightLightFont = new Font(this.richTextBox1.Font, FontStyle.Underline | FontStyle.Bold);
            ReFreshDisplay();
            allowRichTextBoxChange = true;
        }

        private void ControlBindEscEvent(Control ctl)
        {
            ctl.KeyPress += new KeyPressEventHandler(CommKeyPress);
            if (ctl.HasChildren)
            {
                foreach (Control var in ctl.Controls)
                {
                    ControlBindEscEvent(var);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.listBox1.ClearSelected();
            this.Close();
        }

        private void ReFreshDisplay()
        {
            string text = this.richTextBox1.Text;
            currentBadWords = spellEngine.SpellCheck(text);
            this.richTextBox1.Clear();
            this.listBox1.Items.Clear();
            this.richTextBox1.Text = text;

            this.btnIgnore.Enabled = false;
            this.btnIgnoreAll.Enabled = false;
            this.btnChange.Enabled = false;
            this.btnChangeAll.Enabled = false;

            foreach (BadWord word in currentBadWords)
            {
                bool isIgnore = false;
                foreach (BadWord tempBadWord in ignoreBadWords)
                {
                    if (tempBadWord.Equals(word))
                    {
                        isIgnore = true;
                        break;
                    }
                }
                if (!isIgnore && ignoreWords.Contains(word.Word))
                {
                    isIgnore = true;
                }

                if (!isIgnore)
                {
                    this.richTextBox1.Select(word.Index, word.Length);
                    this.richTextBox1.SelectionColor = heightLightColor;
                    this.btnIgnore.Enabled = true;
                    this.btnIgnoreAll.Enabled = true;
                    this.richTextBox1.SelectionFont = heightLightFont;
                    currentBadWord = word;
                    this.richTextBox1.Select(currentBadWord.Index, 0);
                    this.richTextBox1.ScrollToCaret();
                    LoadSuggest(word.Word);
                    break;
                }
            }
        }

        private void LoadSuggest(string word)
        {
            this.listBox1.Items.Clear();
            this.btnChange.Enabled = false;
            this.btnChangeAll.Enabled = false;
            IList<string> suggestWords = spellEngine.Suggest(word);
            if (suggestWords.Count > 0)
            {
                this.btnChange.Enabled = true;
                this.btnChangeAll.Enabled = true;
                foreach (string suggestWord in suggestWords)
                {
                    this.listBox1.Items.Add(suggestWord);
                }
                this.listBox1.SelectedIndex = 0;
            }
            else
            {
                this.listBox1.Items.Add("No suggestion!");
                this.listBox1.SelectedIndex = 0;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.result = this.richTextBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            allowRichTextBoxChange = false;
            if (currentBadWord != null)
            {
                this.ignoreBadWords.Add(currentBadWord);
            }
            ReFreshDisplay();
            allowRichTextBoxChange = true;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                allowRichTextBoxChange = false;
                string tempValue = richTextBox1.Text.Substring(0, currentBadWord.Index);
                tempValue += listBox1.SelectedItem.ToString() + richTextBox1.Text.Substring(currentBadWord.Index + currentBadWord.Length);
                this.richTextBox1.Clear();
                this.richTextBox1.Text = tempValue;
                allowRichTextBoxChange = true;
                ReFreshDisplay();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (btnChange.Enabled)
            {
                btnChange.PerformClick();
            }
        }

        // private bool richTextChanageFlag = false;

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (allowRichTextBoxChange)
            {
                int startIndex = this.richTextBox1.SelectionStart;
                ReFreshDisplay();
                this.richTextBox1.SelectionStart = startIndex;
            }
        }

        private void btnChangeAll_Click(object sender, EventArgs e)
        {
            string tempValue = this.richTextBox1.Text;
            for (int i = currentBadWords.Count - 1; i > -1; i--)
            {
                BadWord word = currentBadWords[i];
                if (word.Index >= currentBadWord.Index)
                {
                    string temp = richTextBox1.Text.Substring(0, word.Index);
                    temp += listBox1.SelectedItem.ToString() + tempValue.Substring(word.Index + word.Length);
                    tempValue = temp;
                }
            }
            this.allowRichTextBoxChange = false;
            this.richTextBox1.Clear();
            this.richTextBox1.Text = tempValue;
            this.allowRichTextBoxChange = true;
        }

        private void btnIgnoreAll_Click(object sender, EventArgs e)
        {
            if (!this.ignoreWords.Contains(currentBadWord.Word))
                this.ignoreWords.Add(this.currentBadWord.Word);
            allowRichTextBoxChange = false;
            ReFreshDisplay();
            allowRichTextBoxChange = true;
        }

        private void CommKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                e.Handled = true;
                this.btnCancel.PerformClick();
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 10)
            {
                e.Handled = true;
                if(this.btnIgnore.Enabled)
                    this.btnIgnore.PerformClick();
            }
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            Console.WriteLine(m.ToString());
            if (m.Msg == 0x100 && m.WParam.ToInt32() == 0xd)
            {
                return true;
            }
            return base.ProcessKeyPreview(ref m);
        }
    }
}