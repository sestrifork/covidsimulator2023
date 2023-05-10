class ChartElement
{
    public int X { set; get; }
    public int Value { set; get; }
    public ConsoleColor Color { set; get; }

    public ChartElement(int TheX, int TheValue, ConsoleColor TheColor)
    {
        X = TheX;
        Value = TheValue;
        Color = TheColor;
    }
}

class ConsoleChart : ConsoleCanvas
{
    List<ChartElement> chartElements;
    int startIndex;

    public ConsoleChart() : base()
    {
        chartElements = new List<ChartElement>();
        startIndex = 0;
    }

    public void Add(ChartElement TheElement)
    {
        chartElements.Add(TheElement);
    }
    public void Add(int TheX, int TheValue, ConsoleColor TheColor)
    {
        Add(new ChartElement(TheX, TheValue, TheColor));
    }

    public void Show()
    {
        Show(startIndex);
    }
    public void Show(int startIndex)
    {
        int endIndex = Math.Min(startIndex + Width / 4, chartElements.Count);

        for (int i = startIndex; i < endIndex; i++)
        {
            ChartElement element = chartElements[i];
            Rect(new Point(element.X - (startIndex * 4), Height - element.Value - 1), 1, element.Value, element.Color);
        }
    }

    public void MoveChart(ConsoleKey arrowKey)
    {
        if (arrowKey == ConsoleKey.RightArrow)
        {
            startIndex = Math.Min(startIndex + 1, chartElements.Count - 1);
        }
        else if (arrowKey == ConsoleKey.LeftArrow)
        {
            startIndex = Math.Max(startIndex - 1, 0);
        }
        ClearChartArea();
        Show();
    }

    public void ClearChartArea()
    {
        int originalCursorLeft = Console.CursorLeft;
        int originalCursorTop = Console.CursorTop;

        for (int y = 1; y < Height; y++)
        {
            for (int x = 1; x < Width + 1; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
            }
        }

        Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
    }

}