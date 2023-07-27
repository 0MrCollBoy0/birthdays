using Birthdays.Core.Entities;
using Birthdays.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Birthdays.Infrastructure.Repositories;

public class PerosnRepository:IPersonRepository
{
    private readonly PersonDbContext _dbContext;

    public PerosnRepository(PersonDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    private void SeedData(PersonDbContext dbContext)
    {
        var seeds = new List<Person>()
        {
            new Person() { Name = "Mustafa", Birthday = new DateTime(2004, 01, 05, 00, 00, 00, DateTimeKind.Utc) },
            new Person() { Name = "Ilya", Birthday = new DateTime(2003, 07, 04, 00, 00, 00, DateTimeKind.Utc) },
            new Person() { Name = "Amet", Birthday = new DateTime(2002, 01, 05, 00, 00, 00, DateTimeKind.Utc) },
            new Person() { Name = "Vadim", Birthday = new DateTime(2001, 01, 05, 00, 00, 00, DateTimeKind.Utc) }
        };
        dbContext.AddRange(seeds);
        dbContext.SaveChanges();
    }
    public IEnumerable<Person> GetAll()
    {
        return _dbContext.Persons.ToList();
    }

    public IEnumerable<Person> GetUpcoming()
    {
        var dayOfYearNow = DateTime.UtcNow.DayOfYear;
        var persons = _dbContext.Persons
            .Where(person =>
                person.Birthday.DayOfYear - dayOfYearNow < 32 && person.Birthday.DayOfYear - dayOfYearNow > -1)
            .OrderBy(person => person.Birthday.DayOfYear)
            .ToList();
        return persons;
    }

    public Person? GetById(int id)
    {
        return _dbContext.Persons.Find(id);
    }

    public int Add(Person model)
    {
        _dbContext.Persons.Add(model);
        _dbContext.SaveChanges();
        return (int)model.Id;
        
    }

    public void Update(Person model)
    {
        _dbContext.Persons.Update(model);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity is null) throw new ArgumentException("Не удалось найти объект!");
        _dbContext.Persons.Remove(entity);
        _dbContext.SaveChanges();
    }
}