interface Population
{
}

class PositionedPopulation : Population
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

    public void ShowAll(Island TheWorld)
    {
        _people.ForEach(delegate(CovidPerson person)
        {
            person.Show(TheWorld);
        });
    }
    public void MovePeople(Island TheWorld)
    {
        Random randomizer = new Random();

        _people.ForEach(delegate(CovidPerson person)
        {
            //person.Move(TheWorld, randomizer.Next(-1,2), randomizer.Next(-1,2));
            person.HideMoveShow(TheWorld, randomizer.Next(-1,2), randomizer.Next(-1,2));
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

    public void Contiminate(Virus TheVirus) 
    {
        _people.ForEach(delegate(CovidPerson person)
        {
            _people.ForEach(delegate(CovidPerson otherPerson) {
                TheVirus.Contiminate(ref person, ref otherPerson);
            });
        });
    }
  

}