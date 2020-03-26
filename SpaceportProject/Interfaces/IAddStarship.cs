namespace SpaceportProject
{
    public interface IAddStarship
    {
        IAddStarship StarshipControl(string shipName);

        IAddStarship Charge();

        IAddStarship AddToDataBase();
    }
}