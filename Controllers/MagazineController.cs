using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGenerator.Controllers
{
    public class MagazineController : IController
    {

        public LibraryController LibraryController { get; set; }
        public Magazine Magazine { get; set; }



        public MagazineController(LibraryController libraryController)
        {
            LibraryController = libraryController;
          

        }

        public void MagazineModificationMenu()
        {
            Console.WriteLine("What would you like to modify in your magazine list?");
            Console.WriteLine("1- Add a magazine");
            Console.WriteLine("2- Delete a magazine");
            Console.WriteLine("3- List magazines");
            Console.WriteLine("4- Back to Main menu");
        }

        public void AddLogic()
        {
            ItemInput();

            var containsMagazine = PeopleController.Person.Library.Magazines.GetLibraryItem(Magazine.Title);

            //bool containsMagazine =
            //    PeopleController.Person.Library.Magazines.Any(
            //        per => per.Title == Magazine.Title);
            if (!containsMagazine)
            {

                AddObject(Magazine);

            }

            else
            {
                Console.WriteLine("Magazine already exists!");
                Console.WriteLine();
            }
        }

        public void DeleteLogic()
        {
            Console.WriteLine("Enter magazine title:");
            Magazine.Title = Console.ReadLine();

            var containsMagazine = PeopleController.Person.Library.Magazines.GetLibraryItem(Magazine.Title);
            //bool containsMagazine =
            //    PeopleController.Person.Library.Magazines.Any(
            //        per => per.Title == Magazine.Title);
            if (containsMagazine)
            {
                DeleteObject(Magazine);

            }

            else
            {
                Console.WriteLine("Magazine doesn't exist!");
            }
        }

        public void ViewLogic()
        {
            if (!PeopleController.Person.Library.Magazines.Any())
            {
                Console.WriteLine("There aren't any magazines!");
            }

            else
            {
                ListLibraryItem(Magazine);
                Console.WriteLine();
            }
        }

        public void ItemInput()
        {
            Console.WriteLine("Enter title of magazine");
            Magazine = new Magazine();
            Magazine.Title = Console.ReadLine();

            Console.WriteLine("Enter writer");
            Magazine.Writer = Console.ReadLine();

            Console.WriteLine("Enter publisher");
            Magazine.Publisher = Console.ReadLine();

            Console.WriteLine("Enter volume");
            Magazine.Volume = Convert.ToInt32(Console.ReadLine());
        }

        public void AddObject(ILibraryItem item)
        {
            if (item.Title != string.Empty) PeopleController.Person.Library.Magazines.AddLibraryItem(Magazine);
            else
                Console.WriteLine("Magazine title is required!");
        }

        public void DeleteObject(ILibraryItem item)
        {
            PeopleController.Person.Library.Magazines.DeleteLibraryItem(item.Title);
        }

        public IEnumerable<ILibraryItem> ListLibraryItem(ILibraryItem item)
        {
            foreach (var mag in PeopleController.Person.Library.Magazines)
            {
                Console.WriteLine("Magazines ");
                Console.WriteLine("Title: {0} ", item.Title);
                Console.WriteLine("Writer: {0} ", item.Writer);
                Console.WriteLine("Publisher: {0} ", mag.Publisher);
                Console.WriteLine("Volume: {0} ", mag.Volume);

            }
            return PeopleController.Person.Library.Magazines;
        }
    }
}
