public interface Island
{
    void Show();
    void ShowHeader();

    void DrawElement(Point Location, Object Value);
    void DrawElement(Point Location, Object Value, ConsoleColor color);
    bool IsPointInside(int x, int y);
    void PopulateWithRandomPositionedPersons(int TheNumberOfPeople);
    public CovidPerson GetRandomPerson();
    public void NewDay();
    public void MovePeople();

    public void Contiminate(Virus TheVirus);

}

class SquaredIsland : ConsoleCanvas, Island
{
    private PositionedPopulation _islandPopulation;
    private Random _randomizer;

    private int _dayNo;
    private Virus _virus;

    public SquaredIsland(Virus TheVirus) : base() 
    {   
        _islandPopulation = new PositionedPopulation();
        _randomizer = new Random();
        _virus = TheVirus;
    }

    Point getRandomLocation()
    {
        return new Point(_randomizer.Next(1, Width), _randomizer.Next(1, Height));
    }

    bool isPersonOnThisPosition(Point ThePosition)
    {
        return _islandPopulation.IsPersonOnThisPosition(ThePosition);
    }

    public void PopulateWithRandomPositionedPersons(int TheNumberOfPeople)
    {
        for (int i=0; i < TheNumberOfPeople; i++)
        {
            Point randomPosition;
            do {
                randomPosition = getRandomLocation();
            } while(isPersonOnThisPosition(randomPosition));
            CovidPerson candidate = new CovidPerson(randomPosition);
            _islandPopulation.Add(candidate);
        }
    }

    public CovidPerson GetRandomPerson()
    {
        return _islandPopulation.GetPerson(_randomizer.Next(0,_islandPopulation.Count()-1));
    }

    public void NewDay() 
    {
        _dayNo++;
    }

    public void MovePeople()
    {
        _islandPopulation.MovePeople(this);
    }

    public void ShowHeader() {
        DrawElement(new Point(2,0), " Squared Island World. Date: "+_dayNo+" Population size: "+_islandPopulation.Count()+" ");
    }

    public void Show()
    {
        Console.Clear();
        DrawMaxFrame();
        ShowHeader();
        _islandPopulation.ShowAll(this);
    }

    public bool IsPointInside(int x, int y)
    {
        return (x>0 && x<Width && y>0 && y<Height);
    }

    public void Contiminate(Virus TheVirus) {
        _islandPopulation.Contiminate(TheVirus);
    }


}