using System;
using System.Collections.Generic;
using System.Linq;


public class LivingOrganism
{
    public double Energy { get; set; }
    public int Age { get; set; }
    public double Size { get; set; }

    public LivingOrganism(double energy, int age, double size)
    {
        Energy = energy;
        Age = age;
        Size = size;
    }

    public virtual void Move()
    {
        Console.WriteLine("The organism is moving.");
    }
}


public class Animal : LivingOrganism, IReproducible, IPredator
{
    public Animal(double energy, int age, double size, string species)
        : base(energy, age, size)
    {
        Species = species;
    }

    public string Species { get; set; }

    public override void Move()
    {
        Console.WriteLine($"{Species} is moving faster.");
    }

    public void Reproduce()
    {
        Console.WriteLine($"{Species} reproduced.");
    }

    public void Hunt()
    {
        Console.WriteLine($"{Species} is hunting.");
    }
}

public class Plant : LivingOrganism, IReproducible
{
    public Plant(double energy, int age, double size, string species)
        : base(energy, age, size)
    {
        Species = species;
    }

    public string Species { get; set; }

    public void Reproduce()
    {
        Console.WriteLine($"{Species} reproduced.");
    }
}

public class Microorganism : LivingOrganism, IReproducible
{
    public Microorganism(double energy, int age, double size, string species)
        : base(energy, age, size)
    {
        Species = species;
    }

    public string Species { get; set; }

    public void Reproduce()
    {
        Console.WriteLine($"{Species} reproduced.");
    }
}


public interface IReproducible
{
    void Reproduce();
}

public interface IPredator
{
    void Hunt();
}


public class Ecosystem
{
    private List<LivingOrganism> organisms;

    public Ecosystem()
    {
        organisms = new List<LivingOrganism>();
    }

    public void AddOrganism(LivingOrganism organism)
    {
        organisms.Add(organism);
    }

    public void SimulateInteraction()
    {
        foreach (var organism in organisms)
        {
            organism.Move();
            if (organism is IReproducible)
            {
                (organism as IReproducible).Reproduce();
            }

            if (organism is IPredator)
            {
                (organism as IPredator).Hunt();
            }
        }
    }

    public void ResourceCompetition()
    {
        var largeAnimals = organisms.OfType<Animal>().Where(a => a.Size > 2);
        var smallAnimals = organisms.OfType<Animal>().Where(a => a.Size <= 2);
        foreach (var smallAnimal in smallAnimals)
        {
            var competitors = largeAnimals.Where(a => Math.Abs(a.Age - smallAnimal.Age) <= 2);
            if (competitors.Any())
            {
                Console.WriteLine($"{smallAnimal.Species} is competing with larger animals.");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Animal lion = new Animal(100, 5, 2, "Lion");
        Plant tree = new Plant(50, 10, 5, "Oak");
        Microorganism bacteria = new Microorganism(10, 1, 0.1, "Bacteria");

        Ecosystem ecosystem = new Ecosystem();
        ecosystem.AddOrganism(lion);
        ecosystem.AddOrganism(tree);
        ecosystem.AddOrganism(bacteria);

        ecosystem.SimulateInteraction();
        ecosystem.ResourceCompetition();

        Console.ReadLine();
    }
}

