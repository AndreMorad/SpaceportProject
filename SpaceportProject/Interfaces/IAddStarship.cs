namespace SpaceportProject
{
    public interface IAddStarship : IConfigDatabase
    {
        IAddStarship StarshipControl();

        IAddStarship Charge();
    }
}