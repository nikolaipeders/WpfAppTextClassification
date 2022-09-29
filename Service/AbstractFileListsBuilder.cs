using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTextClassification.Model;

namespace WpfAppTextClassification.ViewModel
{
    public abstract class AbstractFileListsBuilder { 
    
        public abstract void GenerateFileNamesInA();

        public abstract void GenerateFileNamesInB();
        
        //  get the complete FileLists-object
        public abstract FileLists GetFileLists();

    }
}
