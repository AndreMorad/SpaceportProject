using System.Data;
using System.Linq;
using RestSharp;
using System;
using Newtonsoft.Json;

namespace SpaceportProject
{
    public class MenuDockStarship : MenuCheckOutStarship
    {
        public static void ControlParkingspace()
        {
            MyContext myContext = new MyContext();
            var availableSlots = myContext.Spaceships.Where(p => p.Payed == false).ToList();
            if (availableSlots.Count < 20)
            {
                //AccessControl();
                Console.WriteLine($"There is { availableSlots.Count}");
            }
            else
            {
                Console.WriteLine("No parkingslots are available for the moment, please come back later!");
            }
        }

        public static void AccessControl()
        {
            RestClient client = new RestClient("https://swapi.co/api/");
            bool loop = true;
            while (loop)
            {
                Console.Write("Please enter your name: ");
                var personRequest = new RestRequest($"people/?search={Console.ReadLine()}", DataFormat.Json);
                var personResponse = client.Execute(personRequest);
                var person = JsonConvert.DeserializeObject<JSONCharacterRoot>(personResponse.Content);

                Console.Write("Please validate your starship: ");
                var starshipRequest = new RestRequest($"starships/?search={Console.ReadLine()}", DataFormat.Json);
                var starshipResponse = client.Execute(starshipRequest);
                var starship = JsonConvert.DeserializeObject<JSONStarshipRoot>(starshipResponse.Content);

                if (person.results.Count > 0 && starship.results.Count > 0)
                {
                    ControlPersonInDatabase(person.results[0].name, starship.results[0].name);
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Access denied");
                }
                //if (starship.results.Count > 0)
                //{
                //    Console.WriteLine($"{starship.results[0].name} ready for parking");
                //    createStarship.ShipName = starship.results[0].name;
                //    createStarship.PricePerDay = 1000;
                //    loop = false;
                //}
                //else
                //{
                //    Console.WriteLine("Unauthorised spaceship");
                //}
            }
        }

        public static void ControlPersonInDatabase(string personName, string shipName)
        {
            MyContext context = new MyContext();
            var personCheck = context.Persons.Where(p => p.Name == personName).ToList();
            if (personCheck.Count > 0)
            {
                Console.WriteLine($"Welcome back {personName}");
                var newStarship = new CreateShip(personCheck[0]).StarshipControl(shipName).Charge().AddToDataBase();
            }
            else
            {
                var newCustomer = new CreateNewCustomer().AddNameToPerson(personName).AddFunds().StarshipControl(shipName).Charge().AddToDataBase();
            }
        }
    }
}