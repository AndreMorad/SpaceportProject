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
                Console.WriteLine($"There is { (20 - availableSlots.Count)}");
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

                if (person.results.Count > 0)
                {
                    ControlPersonInDatabase(person.results[0].name);
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Access denied");
                }
            }
        }

        public static void ControlPersonInDatabase(string personName)
        {
            MyContext context = new MyContext();
            var personCheck = context.Persons.Where(p => p.Name == personName).FirstOrDefault();
            if (personCheck != null)
            {
                Console.WriteLine($"Welcome back {personName}");
                MainMenu.Menu(personCheck);
            }
            else
            {
                var newCustomer = new CreateNewCustomer().AddNameToPerson(personName).AddFunds().StarshipControl().Charge().AddToDataBase();
            }
        }
    }
}