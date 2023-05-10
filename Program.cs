class Program
{
    private static void Main(string[] args)
    {
        ConsoleChart chart = new ConsoleChart();

        Virus Covid19 = new Virus(4);
        SquaredIsland MyWorld = new SquaredIsland(Covid19);

        int desiredPopulationSize = args.Length == 1 ? Convert.ToInt32(args[0]) : 100;
        MyWorld.PopulateWithRandomPositionedPersons(desiredPopulationSize);

        MyWorld.Show();

        MyWorld.GetRandomPerson().GetSick();


        int value = 0;
        int preValue = 0;
        int TheX = 2;
        ConsoleColor color = ConsoleColor.Yellow;
        chart.Add(TheX, value, color);
        int maxHeight = chart.Height - 1;

        bool wasArrowKeyOrC = false;
        ConsoleKeyInfo pressedKey;
        do
        {
            pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.LeftArrow || pressedKey.Key == ConsoleKey.RightArrow)
            {
                chart.MoveChart(pressedKey.Key);
                wasArrowKeyOrC = true;

            }
            else if (pressedKey.Key == ConsoleKey.C)
            {
                NextDay(); // Kan fjernes, men så kan man kun fortsætte simuleringen ved at trykke på en anden knap og gå tilbage til visning af personer
                UpdateChart(); // Kan fjernes, men så kan man kun fortsætte simuleringen ved at trykke på en anden knap og gå tilbage til visning af personer
                chart.ClearChartArea();
                chart.Show();
                wasArrowKeyOrC = true;
            }
            else
            {
                if (wasArrowKeyOrC)
                {
                    chart.ClearChartArea();
                    wasArrowKeyOrC = false;
                }

                NextDay();
                UpdateChart();
            }
            
            while (pressedKey.Key == ConsoleKey.A)
            {
                Thread.Sleep(150);
                NextDay();
                UpdateChart();
                if (Console.KeyAvailable)
                {
                    pressedKey = Console.ReadKey();
                }
            }
        } while (pressedKey.Key != ConsoleKey.Escape);

        void NextDay()
        {
            MyWorld.NewDay();
            MyWorld.CreateChildren();
            MyWorld.MovePeople();
            MyWorld.Contaminate(Covid19);
        }
        void UpdateChart()
        { 
            TheX += 4;
 
            preValue = value;
            value = MyWorld._peopleInfected;

            if (value > preValue)
            {
                color = ConsoleColor.Red;
            }
            else if (value == preValue)
            {
                color = ConsoleColor.Cyan;
            }
            else
            {
                color = ConsoleColor.Green;
            }

            double scalingFactor = (double)maxHeight / MyWorld.PopulationCount();
            int scaledValue = (int)(value * scalingFactor);

            chart.Add(TheX, scaledValue, color);
        }
    }
}
// Thomas Final Version
/* MAN KUNNE SELVFØLGELIG LAVE EN SWITCH, 
 * HVOR FORSKELLIGE KNAPPER GJORDE OG VISTE NOGET FORSKELLIGT, 
 * SÅ DET BLIVER MERE BRUGERVENLIGT OG STRUKTURERET, 
 * MEN GRUNDLÆGGENDE FUNKTIONALITET ER OPNÅET */

// Ekstra tilføjelser (ikke implementeret) til overvejelse:
// -- Ændre måden scaledValue udregnes på, så man får vist dataet på en anden måde
// -- Hvis value == 0 så ændres farven -- ifhm. lave if til switch
