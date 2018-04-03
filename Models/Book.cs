using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibraryGenerator
{
    [Serializable]
    public class Book : ILibraryItem
    {
       

        private string m_title;
        public string Title { get; set; }
        public int BookId { get; set; }
        public string Publisher { get; set; }
        public int Published { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Writer { get; set; }



       
        public Book()
        {
           
           
 
        }



        public override string ToString()
        {
            return Title;
        }






    }
}
