interface IPerson {
    void Show(SquaredIsland TheIsland);
}

public class CovidPerson : IPerson
{
    private int _daysSick;

    enum Situation {
        Healthy,
        Sick,
        HealthyImun,
        VacinatedImun
    }
    private Situation _covidStatus;

    public enum Gender
    {
        Male,
        Female,
        GenderNeutral,
        Child
    }
    private Gender _sex;

    Point _location;
    public CovidPerson(Point TheLocation, Gender TheSex) {
        _covidStatus = CovidPerson.Situation.Healthy;
        _location = TheLocation;
        _sex = TheSex;
        _daysSick = 0;
    }

    public void GetSick() => _covidStatus = CovidPerson.Situation.Sick;
    public void GetHealthyImun() => _covidStatus = CovidPerson.Situation.HealthyImun;

    public bool IsSick() {
        return _covidStatus == CovidPerson.Situation.Sick;
    }
    public bool IsHealthy() {
        return _covidStatus == CovidPerson.Situation.Healthy;
    }
    public bool IsImmune()
    {
        return _covidStatus == CovidPerson.Situation.HealthyImun || _covidStatus == CovidPerson.Situation.VacinatedImun;
    }

    public int DaysSick() {
        return _daysSick;
    }
    public void IncrementDaysSick() {
        _daysSick++;
    }

    public bool IsMale() {
        return _sex == CovidPerson.Gender.Male;
    }
    public bool IsFemale() {
        return _sex == CovidPerson.Gender.Female;
    }

    public void Move(SquaredIsland TheIsland, int movex, int movey)
    {
        _location.X += movex;
        _location.Y += movey;
    }

    public void HideMoveShow(SquaredIsland TheIsland, int movex, int movey)
    {
        if (TheIsland.IsPointInside(_location.X + movex, _location.Y + movey)) {
            TheIsland.DrawElement(_location, " ");
            Move(TheIsland, movex, movey);
            Show(TheIsland);
            TheIsland.ShowHeader();
        }
    }

    public void Show(SquaredIsland TheIsland)
    {
        ConsoleColor theColor;
        switch (_covidStatus)
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
        switch (_sex)
        {
            case CovidPerson.Gender.Male: return "\u2642";
            case CovidPerson.Gender.Female: return "\u2640";
            case CovidPerson.Gender.GenderNeutral: return "n";
            case CovidPerson.Gender.Child: return "c";
            default: return "#";
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
        return Math.Sqrt(Math.Pow(Math.Abs(_location.X - ThePerson.GetLocation().X), 2) + Math.Pow(Math.Abs(_location.Y - ThePerson.GetLocation().Y), 2));
    }

}