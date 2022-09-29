using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppTextClassification.Service;
using WpfAppTextClassification.Tools;

namespace WpfAppTextClassification.ViewModel
{
    public class FileListViewModel : Bindable
    {
        private ObservableCollection<string> _folderCollection;
        private ObservableCollection<string> _filesCollectionA;
        private ObservableCollection<string> _filesCollectionB;
        private string _selectedString;
        private string _textInFile;
        private string _numberOfTokens;
        private FileAdapter _fileAdapter;

        public FileListViewModel()
        {
            _fileAdapter = new TextFile("txt"); 

            FilesCollectionA = new ObservableCollection<string>(_fileAdapter.GetAllFileNames("ClassA"));

            FilesCollectionB = new ObservableCollection<string>(_fileAdapter.GetAllFileNames("ClassB"));
        }

        public string SelectedString 
        { 
            get
            {
                return _selectedString;
            } 
            set
            {
                TextInFile = _fileAdapter.GetAllTextFromFileA(value);
                _selectedString = value;
                propertyIsChanged();
            }
        }

        public string TextInFile
        {
            get
            {
                return _textInFile;
            }
            set
            {
                _textInFile = value;
                NumberOfTokens = "Number of tokens: " + Tokenization.Tokenize(value).Count();
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

        public ObservableCollection<string> FolderCollection
        {
            get
            {
                return _folderCollection;
            }
            set
            {
                _folderCollection = value;
                propertyIsChanged();
            }
        }

        public ObservableCollection<string> FilesCollectionA
        {
            get
            {
                return _filesCollectionA;
            }
            set
            {
                _filesCollectionA = value;
                propertyIsChanged();
            }
        }
        public ObservableCollection<string> FilesCollectionB
        {
            get
            {
                return _filesCollectionB;
            }
            set
            {
                _filesCollectionB = value;
                propertyIsChanged();
            }
        }
    }
}
