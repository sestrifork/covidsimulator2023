internal class Program
{
    private static void Main(string[] args)
    {
        SquaredIsland MyWorld ;
        MyWorld = new SquaredIsland();
        MyWorld.Show();

        CovidPerson MyPerson;
        MyPerson = new CovidPerson();
        MyPerson.Show(MyWorld, new Point(10,10));

        MyPerson.GetSick();
        MyPerson.Show(MyWorld, new Point(25,25));

        Console.ReadKey();
    }
}