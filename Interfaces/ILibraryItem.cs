using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGenerator
{
    public interface ILibraryItem
    {

        string Title { get; set; }
        string Writer { get; set; }
        DateTime ReleaseDate { get; set; }
       
        
    }
}
