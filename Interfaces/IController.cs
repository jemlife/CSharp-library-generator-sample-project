using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGenerator
{
    public interface IController
    {

        void AddLogic();
        void DeleteLogic();
        void ViewLogic();
        void ItemInput();
        void AddObject(ILibraryItem item);
        void DeleteObject(ILibraryItem item);
        IEnumerable<ILibraryItem> ListLibraryItem(ILibraryItem item);
    }
}
