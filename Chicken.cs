using System;

public interface IBird
{
    Egg Lay();
}

public class Chicken : IBird
{
    public Chicken()
    {
        Console.WriteLine("A chicken.");
    }
    public Egg Lay()
    {
        return new Egg(new Func<Chicken>(() => new Chicken()));
    }
}
public class Egg
{
    private readonly bool born = false;
    Func<IBird> create;
    public Egg(Func<IBird> createBird)
    {
        create = createBird;
    }

    public IBird Hatch()
    {
        bool born = false;
        if (!born)
        {
            Console.WriteLine("It's Alive!");
            born = true;
            return create();
        }
        else
        {
            Console.WriteLine("Egg already hatched");
        }

        return null;
    }
}
    public class Program
{
    public static void Main(string[] args)
    {
        var chicken1 = new Chicken();
        var egg = chicken1.Lay();
        var childChicken = egg.Hatch();
    }
}