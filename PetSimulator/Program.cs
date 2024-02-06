using System;

class VirtualPet
{
    // Pet attributes
    private string petType;
    private string petName;
    private int hunger;
    private int happiness;
    private int health;

    // Constructor
    public VirtualPet(string type, string name)
    {
        petType = type;
        petName = name;
        hunger = 5;
        happiness = 5;
        health = 5;
    }

    // Display pet status
    public void displayPetStats()
    {
        Console.WriteLine($"\n{petName}'s Status : ");
        Console.WriteLine($"- Hunger: {hunger}");
        Console.WriteLine($"- Happiness: {happiness}");
        Console.WriteLine($"- Health: {health}");
    }

    // Feed the pet
    public void feed()
    {
        Console.WriteLine($"\nYou fed {petName}. His hunger decreases, and health improves slightly.");
        hunger = Math.Max(1, hunger - 2);
        happiness = Math.Min(10, happiness + 1);
        health = Math.Min(10, health + 1);
    }

    // Play with the pet
    public void play()
    {
        Console.WriteLine($"\nYou played with {petName}. His happiness increases, but he's bit hungrier.");
        happiness = Math.Min(10, happiness + 2);
        hunger = Math.Min(10, hunger + 1);
        health = Math.Max(1, health - 1);
    }

    // Rest the pet
    public void rest()
    {
        Console.WriteLine($"\n{petName} is resting. His health is increases, but he's happiness decreases slightly.");
        health = Math.Min(10, health + 2);
        happiness = Math.Max(1, happiness - 1);
    }

    // Time-based changes
    public void timePasses()
    {
        hunger = Math.Min(10, hunger + 1);
        happiness = Math.Max(1, happiness - 1);

        // Check for critical conditions
        if (hunger >= 8)
            Console.WriteLine($"\n{petName} is very hungry! Feed {petName} soon!");
        if (happiness <= 3)
            Console.WriteLine($"\n{petName} is unhappy! Play with {petName} to make it happy!");
        if (health <= 3)
            Console.WriteLine($"\n{petName}'s health is low! Consider letting {petName} rest!");
    }

    // Main method
    static void Main()
    {
        Console.WriteLine
          ("Please choose a type of pet : \n1.Cat \n2.Dog \n3.Rabbit\n ");
        Console.Write("User Input between 1-3: ");
        string petType = Console.ReadLine();

        // Decide type of pet
        switch (petType)
        {
            case "1":
                petType = "Cat";
                break;

            case "2":
                petType = "Dog";
                break;

            case "3":
                petType = "Rabbit";
                break;

            default:
                Console.WriteLine("Invalid choice!");
                Environment.Exit(0);
                break;
        }

        Console.Write($"\nYou've chosen a {petType}. What would you like to name your pet: ");
        string petName = Console.ReadLine();

        Console.WriteLine($"\nWelcome, {petName}! Let's take good care of your pet.");
        VirtualPet pet = new VirtualPet(petType, petName);

        while (true)
        {

            Console.WriteLine();
            Console.WriteLine("Main Menu:");
            Console.WriteLine($"1. Feed {petName}");
            Console.WriteLine($"2. Play with {petName}");
            Console.WriteLine($"3. Let {petName} Rest");
            Console.WriteLine($"4. Check {petName}'s Status");
            Console.WriteLine("5. Exit");

            Console.Write("\nUser Input : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    pet.feed();
                    break;

                case "2":
                    pet.play();
                    break;

                case "3":
                    pet.rest();
                    break;

                case "4":
                    pet.displayPetStats();
                    break;

                case "5":
                    Console.WriteLine($"Thank you for playing with {petName}. Goodbye!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine
                      ("\nInvalid choice. Please enter a number between 1 and 5.");
                    break;
            }

            // Simulate the passage of time
            pet.timePasses();
        }
    }
}
