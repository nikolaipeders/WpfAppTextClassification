using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using WpfAppTextClassification.Service;
using WpfAppTextClassification.Tools;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace WpfAppTextClassification.ViewModel
{
    public class TrainerViewModel : Bindable
    {
        private string _selectedString;
        private string _textInFile;
        private string _category;
        private string _numberOfTokens;
        private FileAdapter _fileAdapter;


        public TrainerViewModel()
        {
            _fileAdapter = new TextFile("txt");

            FileFetcherCMD = new DelegateCommand(FileFetcher);
            CategorizeCMD = new DelegateCommand(Categorize);
        }

        public string SelectedString
        {
            get
            {
                return _selectedString;
            }
            set
            {                
                if (value.EndsWith(".pdf"))
                {
                    TextInFile = StringOperations.ConvertPDFToString(value);                    
                }
                else
                {
                    TextInFile = _fileAdapter.GetAllTextFromFileA(value);
                }
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

        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                propertyIsChanged();
            }
        }


        public void FileFetcher()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                SelectedString = openFileDialog.FileName;
            }
        }

        public void Categorize()
        {
            Category = Categorizer.CategorizeText(TextInFile);
        }

        public ICommand FileFetcherCMD { get; set; }

        public ICommand CategorizeCMD { get; set; }
    }
}
