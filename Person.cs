interface Person {
    void Show(Island TheIsland);
}

public class CovidPerson : Person
{
    enum Situation {
        Healthy,
        Sick,
        HealthyImun,
        VacinatedImun
    }
    private Situation _covidStatus;

    Point _location;
    public CovidPerson(Point TheLocation) {
        _covidStatus = CovidPerson.Situation.Healthy;
        _location = TheLocation;
    }

    public CovidPerson() : this(new Point(1,1)) {}
    
    public void GetSick() => _covidStatus = CovidPerson.Situation.Sick;
    
    public bool IsSick() {
        return _covidStatus == CovidPerson.Situation.Sick;
    }

    public void Move(Island TheIsland, int movex, int movey)
    {
           _location.X += movex;
           _location.Y += movey;
    }

    public void HideMoveShow(Island TheIsland, int movex, int movey)
    {
        if (TheIsland.IsPointInside(_location.X+movex, _location.Y+movey)) { 
            TheIsland.DrawElement(_location, " ");
            Move(TheIsland, movex, movey);
            Show(TheIsland);
            TheIsland.ShowHeader();
        }
    }


    public void Show(Island TheIsland) 
    {
        ConsoleColor theColor;
        switch(_covidStatus) 
        {
            case CovidPerson.Situation.Healthy:
                theColor = ConsoleColor.Green;
            break;
            case CovidPerson.Situation.Sick:
                theColor = ConsoleColor.DarkRed;
            break;
            default:
                theColor = ConsoleColor.White;
            break;
        }
        TheIsland.DrawElement(_location, this, theColor);
    }

    public override String ToString()
    {
        switch(_covidStatus) 
        {
            case CovidPerson.Situation.Healthy:     return "o";
            case CovidPerson.Situation.Sick:        return "x";
            default:                                return "#";
        }        
    }
    public bool IsPersonOnThisPoint(Point ThePoint)
    {
        return (_location.X == ThePoint.X && _location.Y == ThePoint.Y);
    }
    public Point GetLocation() {
        return _location;
    }

    public double DistanceTo(CovidPerson ThePerson) {
        //Teknisk gæld
        return Math.Sqrt(Math.Pow(Math.Abs(_location.X-ThePerson.GetLocation().X),2) + Math.Pow(Math.Abs(_location.Y-ThePerson.GetLocation().Y),2));
    }
}