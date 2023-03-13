internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("This is a Covid-19 simulator");
        SquaredIsland MyWorld ;
        MyWorld = new SquaredIsland();
        MyWorld.Show();

        CovidPerson MyPerson;
        MyPerson = new CovidPerson();
        MyPerson.Show(MyWorld, new Point(10,10));

        MyPerson.GetSick();
        MyPerson.Show(MyWorld, new Point(15,15));

        Console.ReadKey();
    }
}