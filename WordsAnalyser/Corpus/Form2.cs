using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TextParser;

namespace Corpus
{
    public partial class Form2 : Form
    {
        private static string basicserialisationpath = "ser.txt";
        private static string basicresultpath = "res.txt";
        //private Program.My_Dictionary nextDictionary;
        public Form2()
        {
            InitializeComponent();
            this.Text="Меню для работы с новыми текстами";
            System.IO.StreamReader a;
            My_Dictionary.nextDictionary = new Dictionary<string, int>();
            //nextDictionary = new Program.My_Dictionary(); 
            //OutputResultToTextFile()
            //Program.OutputResultToTextBoxByFrequence(dataGridView2);
            //textBox1.Text=("Total number of words: " + Program.My_Dictionary.dictionaryBasic.Sum(word => word.Value));
        }

        public void button1_Click(object sender, EventArgs e)
        {
            //Program.OutputResultToTextBoxByFrequence(dataGridView2);
        }

        //public void button2_Click(object sender, EventArgs e)
        //{
        //    Program.OutputResultToTextBoxByAlphabet(dataGridView2);
        //}
        private delegate DialogResult ShowSaveFileDialogInvoker();
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    SynchronizationContext.Current.Send(_ =>
        //    {
        //        //if (saveFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        //{
        //        //Form.ActiveForm.Invoke()
        //        SaveFileDialog saveFileDialog2 = new SaveFileDialog();
        //        //this.Invoke(() => this.saveFileDialog2);
        //        ShowSaveFileDialogInvoker invoker = new ShowSaveFileDialogInvoker(saveFileDialog2.ShowDialog);
        //        this.Invoke(invoker);
        //        textBox3.Text = saveFileDialog2.FileName;
        //        button6.Enabled = true;
        //        //}
        //    }, null);
           
        //}

        private void button6_Click(object sender, EventArgs e)
        {
            //Program.OutputResultToFileFromTextBox(richTextBox1, textBox3.Text);
            //button6.Enabled = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Program.CodeAnalys(richTextBox2,dataGridView1);
            ////Program.CodeAnalys(richTextBox1.Text, richTextBox2);
            var form3 = new Form3();
            form3.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string openedFileName = openFileDialog1.FileName;
                StreamReader sr = new
                    System.IO.StreamReader(openedFileName);
                DictionaryHelper.ParseFile(sr, My_Dictionary.nextDictionary);
                //Program.OutputResultToTextBoxByFrequence(My_Dictionary.nextDictionary, dataGridView2);
               // DictionaryHelper.CodeAnalys(richTextBox2, dataGridView1, openedFileName);
                //textBox1.Text = openedFileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int changeword = 0;
            foreach (var word in My_Dictionary.nextDictionary)
            {
                if (My_Dictionary.dictionaryBasic.ContainsKey(word.Key))
                {
                    My_Dictionary.dictionaryBasic.TryGetValue(word.Key, out changeword);
                    My_Dictionary.dictionaryBasic.Remove(word.Key);
                    My_Dictionary.dictionaryBasic.Add(word.Key,changeword+word.Value);
                }
                else
                    My_Dictionary.dictionaryBasic.Add(word.Key,word.Value);
            }
            My_Dictionary.nextDictionary.Clear();
        }
    }
}
