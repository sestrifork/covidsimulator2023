public class Virus
{
    private int _radius;
    public Virus(int TheRadius) {
        _radius = TheRadius;
    }

    public void Contaminate(ref CovidPerson TheFirstPerson, ref CovidPerson TheSecondPerson)
    {
        if (TheFirstPerson.DistanceTo(TheSecondPerson) < _radius)
        {
            if (TheFirstPerson.IsSick() && TheSecondPerson.IsHealthy()) {
                TheSecondPerson.GetSick();
            }
            else if (TheFirstPerson.IsHealthy() && TheSecondPerson.IsSick()) {
                TheFirstPerson.GetSick();
            }
        }
    }

}