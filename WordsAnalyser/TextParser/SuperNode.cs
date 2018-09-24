using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public class SuperNode: BasePropertyChanged
    {
        private string _mainword;
        public string mainword
        {
            get { return _mainword; }
            set
            {
                _mainword = value;
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

        public HashSet<Node> allForms
        {
            get { return _allForms; }
            set
            {
                _allForms = value;
                OnPropertyChanged();
            }
        }

        private int _frequence;
        private HashSet<Node> _allForms = new HashSet<Node>();
    }
}
