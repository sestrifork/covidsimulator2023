using System;
using static System.Net.Mime.MediaTypeNames;

public interface IIsland
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

    public void Contaminate(Virus TheVirus);

}

public class SquaredIsland : ConsoleCanvas, IIsland
{
    private PositionedPopulation _islandPopulation;
    private Random _randomizer;
    private Virus _virus;

    public int _dayNo;
    public int _peopleInfected;
    private int _peopleImmune;

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
        for (int i = 0; i < TheNumberOfPeople; i++)
        {
            Point randomPosition;
            do {
                randomPosition = getRandomLocation();
            } while (isPersonOnThisPosition(randomPosition));

            CovidPerson candidate;
            int rndint = _randomizer.Next(0, 100);
            if (rndint < 45) {
                candidate = new CovidPerson(randomPosition, CovidPerson.Gender.Male);
            }
            else if (rndint < 90) {
                candidate = new CovidPerson(randomPosition, CovidPerson.Gender.Female);
            }
            else {
                candidate = new CovidPerson(randomPosition, CovidPerson.Gender.GenderNeutral);
            }
            _islandPopulation.Add(candidate);
        }
    }

    public CovidPerson GetRandomPerson()
    {
        return _islandPopulation.GetPerson(_randomizer.Next(0, _islandPopulation.Count() - 1));
    }

    public void NewDay()
    {
        _dayNo++;
        GetHealthyImunAfterSick();
        PeopleInfected();
        PeopleImmune();
    }

    public void MovePeople()
    {
        _islandPopulation.MovePeople(this);
    }

    public void ShowHeader() {
        DrawElement(new Point(2, 0), $" Thomas Al-Suliman - Squared Island World. Date: {_dayNo}. ");
        DrawElement(new Point(2, Console.WindowHeight - 2),
            $" Population size: {_islandPopulation.Count()}." +
            $" People infected: {_peopleInfected}." +
            $" People immune: {_peopleImmune}. ");
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
        return (x > 0 && x < Width && y > 0 && y < Height);
    }

    public void Contaminate(Virus TheVirus)
    {
        _islandPopulation.Contaminate(TheVirus);
    }

    public void CreateChildren()
    {
        for (int i = 0; i < _islandPopulation.Count(); i++)
        {
            CovidPerson parent1 = _islandPopulation.GetPerson(i);
            for (int j = i + 1; j < _islandPopulation.Count(); j++)
            {
                CovidPerson parent2 = _islandPopulation.GetPerson(j);
                CreateChildIfPossible(parent1, parent2);
            }
        }
    }
    private void CreateChildIfPossible(CovidPerson parent1, CovidPerson parent2)
    {
        if (parent1.IsMale() && parent2.IsFemale() ||
            parent1.IsFemale() && parent2.IsMale())
        {
            if (parent1.DistanceTo(parent2) == 0)
            {
                int rnd = _randomizer.Next(0, 5);
                if (rnd < 2) {
                    Point childLocation = new Point(_randomizer.Next(parent1.GetLocation().X, parent2.GetLocation().X), _randomizer.Next(parent1.GetLocation().Y, parent2.GetLocation().Y));
                    CovidPerson child = new CovidPerson(childLocation, CovidPerson.Gender.Child);
                    _islandPopulation.Add(child);
                }
                
            }
        }
    }

    private void PeopleInfected()
    {
        _peopleInfected = 0;
        for (int i = 0; i < _islandPopulation.Count(); i++)
        {
            CovidPerson person = _islandPopulation.GetPerson(i);
            if (person.IsSick())
            {
                _peopleInfected++;
            }
        }
    }
    private void PeopleImmune()
    {
        _peopleImmune = 0;
        for (int i = 0; i < _islandPopulation.Count(); i++)
        {
            CovidPerson person = _islandPopulation.GetPerson(i);
            if (person.IsImmune())
            {
                _peopleImmune++;
            }
        }
    }

    public void GetHealthyImunAfterSick()
    {
        for (int i = 0; i < _islandPopulation.Count(); i++)
        {
            CovidPerson person = _islandPopulation.GetPerson(i);
            if (person.IsSick())
            {
                if (person.DaysSick() == 20) {
                    person.GetHealthyImun();
                }
                else {
                    person.IncrementDaysSick();
                }
            }
        }
    }

    public int PopulationCount()
    {
        return _islandPopulation.Count();
    }
}


