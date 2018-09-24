using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenNLP.Tools.Util;
using TextParser;

namespace TextParser
{
    public static class SuperDictionary
    {
        public static Dictionary<string, Canonicalgroup> canonical_groups = new Dictionary<string, Canonicalgroup>();

        [Serializable]
        public class Canonicalgroup
        {
            public int frequence;
            public System.Collections.Generic.HashSet<Node> group;

            public Canonicalgroup()
            {
                frequence = 1;
                group = new System.Collections.Generic.HashSet<Node>();
            }
        }
        public static bool AddingToGroup(string word, string tag, string basicWord, int frequence)
        {
            Canonicalgroup gr;
            if (canonical_groups.ContainsKey(basicWord))
            {
                Node new_n = new Node(word, tag);
                new_n.frequence = frequence;
                gr = canonical_groups[basicWord];
                new_n.mainWord = basicWord;
                foreach (var wordik in gr.@group)
                {
                    if ((wordik.word == word) && (wordik.tag == tag))
                        return false;
                }
                gr.@group.Add(new_n);
                gr.frequence += new_n.frequence;
                return true;
            }
            CreatingGroupByWord(basicWord, tag, frequence);
            AddingToGroup(word, tag, basicWord, frequence);
            return true;
            /*else
                gr = new Canonicalgroup();
            gr.@group.Add(word);*/
        }

        public static void Add(SuperNode snd)
        {
            //if (!canonical_groups.ContainsKey(snd.mainword))
            //{

            //}
            foreach (var nd in snd.allForms)
            {
                AddingToGroup(nd.word, nd.tag, nd.mainWord, nd.frequence+1);
            }
        }

        public static bool AddingToGroup(string word, string basicWord)
        {
            Canonicalgroup gr;
            if (canonical_groups.ContainsKey(basicWord))
            {
                String[] values = word.Split(' ');
                Node new_n = new Node(values[0], values[1]);
                new_n.frequence = 1;
                gr = canonical_groups[basicWord];
                new_n.mainWord = basicWord;
                gr.@group.Add(new_n);
                gr.frequence += new_n.frequence;
                return true;
            }
            return false;
            /*else
                gr = new Canonicalgroup();
            gr.@group.Add(word);*/
        }

        public static bool DeleteGroup(string canonicalWord)
        {
            if (canonical_groups.ContainsKey(canonicalWord))
            {
                canonical_groups.Remove(canonicalWord);
                return true;
            }
            return false;
        }

        public static bool CreatingGroupByWord(string word, string tag, int frequence)
        {
            if (canonical_groups.ContainsKey(word))
                return false;
            Canonicalgroup gr=new Canonicalgroup();
            gr.frequence = frequence;
            Node new_n=new Node(word, tag);
            new_n.frequence = frequence;
            new_n.mainWord = word;
            gr.@group.Add(new_n);
            canonical_groups.Add(word, gr);
            return true;
        }

        public static Canonicalgroup FindWord(string word, string basicWord)
        {
            Canonicalgroup gr=null;
            if (canonical_groups.ContainsKey(basicWord))
            {
                gr = canonical_groups[basicWord];
                foreach (var nod in gr.@group)
                {
                    if (word == nod.word)
                        return gr;
                }
            }
            return null;
        }

        public static bool DeleteWord(string word, string basicWord)
        {
            Canonicalgroup gr = FindWord(word, basicWord);
            if (gr != null)
            {
                foreach (var nod in gr.@group)
                {
                    if (word == nod.word)
                    {
                        gr.@group.Remove(nod);
                        break;
                    }
                }
                return true;
            }
            return false;
        }
    }

}
