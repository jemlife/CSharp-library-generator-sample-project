using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGenerator
{
    public class Library
    {

       
        public List<Book> Books { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Magazine> Magazines { get; set; }
        public LibraryController LibraryController { get; set; }
        public Library(LibraryController libraryController)
        {
            
            LibraryController = libraryController;
            Books = new List<Book>();
            Movies = new List<Movie>();
            Magazines = new List<Magazine>();
        }
    }
}
