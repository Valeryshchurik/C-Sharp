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
using TextHandler;
using TextParser;

namespace Corpus
{

    public partial class Form1 : Form
    {
        public System.IO.StreamReader sr;
        public string openedFileName, serialisationname, outputPath,  resultpath;
        private static string basicserialisationpath = "ser.txt";
        private static string basicresultpath = "res.txt";
        Dictionary<string, int> dictionary;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Меню словаря";
            dictionary = new Dictionary<string, int>();
        }
 

        private void button2_Click(object sender, EventArgs e)
        {
            if (sr != null)
            {
                //DictionaryHelper.ParseFile(sr, My_Dictionary.dictionaryBasic);
                //Program.SerializeResult(basicserialisationpath, Program.My_Dictionary.dictionaryBasic);
                //Program.OutputResultToTextFile(basicserialisationpath, basicresultpath);
                Program.OutputResultToTextBoxByFrequence(DictionaryGridView);
                MessageBox.Show("Обработка прошла успешно");
                //Program.RunForm2();
            }
            else
            {
                DictionaryHelper.SerializeResult(basicserialisationpath, My_Dictionary.dictionaryBasic);
                DictionaryHelper.OutputResultToTextFile(basicserialisationpath, basicresultpath);
                Program.OutputResultToTextBoxByFrequence(DictionaryGridView);
                MessageBox.Show("Обработка прошла успешно");
                //Program.RunForm2();
            }
            textBox5.Text = ("Общее число слов: " + SuperDictionary.canonical_groups.Values.Sum(word => word.frequence));
        }

        private void ShowDictionaryClick(object sender, EventArgs e)
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
                    forms.Add(node.word + " " + node.tag + " (" + node.frequence + ")");
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
            textBox5.Text = ("Общее число слов: " + SuperDictionary.canonical_groups.Values.Sum(word => word.frequence));
        }

        private void DeleteWordClick(object sender, EventArgs e)
        {
            SuperDictionary.DeleteWord(DelWord.Text, DelGroup.Text);
        }

        private void AddingTogroupClick(object sender, EventArgs e)
        {
            SuperDictionary.AddingToGroup(AddWord.Text, AddTag.Text, AddGroup.Text, 1);
        }

        private void CreatingGroupByWordClick(object sender, EventArgs e)
        {
            SuperDictionary.CreatingGroupByWord(AGWord.Text, AGTag.Text, 1);
        }

        private void DeleteGroupClick(object sender, EventArgs e)
        {
            SuperDictionary.DeleteGroup(DGGroup.Text);
        }
    

        private void button1_Click_1(object sender, EventArgs e)
        {
            var wnd = new MainWindow();
            wnd.Show();
           // Program.RunForm2();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var form4 = new Form4();
            form4.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var form3 = new Form3();
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                outputPath = saveFileDialog1.FileName;
                textBox2.Text = outputPath;
                DictionaryHelper.SerializeResult(outputPath, dictionary);
            }
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                resultpath = saveFileDialog2.FileName;
                textBox3.Text = resultpath;
                //Program.OutputResultToFileFromTextBox(textBox3.Text);
            }
        }


        private void InputVocabularyButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                serialisationname = openFileDialog2.FileName;
                sr = new
                   System.IO.StreamReader(serialisationname);
                textBox4.Text = serialisationname;
            }
           SuperDictionary.canonical_groups = DictionaryHelper.DeserialiseDictionaryFrom(textBox4.Text);
        }
    }
}
