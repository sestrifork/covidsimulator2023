internal class Program
{
    private static void Main(string[] args)
    {

        Virus Covid19 = new Virus(4);        
        Island MyWorld = new SquaredIsland(Covid19);

        MyWorld.PopulateWithRandomPositionedPersons(200);
        MyWorld.Show();

        Console.ReadKey();

        MyWorld.GetRandomPerson().GetSick();


        ConsoleKeyInfo pressedKey ;
        
        void dostuff() {
            MyWorld.NewDay();
            MyWorld.MovePeople();
            MyWorld.Contiminate(Covid19);
            MyWorld.ShowHeader();
        }

        do {
            dostuff();
            pressedKey = Console.ReadKey();
            while (pressedKey.Key == ConsoleKey.A) {
                Thread.Sleep(500);
                dostuff();
                if (Console.KeyAvailable) {
                    pressedKey = Console.ReadKey();
                }
            }
        } while (pressedKey.Key != ConsoleKey.Escape);
    }
}