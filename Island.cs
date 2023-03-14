interface Island
{
    void Show();
    void DrawElement(Point Location, Object Value);
    void DrawElement(Point Location, Object Value, ConsoleColor color);
    
}

class SquaredIsland : ConsoleCanvas, Island
{
    SmallPopulation IslandPopulation;

    public SquaredIsland() : base() 
    {   
        IslandPopulation = new SmallPopulation(); 
    }

    /*hej hej, pls virk github*/

    public void Show()
    {
        DrawMaxFrame();
        DrawElement(new Point(1,1), "Squared Island World. Population size:"+IslandPopulation.Size);
    }
}