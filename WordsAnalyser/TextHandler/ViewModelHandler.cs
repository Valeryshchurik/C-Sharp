using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using TextParser;

namespace TextHandler
{
    public class ViewModelHandler: BasePropertyChanged
    {
        private bool analysExecutingNow = false;
        private BindingList<Node> _wordsFromText = new BindingList<Node>();
        private ObservableCollection<SuperNode> _smallDictionary = new ObservableCollection<SuperNode>();
        public ObservableCollection<SuperNode> smallDictionary
        {
            get { return _smallDictionary; }
            set
            {
                _smallDictionary = value;
                OnPropertyChanged();
            }
        }

        public BindingList<Node> WordsFromText
        {
            get { return _wordsFromText; }
            set
            {
                _wordsFromText = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenFileCommand { get; set; }
        public ICommand EditNodeInTextCommand { get; set; }
        public ICommand MergeDictionariesCommand { get; set; }
        public ICommand OrderByCommand { get; set; }
        public ViewModelHandler()
        {
            OpenFileCommand = new SimpleCommand(OpenFileExecute, o => !analysExecutingNow);
            EditNodeInTextCommand = new SimpleCommand(EditNodeInTextExecute);
            MergeDictionariesCommand = new SimpleCommand(MergeDictionariesExecute);
            OrderByCommand = new SimpleCommand(OrderByExecute);
            _wordsFromText.ListChanged += _wordsFromText_ListChanged;
            //WordsFromText
        }

        private void _wordsFromText_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (analysExecutingNow)
                return;
            smallDictionary.Clear();
            var new_list= new ObservableCollection<SuperNode>(DictionaryHelper.ConvertNodesToSuperNodes(_wordsFromText.ToList()).Select(pair => pair.Value).ToList());
            foreach (var node in new_list)
            {
                SuperDictionary.Add(node);
            }
        }

        public static T FindAncestor<T>(DependencyObject dependencyObject)
            where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);
 
            if (parent == null) return null;
 
            var parentT = parent as T;
            return parentT ?? FindAncestor<T>(parent);
        }
        public void OrderByExecute(object o1)
        {
            var column = o1 as GridViewColumnHeader;
            var grid = FindAncestor<ListView>(column);
            var binding = column?.Column?.DisplayMemberBinding as Binding;
            var propertyname = binding?.Path.Path;
            if (propertyname == null)
                return;
            var sortDescriptors = grid.Items.SortDescriptions;
            if (sortDescriptors.Contains(new SortDescription(propertyname, ListSortDirection.Ascending)))
            {
                sortDescriptors.Clear();
                sortDescriptors.Add(new SortDescription(propertyname, ListSortDirection.Descending));
                return;
            }
            if (sortDescriptors.Contains(new SortDescription(propertyname, ListSortDirection.Descending)))
            {
                sortDescriptors.Clear();
                sortDescriptors.Add(new SortDescription(propertyname, ListSortDirection.Ascending));
                return;
            }
            sortDescriptors.Clear();
            sortDescriptors.Add(new SortDescription(propertyname, ListSortDirection.Ascending));
            // column.
        }
        private void EditNodeInTextExecute(object o1)
        {
            Node n = o1 as Node;
            if (n == null)
                return;
            var wnd  =new NodeEditor();
            wnd.DataContext = n;
            wnd.ShowDialog();
        }

        private void MergeDictionariesExecute(object o)
        {
            int changeword = 0;
            foreach (var word in _smallDictionary)
            {
                SuperDictionary.Add(word);
            }
            MessageBox.Show("Слияние словарей произошло успешно!", "Готово!");
        }
        private async void OpenFileExecute(object o)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            List<Node> listfromtext=null;
            //List<SuperNode> smallDictionary = null;
            analysExecutingNow = true;
            if (openFileDialog.ShowDialog() == true)
            {
                string openedFileName = openFileDialog.FileName;
                WordsFromText.Clear();
                await Task.Run(() =>
                {
                    listfromtext = DictionaryHelper.CodeAnalys(openedFileName);
                }) .ConfigureAwait(true);
                smallDictionary = new ObservableCollection<SuperNode>(DictionaryHelper.ConvertNodesToSuperNodes(listfromtext).Select(pair => pair.Value).ToList());
                //WordsFromText = new ObservableCollection<Node>(listfromtext);
                foreach (var word in listfromtext)
                {
                    await Task.Delay(1);
                    WordsFromText.Add(word);
                }
            }
            analysExecutingNow = false;
        }
    }
}
