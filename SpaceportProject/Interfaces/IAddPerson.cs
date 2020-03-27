namespace SpaceportProject
{
    public interface IAddPerson : IConfigDatabase
    {
        IAddPerson AddNameToPerson(string name);

        IAddPerson AddFunds();
    }
}