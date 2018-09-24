using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenNLP.Tools.Util;
using TextParser;

namespace Corpus
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DictionaryGridView.Rows.Clear();
            foreach (var group in SuperDictionary.canonical_groups)
            {
                var cb = new DataGridViewComboBoxCell();
                var dr = new DataGridViewRow();
                string word = group.Key;
                int frequence = group.Value.frequence;
                Set<String> forms = new Set<String>();
                foreach (var node in group.Value.@group)
                {
                    forms.Add(node.word+" "+node.tag+" ("+node.frequence+")");
                }
                foreach (var node in forms)
                {
                    cb.Items.Add(node);
                    cb.Value = node;
                }
                var cell = new DataGridViewTextBoxCell();
                cell.Value = word;
                var cell2 = new DataGridViewTextBoxCell();
                cell2.Value = frequence;
                dr.Cells.Add(cell);
                dr.Cells.Add(cb);
                dr.Cells.Add(cell2);
                DictionaryGridView.Rows.Add(dr);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SuperDictionary.DeleteWord(DelWord.Text, DelGroup.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SuperDictionary.AddingToGroup(AddWord.Text, AddTag.Text, AddGroup.Text, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SuperDictionary.CreatingGroupByWord(AGWord.Text, AGTag.Text, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SuperDictionary.DeleteGroup(DGGroup.Text);
        }
    }
}
