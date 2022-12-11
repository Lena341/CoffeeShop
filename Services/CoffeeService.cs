using CoffeeShop.Models;

namespace CoffeeShop.Services;

public static class CoffeeService
{
    static List<Coffee> Coffees {get;}
    static int nextId = 6;
    static CoffeeService()
    {
        Coffees = new List<Coffee>
        {
            new Coffee {Id = 1, Name = "Cappucino", IsSugarFree = false},
            new Coffee {Id = 2, Name = "Americano", IsSugarFree = true},
            new Coffee {Id = 3, Name = "Black", IsSugarFree = true},
            new Coffee {Id = 4, Name = "Latte", IsSugarFree = false},
            new Coffee {Id = 5, Name = "Espresso", IsSugarFree = true}
        };
    }
    public static List<Coffee> GetAll() => Coffees;
    public static Coffee? Get(int id) => Coffees.FirstOrDefault(p => p.Id == id);
    public static void Add(Coffee coffee)
    {
        coffee.Id = nextId++;
        Coffees.Add(coffee);
    }
    public static void Delete(int id)
    {
        var coffee = Get(id);
        if (coffee is null)
        {
            return;
        }
        Coffees.Remove(coffee);
    }
    public static void Update(Coffee coffee)
    {
        var index = Coffees.FindIndex(p => p.Id == coffee.Id);
        if(index == -1)
          return;
        
        Coffees[index] = coffee;


    }
}