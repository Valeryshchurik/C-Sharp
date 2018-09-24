using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LemmaSharp.Classes;
using OpenNLP.Tools.PosTagger;
using OpenNLP.Tools.Tokenize;

namespace TextParser
{
    public class DictionaryHelper
    {
        public static void ParseFile(StreamReader sr, Dictionary<string, int> dictionary)
        {
            string line;
            var path = @"e:\C#LIBs\LemmaGenerator-master\Test\Data\full7z-multext-en.lem";
            var stream = File.OpenRead(path);
            var lemmatizer = new Lemmatizer(stream);
            while ((line = sr.ReadLine()) != null)
            {
                string[] words = Regex.Split(line, "[^A-Za-z]+").
                    Where(s => !String.IsNullOrEmpty(s)).
                    Select(s => s.ToLower()).ToArray();
                foreach (var word in words)
                {
                    if (!dictionary.ContainsKey(word))
                        dictionary.Add(word, 1);
                    else
                        dictionary[word]++;
                    string basicword = lemmatizer.Lemmatize(word);
                    /*SuperDictionary.Canonicalgroup gr=SuperDictionary.FindWord(word, basicword));
                    if (gr != null)
                    {
                        
                    }*/
                }
            }
            //My_Dictionary.dictionaryBasic = dictionary;
        }
        public static List<Node> CodeAnalys(string path)
        {
            var pathlem = @"e:\C#LIBs\LemmaGenerator-master\Test\Data\full7z-multext-en.lem";
            var stream = File.OpenRead(pathlem);
            var lemmatizer = new Lemmatizer(stream);
            var modelPath = @"e:\MyWORK\Models\EnglishPOS.nbin";
            var tagDictDir = @"e:\MyWORK\Models\Parser\tagdict";
            var tokenizer = new EnglishMaximumEntropyTokenizer(modelPath);
            var posTagger = new EnglishMaximumEntropyPosTagger(modelPath, tagDictDir);
            var wordRegex = new Regex("^[A-Za-z]+$");
            List<Node> result = new List<Node>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadToEnd();
                string[] words = tokenizer.Tokenize(line)
                    .Where(s => !String.IsNullOrEmpty(s))
                    .Select(s => s.ToLower()).ToArray();
                for (var i = 0; i < words.Length; i++)
                {
                    var pos = posTagger.Tag(new string[] { words[i] });
                    if (wordRegex.IsMatch(words[i]))
                    {
                        /*var cb = new DataGridViewComboBoxCell();
                        var dr = new DataGridViewRow();
                        cb.Items.Add(pos[0]);
                        foreach (var code in My_Dictionary.Codes)
                            if (!code.Equals(pos[0]))
                                cb.Items.Add(code);
                        cb.Value = pos[0];
                        var cell = new DataGridViewTextBoxCell();
                        cell.Value = words[i];
                        dr.Cells.Add(cell);
                        dr.Cells.Add(cb);
                        dv.Rows.Add(dr);*/
                        Node new_n = new Node(words[i], pos[0]);
                        new_n.mainWord = lemmatizer.Lemmatize(words[i]);
                        result.Add(new_n);
                        //SuperDictionary.AddingToGroup(words[i], pos[0], basicword);
                    }
                    else
                    {
                        string new_word = words[i].Substring(0, words[i].Length-1);
                        if (wordRegex.IsMatch(new_word))
                        {
                            Node new_n = new Node(new_word, pos[0]);
                            new_n.mainWord = lemmatizer.Lemmatize(new_word);
                            result.Add(new_n);
                        }
                        Node newSign = new Node(words[i].Substring(words[i].Length - 1, 1), null);
                        result.Add(newSign);
                    }
                }
            }
            return result;
        }

