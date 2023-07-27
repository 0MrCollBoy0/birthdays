using System.Net.Mime;
using System.Text;
using Birthdays.Core.Dtos;
using Birthdays.Core.Entities;
using Birthdays.Core.Interfaces;

namespace Birthdays.Core.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository)
    {
        _repository = repository;
    }
    
    public IEnumerable<PersonDto> GetAll()
    {
        List<PersonDto> result = new List<PersonDto>();
        var models = _repository.GetAll();
        foreach (var person in models)
        {
            result.Add(new PersonDto()
            {
                Id = (int)person.Id,
                Name = person.Name,
                Birthday = person.Birthday,
                Image = Convert.ToBase64String(person.Image)
            });
        }

        return result;
    }

    public IEnumerable<PersonDto> GetUpcoming()
    {
        return _repository.GetUpcoming().Select(b =>
            new PersonDto()
            {
                Id = (int)b.Id,
                Name = b.Name,
                Birthday = b.Birthday,
                Image = Convert.ToBase64String(b.Image)
            });
    }

    public PersonDto? GetById(int id)
    {
        var person = _repository.GetById(id);
        return new PersonDto()
        {
            Id = (int)person.Id,
            Name = person.Name,
            Birthday = person.Birthday
        };
    }

    public int Add(AddPersonDto model)
    {
        using (var ms = new MemoryStream())
        {
            model.Image.CopyTo(ms);

            return _repository.Add(new Person()
            {
                Name = model.Name,
                Birthday = model.Birthday,
                Image = ms.ToArray()
            });
        }
    }

    public void Update(UpdatePersonDto model)
    {
        using (var ms = new MemoryStream())
        {
            model.Image.CopyTo(ms);

            _repository.Update(new Person()
            {
                Id = model.Id,
                Name = model.Name,
                Birthday = model.Birthday,
                Image = ms.ToArray()
            });
        }
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}