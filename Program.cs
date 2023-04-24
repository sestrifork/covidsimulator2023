class Program
{
    private static void Main(string[] args)
    {

        Virus Covid19 = new Virus(4);
        SquaredIsland MyWorld = new SquaredIsland(Covid19);

        int desiredPopulationSize = args.Length == 1 ? Convert.ToInt32(args[0]) : 100;
        MyWorld.PopulateWithRandomPositionedPersons(desiredPopulationSize);
        MyWorld.Show();

        Console.ReadKey();
        
        MyWorld.GetRandomPerson().GetSick();

        void NextDay() {
            MyWorld.NewDay();
            MyWorld.CreateChildren();
            MyWorld.MovePeople();
            MyWorld.Contaminate(Covid19);
            MyWorld.ShowHeader();
        }

        ConsoleKeyInfo pressedKey;
        do
        {
            NextDay();
            pressedKey = Console.ReadKey();
            while (pressedKey.Key == ConsoleKey.A) {
                Thread.Sleep(150);
                NextDay();
                if (Console.KeyAvailable) {
                    pressedKey = Console.ReadKey();
                }
            }
        } while (pressedKey.Key != ConsoleKey.Escape);


    }
}
// Thomas
