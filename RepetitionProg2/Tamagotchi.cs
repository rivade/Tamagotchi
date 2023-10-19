using System.Reflection;

public class Tamagotchi
{
    public string name;
    private Random generator = new();
    private List<string> words = new();
    public Action[] methods;
    private int hunger = 0;
    private int boredom = 0;

    public void Feed()
    {
        if (hunger <= 0)
        {
            System.Console.WriteLine($"{name} is already full!");
            Console.ReadLine();
        }
        else
        {
            hunger -= generator.Next(1, 3);
            System.Console.WriteLine($"You fed {name}!");
            if (hunger < 0)
            {
                hunger = 0;
            }
            Console.ReadLine();
        }
    }

    public void Hi()
    {
        if (words.Count != 0)
        {
            Console.WriteLine($"{name}: {words[generator.Next(words.Count)]}");
            ReduceBoredom(1);
            Console.ReadLine();
        }
        else
        {
            System.Console.WriteLine($"You need to teach {name} words first!");
            Console.ReadLine();
        }
    }

    public void Tick()
    {
        hunger += 1;
        boredom += 1;
    }

    public void PrintStats()
    {
        System.Console.WriteLine($"Hunger: {hunger}, Boredom: {boredom}");
        Console.ReadLine();
    }

    public bool GetAlive()
    {
        return hunger < 10 && boredom < 10;
    }

    private void ReduceBoredom(int reduceAmount)
    {
        boredom -= reduceAmount;
        if (boredom < 0)
        {
            boredom = 0;
        }
    }

    public void Teach(string word)
    {
        while (word.Length == 0)
        {
            System.Console.WriteLine("You need to write a word");
            System.Console.WriteLine("Write the word you want to teach your tamagotchi:");
            word = Console.ReadLine();
        }
        words.Add(word);
        ReduceBoredom(1);
    }




    public void Draw()
    {
        System.Console.WriteLine(@"  .^._.^.
  | . . |
 (  ---  )
 .'     '.
 |/     \|
  \ /-\ /
   V   V
   ");
        System.Console.WriteLine($@"{name}
        ");
        System.Console.WriteLine("Select Action:");
        System.Console.WriteLine("[1] Feed [2] Talk [3] Print Stats [4] Teach Word");
    }

    public void Actions()
    {
        string answerStr = Console.ReadLine();
        bool success = int.TryParse(answerStr, out int answer);
        while (!success || answer < 1 || answer > 5)
        {
            System.Console.WriteLine("You need to chose a number between 1-4");
            answerStr = Console.ReadLine();
            success = int.TryParse(answerStr, out answer);
        }
        if (answer < 4)
        {
            methods[(answer - 1)]();
        }
        else
        {
            System.Console.WriteLine("Write the word you want to teach your tamagotchi:");
            Teach(Console.ReadLine());
        }
    }

    public Tamagotchi(string inName)
    {
        name = inName;
        methods = new Action[] { Feed, Hi, PrintStats };
    }
}