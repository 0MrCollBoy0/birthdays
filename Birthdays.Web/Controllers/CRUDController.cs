using Birthdays.Core.Dtos;
using Birthdays.Core.Entities;
using Birthdays.Core.Interfaces;
using Birthdays.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

public class CRUDController:Controller
{
    private readonly IPersonService _personService;

    public CRUDController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public IActionResult AddPerson()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddPerson(string name, DateTime birthday, [FromForm]IFormFile uploadedFile)
    {
        _personService.Add(new AddPersonDto()
        {
            Name = name,
            Birthday = new DateTime(birthday.Year, birthday.Month,birthday.Day, 0, 0, 0, DateTimeKind.Utc),
            Image = uploadedFile
        });
        return RedirectToAction("Index", "Home", 1);
    }

    [HttpGet]
    public IActionResult UpdatePerson(int id)
    {
        var person = _personService.GetById(id);
        return View(model: person);
    }
    [HttpPost]
    public IActionResult UpdatePerson(int id, string name, DateTime birthday, IFormFile uploadedFile)
    {
        _personService.Update(new UpdatePersonDto()
        {
            Id = id,
            Name = name,
            Birthday = new DateTime(birthday.Year, birthday.Month,birthday.Day, 0, 0, 0, DateTimeKind.Utc),
            Image = uploadedFile
        });
        return RedirectToAction("Index", "Home", 1);
    }

    [HttpGet]
    public IActionResult DeletePerson(int id)
    {
        var person = _personService.GetById(id);
        return View(model: person);
    }
    [HttpPost]
    public IActionResult DeletePerson(int id, string name)
    {
        _personService.Delete(id);
        return RedirectToAction("Index", "Home", 1);
    }


}