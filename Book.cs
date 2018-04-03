using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGenerator
{
    public class Book : ILibraryItem
    {
        public string Title { get; set; }
        public int BookId { get; set; }
        public string Publisher { get; set; }
        public int Published { get; set; }
        public string Writer { get; set; }
        public int ReleaseDate { get; set; }



        private List<Book> m_books;
        public Book()
        {
            m_books = new List<Book>();
 
        }

       

       

      

      

    }
}
