interface Population
{
    public int Size { get; }
    //public void AddPerson(Person ThePerson);
}

class SmallPopulation : Population
{
    public int Size {
        get => 0;
    }
}