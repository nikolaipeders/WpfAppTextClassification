using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfAppTextClassification.Model;
using WpfAppTextClassification.Service;
using WpfAppTextClassification.Tools;

namespace WpfAppTextClassification.ViewModel
{
    public class DictionaryViewModel : Bindable
    {
        private static ObservableCollection<string> _dictionary = new ObservableCollection<string>();
        private string _selectedString;
        private string _numberOfTokens;

        public DictionaryViewModel()
        {
            NumberOfTokens = "Dimension: " + Dictionary.Count();
        }

        public string SelectedString
        {
            get
            {
                return _selectedString;
            }
            set
            {
                _selectedString = value;
                propertyIsChanged();
            }
        }

        public string NumberOfTokens
        {
            get
            {
                return _numberOfTokens;
            }
            set
            {
                _numberOfTokens = value;
                propertyIsChanged();
            }
        }

        public static ObservableCollection<string> Dictionary
        {
            get
            {
                return _dictionary;
            }
            set
            {
                _dictionary = value;
            }
        }
    }
}
