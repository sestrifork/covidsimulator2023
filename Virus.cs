public class Virus
{
    private int _radius;
    public Virus(int TheRadius) {
        _radius = TheRadius;
    }

    public void Contiminate(ref CovidPerson TheFirstPerson, ref CovidPerson TheSecondPerson)
    {
        // Check if one of the two persons is sick
        if ((TheFirstPerson.IsSick() && !TheSecondPerson.IsSick()) ||
            (!TheFirstPerson.IsSick() && TheSecondPerson.IsSick())) 
        {
            if (TheFirstPerson.DistanceTo(TheSecondPerson) < _radius) {
                // Tekninsk gæld!
                TheFirstPerson.GetSick();
                TheSecondPerson.GetSick();
            }
        }
    }
}