using Birthdays.Core.Dtos;

namespace Birthdays.Core.Interfaces;

public interface IPersonService
{
    IEnumerable<PersonDto> GetAll();
    IEnumerable<PersonDto> GetUpcoming();
    PersonDto? GetById(int id);
    int Add(AddPersonDto model);
    void Update(UpdatePersonDto model);
    void Delete(int id);
}