using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryGenerator.Controllers;
using Newtonsoft.Json;

namespace LibraryGenerator
{
    [Serializable]
    public class Library
    {

       
        public List<Book> Books { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Magazine> Magazines { get; set; }
      
 
        public Library()
        {
            
           
            Books = new List<Book>();
            Movies = new List<Movie>();
            Magazines = new List<Magazine>();
           

        }
    }
}
