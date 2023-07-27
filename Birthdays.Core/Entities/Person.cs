using System.Net.Mime;

namespace Birthdays.Core.Entities;

public class Person
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public byte[] Image { get; set; }
}