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
    public class Person
    {
       
       
        public string Name { get; set; }
        public Library Library { get; set; }
       
       

        public Person()
        {
           
          
            Library = new Library();       

        }

        public override string ToString()
        {
            return Name;
        }

      




    }
}
