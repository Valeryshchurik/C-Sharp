using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using LemmaSharp.Classes;
using OpenNLP.Tools.Tokenize;
using OpenNLP.Tools.PosTagger;
using OpenNLP.Tools.Util;
using TextHandler;
using TextParser;

namespace Corpus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            My_Dictionary.nextDictionaryCodeBasic = new Dictionary<string, Code[]>();  
            Application.Run(new Form1());
        }
        public static void RunForm2()
        {
            var form2 = new Form2();
            form2.Show();
        }
        public static void OutputResultToTextBoxByFrequence(DataGridView dv)
        {
            dv.Rows.Clear();
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
                dv.Rows.Add(dr);
            }
        }
    }
}
