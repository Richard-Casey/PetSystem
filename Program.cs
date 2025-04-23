using System;
using System.Collections.Generic;

// An interface is like a promise or a contract. What we are saying here is that any class that implements this IFeedable
// interface must also define a Feed() method.
interface IFeedable
{
    void Feed();
}

// This is defines an abstract class, in this case a general household pet. It implements IFeedable so therefore
// somewhere it must also provide a Feed().method within its inheritance chain.
abstract class Pet : IFeedable
{
    // A common property for all pets - their name
    public string Name { get; set; }

    // This is the constructor. A constructor has the same name as the class and sets up the object
    // when it's created – in this case, assigning the pet's name.
    public Pet(string name)
    {
        Name = name;
    }

    // This is an abstract method, meaning any class that inherits from Pet must implement its own version of Speak().
    public abstract void Speak();

    // This is a concrete (default) implementation of Feed() from IFeedable.
    // All pets will use this method unless they choose to override it (which they can, but don’t have to).
    public void Feed() => Console.WriteLine($"{Name} has been fed.");
}

// Dog is a concrete class that inherits from Pet. Because Pet has an abstract Speak() method,
// Dog must implement it.
class Dog : Pet
{
    public Dog(string name) : base(name) { }

    // Implements the Speak() method specifically for dogs.
    public override void Speak() => Console.WriteLine($"{Name} says: Woof!");
}


// Another concrete class – this time representing a Cat.
// Like Dog, it must implement its own version of Speak().
class Cat : Pet
{
    public Cat(string name) : base(name) { }

    // Implements Speak() specifically for cats.
    public override void Speak() => Console.WriteLine($"{Name} says: Meow!");
}


// This is the entry point of the application – the program starts running from here.
class Program
{
    static void Main(string[] args)
    {
        // Create a list of pets using polymorphism – both Dog and Cat are treated as type Pet.
        // Each one is given a name on creation.
        List<Pet> pets = new List<Pet>
        {
            new Dog("Fido"),
            new Cat("Jasper")
        };

        // Loop through each pet and call their Speak() and Feed() methods.
        foreach (var pet in pets)
        {
            pet.Speak(); // Calls the overridden Speak() method for Dog or Cat.
            pet.Feed(); // Calls the shared Feed() method from Pet.
            Console.WriteLine(); // Adds spacing between each pet’s output.
        }
    }
}