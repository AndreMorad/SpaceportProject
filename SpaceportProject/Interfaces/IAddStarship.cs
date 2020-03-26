namespace SpaceportProject
{
    public interface IAddStarship
    {
        IAddStarship StarshipControl();

        IAddStarship Charge();

        IAddStarship AddToDataBase();
    }
}