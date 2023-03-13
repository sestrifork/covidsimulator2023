public record Point(int X, int Y);

public class ConsoleCanvas
{
    public int Height;
    public int Width;

    public ConsoleCanvas()
    {
        Console.Clear();
        Height = Console.WindowHeight-2;
        Width = Console.WindowWidth-2;
    }

    public void Rect(Point Location, int Width, int Height, ConsoleColor BorderColor)
    {
        Console.ForegroundColor = BorderColor;

        string s = "╔";
        string temp = "";
        for (int i = 0; i < Width; i++)
            s += "═";

        s += "╗" + "\n";
        
        Console.CursorTop = Location.Y;
        Console.CursorLeft = Location.X;
        Console.Write(s);

        for (int i = 0; i < Height; i++) {
            Console.CursorTop = Location.Y + 1 + i;
            Console.CursorLeft = Location.X;
            Console.WriteLine("║");
            Console.CursorTop = Location.Y + 1 + i;
            Console.CursorLeft = Location.X + Width+1;
            Console.WriteLine("║");
        }
           

        s = temp + "╚";
        for (int i = 0; i < Width; i++)
            s += "═";

        s += "╝" + "\n";

        
        Console.CursorTop = Location.Y+Height;
        Console.CursorLeft = Location.X;
        Console.Write(s);
        Console.ResetColor();
    }

    public void DrawMaxFrame()
    {
        Rect(new Point(0, 0), Console.WindowWidth-2, Console.WindowHeight-2, ConsoleColor.White);
    }

    public void DrawElement(Point Location, Object Value) {
        Console.CursorTop = Location.Y;
        Console.CursorLeft = Location.X;
        Console.WriteLine(Value.ToString());
    }
    
    public void DrawElement(Point Location, Object Value, ConsoleColor BorderColor) {
        Console.ForegroundColor = BorderColor;
        DrawElement(Location, Value);
        Console.ResetColor();
    }

// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public void UnitTest() {
        DrawMaxFrame();
        DrawElement(new Point(1,1), "Upper left corner");

        var text = "Lower left corner";
        DrawElement(new Point(Width-text.Length+1, Height-1), text);

        DrawElement(new Point(Width/2-7, Height/2), "<Hit any key>");
        Console.ReadKey();
        DrawElement(new Point(Width/2-7, Height/2), "             ");
        
        Random rnd = new Random();
        ConsoleColor color;
        for (int j = 0; j < 100; j++)
        {
            if (j%2 == 0) {
                color = ConsoleColor.DarkRed;
            } else {
                color = ConsoleColor.Green;
            }
            DrawElement(
                new Point(1 + rnd.Next(Width-1), 1 + rnd.Next(Height-1)), 
                'O', color);
        }

        Console.ReadKey();
    }

    public void PrintHeart(int size) {
        int n = size;
        for (int y = -n; y <= 2 * n; y++) {
            for (int x = -2 * n; x <= 2 * n; x++)
                if ((y <= 0 &&
                    ((int) Math.Sqrt((x+n)*(x+n) + y*y) <= n
                        || (int) Math.Sqrt((x-n)*(x-n) + y*y) <= n))
                    || (y > 0 && Math.Abs(x) <= 2 * n - y))
                    Console.Write("\u2665 ");
                else
                    Console.Write("\u2661 ");
            Console.Write("\n");
        }
    }
}
