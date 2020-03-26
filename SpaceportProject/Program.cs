using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SpaceportProject
{
    public class Program : MainMenu
    {
        public static void Main(string[] args)
        {
            AccessControl();
            Menu();
        }

        public void login()
        {
            // kollar om det finns ledig parkering
            ControlParkingspace();

            // Kollar om personen finns i API
            AccessControl();

            // kollar om skeppet finns i API
            //StarshipControl();

            //// lägg till pengar i ditt konto
            //AddFunds();

            //// hur lännge du vill parkera
            //Charge();

            //// lägger till i databasen
            //AddToDataBase();

            // skapar eller kollar om
        }
    }
}