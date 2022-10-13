using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using WpfAppTextClassification.Model;
using WpfAppTextClassification.Service;
using WpfAppTextClassification.Tools;

namespace WpfAppTextClassification.ViewModel
{
    public class MainWindowViewModel : Bindable
    {
        public MainWindowViewModel()
        {
        }

        public ICommand ChangePageToDictionaryViewCMD { get; set; } = new DelegateCommand(() => { ((App)App.Current).ChangeUserControl(typeof(DictionaryViewModel)); });
        public ICommand ChangePageToFileListViewCMD { get; set; } = new DelegateCommand(() => { ((App)App.Current).ChangeUserControl(typeof(FileListViewModel)); });
        public ICommand ChangePageToTrainerViewCMD { get; set; } = new DelegateCommand(() => { ((App)App.Current).ChangeUserControl(typeof(TrainerViewModel)); });
        public ICommand ChangePageToVectorViewCMD { get; set; } = new DelegateCommand(() => { ((App)App.Current).ChangeUserControl(typeof(VectorViewModel)); });
    }
}
