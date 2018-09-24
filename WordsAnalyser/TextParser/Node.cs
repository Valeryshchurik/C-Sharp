using System;

namespace TextParser
{
    [Serializable]
    public class Node: BasePropertyChanged
    {
        public string mainWord
        {
            get { return _mainWord; }
            set
            {
                _mainWord = value;
                OnPropertyChanged();
            }
        }

        public string word
        {
            get { return _word; }
            set
            {
                _word = value;
                OnPropertyChanged();
            }
        }

        public string tag
        {
            get { return _tag; }
            set
            {
                _tag = value;
                OnPropertyChanged();
            }
        }

        public int frequence
        {
            get { return _frequence; }
            set
            {
                _frequence = value;
                OnPropertyChanged();
            }
        }

        private string _tag;
        private string _word;
        private string _mainWord;
        private int _frequence;
        
        public Node(string word, string tag)
        {
            this.word = word;
            this.tag = tag;
            int frequence = 1;
        }

        public override bool Equals(object obj)
        {
            var obj2 = obj as Node;
            if (obj2==null)
                return false;
            return obj2.tag.Equals(tag)&& obj2.word.Equals(word);
        }

        public override int GetHashCode()
        {
            return word.GetHashCode();
        }
    }
}