        public static Dictionary<string, SuperNode> ConvertNodesToSuperNodes(List<Node> nodes)
        {
            Dictionary<string, SuperNode> result = new Dictionary<string, SuperNode>();
            foreach (var word in nodes)
            {
                if (word.tag == null)
                    continue;
                if (!result.ContainsKey(word.mainWord))
                {
                    SuperNode sn=new SuperNode();
                    sn.frequence = 1;
                    sn.mainword = word.mainWord;
                    sn.allForms.Add(word);
                    result.Add(sn.mainword, sn);
                }
                else
                {
                    SuperNode sn;
                    result.TryGetValue(word.mainWord, out sn);
                    sn.frequence += 1;
                    if (sn.allForms.Contains(word))
                    {
                        var node = sn.allForms.First(n => n.Equals(word));
                        node.frequence++;
                    }
                    else
                    {
                        sn.allForms.Add(word);
                    }
                }
            }
            return result;
        }
        /* public static void CodeAnalys(string line, RichTextBox rb)
         {
             var lemmatizer = new Lemmatizer();
             var lemma = lemmatizer.Lemmatize("came");
             var stringBuilder = new StringBuilder();
             var modelPath = @"e:\MyWORK\Models\EnglishPOS.nbin";
             var tagDictDir = @"e:\MyWORK\Models\Parser\tagdict";
             var tokenizer = new EnglishMaximumEntropyTokenizer(modelPath);
             var posTagger = new EnglishMaximumEntropyPosTagger(modelPath, tagDictDir);
             var wordRegex = new Regex("^[A-Za-z]+$");
             string output = "";
             string[] words = tokenizer.Tokenize(line)
                             .Where(s => !String.IsNullOrEmpty(s))
                             .Select(s => s.ToLower()).ToArray();
             var pos = posTagger.Tag(words);
             for (int i = 0; i < words.Length; i++)
             {
                 if (wordRegex.IsMatch(words[i]))
                 {
                     output += words[i] + " " + pos[i] + "\n";
 
                 }
             }
             rb.Text = output;
         }*/

        private static Dictionary<string, int> ParseTexts(StreamReader sr)
        {
            ParseFile(sr, My_Dictionary.dictionaryBasic);
            return My_Dictionary.dictionaryBasic;
        }

        public static void SerializeResult(string outputPath, Dictionary<string, int> dictionary)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, SuperDictionary.canonical_groups);
            }
        }
        public static Dictionary<string, SuperDictionary.Canonicalgroup> DeserialiseDictionaryFrom(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (path == null)
                return SuperDictionary.canonical_groups;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            SuperDictionary.canonical_groups = (Dictionary<string, SuperDictionary.Canonicalgroup>) formatter.Deserialize(fs);
            return SuperDictionary.canonical_groups;
        }
        public static void OutputResultToTextFile(string outputPath, string resultpath)
        {
            List<KeyValuePair<string, int>> dictionary;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
            {
                dictionary = ((Dictionary<string, int>)formatter.Deserialize(fs)).ToList();
            }
            dictionary.Sort((p1, p2) => p2.Value.CompareTo(p1.Value));
            using (StreamWriter writer = new StreamWriter(resultpath))
            {
                writer.WriteLine("Total number of words: " + dictionary.Sum(word => word.Value));
                foreach (var word in dictionary)
                {
                    writer.WriteLine(word.Key + " " + word.Value);
                }
            }
        }
       
        
    }
    public static class My_Dictionary
    {
        public static Dictionary<string, int> dictionaryBasic;
        public static Dictionary<string, int> nextDictionary;
        public static Dictionary<string, Code[]> dictionaryCodeBasic;
        public static Dictionary<string, Code[]> nextDictionaryCodeBasic;
        public static readonly string[] Codes = new string[35] { "NN", "FW", "RP", "WRB", "POS", "TO", "JJR", "VB", "JJS", "CD", "PRP$", "MD", "CC", "EX", "WP", "UH", "VBD", "NNPS", "JJ", "WP$", "VBP", "RB", "DT", "SYM", "WDT", "VBZ", "LS", "PDT", "RBS", "IN", "NNP", "NNS", "RBR", "VBN", "VBG" };
        public static string help = "e:\\help.rtf";

    }

    public struct Code
    {
        public string NameOfCode;
        public int frequence;
        public int percentage;
    }
}
