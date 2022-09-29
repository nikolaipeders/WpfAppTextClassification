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
            TrainCMD = new DelegateCommand(TrainAI);
        }
        private void TrainAI()
        {
            ((App)App.Current).ChangeUserControl(typeof(TrainerViewModel));

            KnowledgeBuilder nb = new KnowledgeBuilder();

            // initiate the learning process

            nb.Train();

            // getting the (whole) knowledge found in ClassA and in ClassB
            Knowledge k = nb.GetKnowledge();

            // get a part of the knowledge - here just for debugging
            BagOfWords bof = k.GetBagOfWords();

            List<string> entries = bof.GetEntriesInDictionary();

            DictionaryViewModel.Dictionary.Clear();

            foreach (string entry in entries)
            {
                DictionaryViewModel.Dictionary.Add(entry);
            }

            TrainerViewModel.timer.Stop();

            TrainerViewModel.InfoText = "Completed";
        }

        public ICommand TrainCMD { get; set; }

        public ICommand ChangePageToDictionaryViewCMD { get; set; } = new DelegateCommand(() => { ((App)App.Current).ChangeUserControl(typeof(DictionaryViewModel)); });

        public ICommand ChangePageToFileListViewCMD { get; set; } = new DelegateCommand(() => { ((App)App.Current).ChangeUserControl(typeof(FileListViewModel)); });
    }
}
