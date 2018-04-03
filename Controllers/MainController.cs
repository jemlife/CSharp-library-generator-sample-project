using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryGenerator.Controllers;
using Newtonsoft.Json;


namespace LibraryGenerator
{
    public class MainController
    {
        public PeopleController PeopleController { get; set; }
        public BooksController BooksController { get; set; }
        public LibraryController LibraryController { get; set; }
        public MovieController MovieController { get; set; }
        public MagazineController MagazineController { get; set; }

        public MainController()
        {
            PeopleController = new PeopleController(this);
            LibraryController = new LibraryController(PeopleController);
            BooksController = new BooksController(LibraryController);
            MovieController = new MovieController(LibraryController);
            MagazineController = new MagazineController(LibraryController);
        }

        bool repeat = true;
        private string option;

        public void Begin()
        {
            do
            {
                MainMenu();
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":

                        PeopleController.PeopleModificationMenu();
                        option = Console.ReadLine();

                        if (option == "1") // Add person
                        {
                            PeopleController.AddLogic();
                        }

                        else if (option == "2") // Delete person
                        {
                            PeopleController.DeleteLogic();
                        }

                        else if (option == "3") // View people
                        {
                            PeopleController.ViewLogic();
                        }

                        else if (option == "4")
                        {
                            MainMenu();
                        }
                        break;

                    case "2":

                        LibraryController.LibraryMenu();
                        option = Console.ReadLine();

                        if (option == "1")
                        {
                            PeopleController.GetPerson(PeopleController.Person);
                            option = Console.ReadLine();


                            if (option == "1")
                            {
                                BooksController.BookModificationMenu();
                                option = Console.ReadLine();

                                if (option == "1") // Add book
                                {
                                    BooksController.AddLogic();
                                }

                                if (option == "2") // Delete book
                                {
                                    BooksController.DeleteLogic();
                                }

                                if (option == "3") // View books
                                {
                                    BooksController.ViewLogic();
                                }

                                if (option == "4") // return to Library menu
                                {
                                    LibraryController.LibraryModificationMenu();
                                }
                            }

                            else if (option == "2")
                            {
                                MagazineController.MagazineModificationMenu();
                                option = Console.ReadLine();


                                if (option == "1") // Add magazine
                                {
                                    MagazineController.AddLogic();
                                }

                                if (option == "2") // Delete magazine
                                {
                                    MagazineController.DeleteLogic();
                                }

                                if (option == "3") // View magazine
                                {
                                    MagazineController.ViewLogic();
                                }

                                if (option == "4") // Return to Library menu
                                {
                                    LibraryController.LibraryModificationMenu();
                                }
                            }

                            else if (option == "3")
                            {
                                MovieController.MovieModificationMenu();
                                option = Console.ReadLine();


                                if (option == "1") // Add movie
                                {
                                    MovieController.AddLogic();
                                }

                                if (option == "2") // Delete movie
                                {
                                    MovieController.DeleteLogic();
                                }

                                if (option == "3") // View movie
                                {
                                    MovieController.ViewLogic();
                                }

                                if (option == "4") // Return to library menu
                                {
                                    LibraryController.LibraryModificationMenu();
                                }
                            }
                        }

                        else if (option == "2") // Delete library 
                        {
                            LibraryController.DeleteLibrary(BooksController.Book, MovieController.Movie,
                                MagazineController.Magazine);
                        }

                        else if (option == "3") // View library
                        {
                            LibraryController.ViewLogic();
                        }

                        else if (option == "4") // return to Main menu
                        {
                            MainMenu();
                        }

                        break;

                    case "3": // Exit application

                        End();

                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Wrong option. Please re-enter\n");
                        break;
                }
            } while (repeat);
        }

        public void End()
        {
            //SaveToJson();
            repeat = false;
        }


        public void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Library Generator");
            Console.WriteLine();
            Console.WriteLine("What would you like to modify?");
            Console.WriteLine("1- People");
            Console.WriteLine("2- Library");
            Console.WriteLine("3- Exit");
            Console.Write("Enter an option: ");
        }

        //public void LoadJson()
        //{
        //    var dir = FileUtils.AppFolder.GetSubFolder("Data");
        //    var fileDir = dir.GetFile("data.json");
        //    if (fileDir != null)
        //    {
        //        using (StreamReader file = File.OpenText(fileDir.FullName))
        //        {
        //            string json = file.ReadToEnd();
        //            Person per = JsonConvert.DeserializeObject<Person>(json);
        //            //if (lib == null) return;
        //            //PeopleController.Person.Library.Books.SetValues(lib.Books);
        //            //PeopleController.Person.Library.Movies.SetValues(lib.Movies);
        //            //PeopleController.Person.Library.Magazines.SetValues(lib.Magazines);

        //            //JsonSerializer serializer = new JsonSerializer();
        //            //Person per = (Person)serializer.Deserialize(file, typeof(Person));
        //        }
        //    }
        //}

        //public void SaveToJson()
        //{
        //    bool confirmed2 = false;
        //    string Key2;
        //    ConsoleKey response2;

        //    do
        //    {
        //        Console.WriteLine("Do you want to save changes? [y/n]");
        //        response2 = Console.ReadKey(false).Key;

        //        if (response2 != ConsoleKey.Enter && response2 != ConsoleKey.N)
        //        {
        //            var dir = FileUtils.AppFolder.GetSubFolder("Data");
        //            dir.EnsureExists();

        //            using (StreamWriter file = File.CreateText(dir + @"\" + "data.json"))
        //            {
        //                JsonSerializer serializer = new JsonSerializer();
        //                serializer.Serialize(file, PeopleController.Person);

        //                //serializer.Serialize(file, PeopleController.Person.Library);
        //                //JsonSerializer serializer2 = new JsonSerializer();
        //                //serializer.Serialize(file, PeopleController.Person.Library);
        //            }
        //        }
        //    } while (response2 != ConsoleKey.Y && response2 != ConsoleKey.N);
        //    confirmed2 = response2 == ConsoleKey.Y;
        //}
    }
}