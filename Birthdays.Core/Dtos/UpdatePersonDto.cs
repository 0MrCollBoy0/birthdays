using Microsoft.AspNetCore.Http;

namespace Birthdays.Core.Dtos;

public class UpdatePersonDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public IFormFile Image { get; set; }
}