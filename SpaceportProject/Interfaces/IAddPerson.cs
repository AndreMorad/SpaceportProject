namespace SpaceportProject
{
    public interface IAddPerson : IAddStarship
    {
        IAddPerson AddNameToPerson(string name);

        IAddPerson AddFunds();
    }
}