interface Person {
    void Show(Island TheIsland, Point TheLocation);
}

class CovidPerson : Person
{
    static int heads = 1;

    enum Situation {
        Healthy,
        Sick,
        HealthyImun,
        VacinatedImun
    }

    private Situation covidStatus;

    public CovidPerson() {
        covidStatus = CovidPerson.Situation.Healthy;
    }
    
    public void GetSick(){
        covidStatus = CovidPerson.Situation.Sick;
    }
    public void Show(Island TheIsland, Point TheLocation) {
        ConsoleColor theColor;
        switch(covidStatus) 
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
        TheIsland.DrawElement(TheLocation, this, theColor);
    }

    public override String ToString()
    {
        return "#";
    }
} 