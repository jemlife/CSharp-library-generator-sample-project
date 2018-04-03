using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryGenerator.Controllers;


namespace LibraryGenerator
{
    public class Program
    {
        private static MainController MainController { get; set; }

        static void Main(string[] args)
        {
            MainController = new MainController();
            MainController.Begin();
        }
    }
}