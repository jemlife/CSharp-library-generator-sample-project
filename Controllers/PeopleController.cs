using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGenerator.Controllers
{
    public class PeopleController : IPersonRepository
    {


        public MainController MainController { get; set; }
        public BooksController BookController { get; set; }
        public MagazineController MagazineController { get; set; }
        public MovieController MovieController { get; set; }
        public static LibraryController LibraryController { get; set; }
        public static Person Person { get; set; }
        public static List<Person> People { get; set; }

        public PeopleController(MainController mainController)
        {

            MainController = mainController;
            LibraryController = new LibraryController(this);
            People = new List<Person>();

        }


        public void AddPerson(Person person)
        {
            if (Person.Name != string.Empty) People.Add(person);
            else
                Console.WriteLine("Person name is required!");
        }

        public void AddLogic()
        {
            PersonInput();

            bool containsPerson =
                People.Any(per => per.Name == Person.Name);
            if (!containsPerson)
            {

                AddPerson(Person);
            }

            else
            {
                Console.WriteLine("User already exists!");
                Console.WriteLine();
            }

        }

        public void DeletePerson(Person person)
        {
            People.RemoveAll(x => x.Name == person.Name);
        }

        public void DeleteLogic()
        {
            Console.Write("Enter name of person: ");
            Person.Name = Console.ReadLine();

            bool containsPerson =
                People.Any(per => per.Name == Person.Name);
            if (containsPerson)
            {

                DeletePerson(Person);

            }
        }

        public void ViewLogic()
        {
            if (!People.Any())
            {
                Console.WriteLine("There are no people!");

            }
            else
            {

                GetPeople();

            }
        }

        public void PeopleModificationMenu()
        {

            Console.WriteLine();
            Console.WriteLine("People");
            Console.WriteLine();
            Console.WriteLine("What would you like to modify in your people list?");
            Console.WriteLine("1- Add a person");
            Console.WriteLine("2- Delete a person");
            Console.WriteLine("3- List people");
            Console.WriteLine("4- Back to Main menu");

        }

        public void PersonInput()
        {
            Console.Write("Enter name of person: ");
            Person = new Person {Name = Console.ReadLine()};
        }

        public IEnumerable<Person> GetPeople()
        {
            foreach (var p in People)
            {
                Console.WriteLine("Person: {0}", p.Name);
            }
            return People;
        }
        
        public Person GetPerson(Person person)
        {

            Console.Write("Enter name of person: ");
            Person.Name = Console.ReadLine();

            if (string.IsNullOrEmpty(Person.Name))
            {
                Console.WriteLine("This user doesn't exist!");
                MainController.MainMenu();

            }

            var containsPerson =
                People.Any(
                    per => per.Name == Person.Name);
            if (!containsPerson)
            {
                Console.WriteLine("This user doesn't exist!");
                MainController.MainMenu();


            }

            else
            {

                LibraryController.LibraryModificationMenu();

            }
            return person;
        }

    }
}
