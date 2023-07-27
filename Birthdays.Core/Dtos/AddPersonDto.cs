using Microsoft.AspNetCore.Http;

namespace Birthdays.Core.Dtos;

public class AddPersonDto
{
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public IFormFile Image { get; set; }
}