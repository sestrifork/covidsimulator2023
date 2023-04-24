class PositionedPopulation
{   
    private List<CovidPerson> _people;

    public PositionedPopulation()
    {
        _people = new List<CovidPerson>();
    }

    public void Add(CovidPerson ThePerson)
    {
        _people.Add(ThePerson);
    }

    public CovidPerson GetPerson(int index)
    {
        return _people[index];
    }

    public int Count() {
        return _people.Count();
    }

    public void ShowAll(SquaredIsland TheWorld)
    {
        _people.ForEach(delegate(CovidPerson person)
        {
            person.Show(TheWorld);
        });
    }

    public void MovePeople(SquaredIsland TheWorld)
    {
        Random randomizer = new Random();

        _people.ForEach(delegate(CovidPerson person)
        {
            int rndint = randomizer.Next(0, 100);

            if (rndint < 90) {
                person.HideMoveShow(TheWorld, randomizer.Next(-1, 2), randomizer.Next(-1, 2));
            }
            else if (rndint < 97) {
                person.HideMoveShow(TheWorld, randomizer.Next(-75, 76), randomizer.Next(-75, 76));
            }
            else {
                person.HideMoveShow(TheWorld, randomizer.Next(-150, 151), randomizer.Next(-150, 151));
            }
        });
    }

    public bool IsPersonOnThisPosition(Point ThePoint) 
    {
        bool isOverlapping = false;
        _people.ForEach(delegate(CovidPerson person)
        {
            if (person.IsPersonOnThisPoint(ThePoint)) {
                isOverlapping = true;
            }
        });
        return isOverlapping;
    }

    public void Contaminate(Virus TheVirus) 
    {
        _people.ForEach(delegate(CovidPerson person)
        {
            _people.ForEach(delegate(CovidPerson otherPerson) {
                TheVirus.Contaminate(ref person, ref otherPerson);
            });
        });
    }

}
