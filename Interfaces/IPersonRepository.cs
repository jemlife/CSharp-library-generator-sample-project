using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGenerator
{
    public interface IPersonRepository
    {

        IEnumerable<Person> GetPeople();
        Person GetPerson(Person person);
        void AddPerson(Person person);
        void DeletePerson(Person person);

    }
}
