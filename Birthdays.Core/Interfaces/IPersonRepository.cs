using Birthdays.Core.Entities;

namespace Birthdays.Core.Interfaces;

public interface IPersonRepository
{
    IEnumerable<Person> GetAll();
    IEnumerable<Person> GetUpcoming();
    Person? GetById(int id);
    int Add(Person model);
    void Update(Person model);
    void Delete(int id);
}