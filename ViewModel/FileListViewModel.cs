using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using WpfAppTextClassification.Model;
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
            TrainCMD = new DelegateCommand(TrainAI);

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
        private void TrainAI()
        {
            KnowledgeBuilder nb = new KnowledgeBuilder();

            // initiate the learning process
            nb.Train();

            // getting the (whole) knowledge found in ClassA and in ClassB
            Knowledge k = nb.GetKnowledge();

            // get a part of the knowledge - here just for debugging
            BagOfWords bof = k.GetBagOfWords();
            Categorizer.bagOfWords = k.GetBagOfWords();

            List<string> entries = bof.GetEntriesInDictionary();

            DictionaryViewModel.Dictionary.Clear();

            foreach (string entry in entries)
            {
                DictionaryViewModel.Dictionary.Add(entry);
            }

            Vectors vectors = new Vectors();
            vectors = nb.GetVectors();
            Categorizer.vectors = vectors;

            VectorViewModel.VectorA = vectors.GetVectorsInA().SelectMany(x => x).ToList();

            VectorViewModel.VectorB = vectors.GetVectorsInB().SelectMany(x => x).ToList();
        }

        public ICommand TrainCMD { get; set; }
    }
}
