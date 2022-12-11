using CoffeeShop.Models;
using CoffeeShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

[ApiController]
[Route("[controller]")]
public class CoffeeController : ControllerBase
{
    public CoffeeController() {}
    [HttpGet]
    public ActionResult<List<Coffee>> GetAll() => CoffeeService.GetAll();
    [HttpGet("{id}")]
    public ActionResult<Coffee> Get(int id)
    {
        var coffee = CoffeeService.Get(id);

        if(coffee == null)
           return NotFound();
        
        return coffee;
    }
    [HttpPost]
    public IActionResult Create(Coffee coffee)
    {
        CoffeeService.Add(coffee);
        return CreatedAtAction(nameof(Create), new {id = coffee.Id},coffee);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, Coffee coffee)
    {
        if (id != coffee.Id)
           return BadRequest();
        
        var existingCoffee = CoffeeService.Get(id);
        
        if (existingCoffee == null)
           return NotFound();
        
        CoffeeService.Update(coffee);

        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var coffee = CoffeeService.Get(id);

        if (coffee == null)
           return NotFound();

        CoffeeService.Delete(id);
        
        return NoContent();
    }

}
