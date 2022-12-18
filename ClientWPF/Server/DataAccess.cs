using MongoDB.Driver;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class DataAccess
    {
       
        private string ConnectionString = "mongodb://127.0.0.1:27017";
        private string DataBaseName = "airlinesticketdb";
        private string UserCollection = "users";
        private string OrderCollection = "orders";
        private string PlaceCollection = "places";
        private string CityCollection = "cities";
        private string FlightCollection = "flights";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DataBaseName);
            return db.GetCollection<T>(collection);
        }

        public (User, string) Autorization(string login, string password)
        {
            var userCollection = ConnectToMongo<User>(UserCollection);
            var exist = userCollection.AsQueryable().FirstOrDefault(x => x.Email == login) != null;
            if (exist)
            {
                var userObject = userCollection.Find(x => x.Email == login).ToList();
                if (userObject[0].Password == password)
                {                   
                    return (userObject[0], "Success");
                }
                else
                {                   
                    return (new User(), "Неправильний пароль");
                }

            }
            else
            {
                Console.WriteLine("not!");
                return (new User(), "Користувача не існує!");
            }
        }

        #region Admin
        public List<User> GetAllUsers()
        {
            var userCollection = ConnectToMongo<User>(UserCollection);
            var result = userCollection.Find(_ => true);
            return result.ToList();
        }

        public List<Flight> GetAllFlights()
        {
            var flightCollection = ConnectToMongo<Flight>(FlightCollection);
            var result = flightCollection.Find(_ => true);
            return result.ToList();
        }

        public List<Order> GetAllOrders()
        {
            var orderCollection = ConnectToMongo<Order>(OrderCollection);
            var result = orderCollection.Find(_ => true);
            return result.ToList();
        }
        
        public void AddNewFlight(Flight flight)
        {
            var flightCollection = ConnectToMongo<Flight>(FlightCollection);
            flightCollection.InsertOne(flight);
        }

        public void DeleteFlight(Flight flight)
        {
            var flightCollection = ConnectToMongo<Flight>(FlightCollection);
            flightCollection.DeleteOne(x => x.Id == flight.Id);
        }


        public List<Flight> UpdateFlight(Flight flight)
        {
            var flightCollection = ConnectToMongo<Flight>(FlightCollection);
            flightCollection.DeleteOne(x => x.Id == flight.Id);
            return flightCollection.Find(_ => true).ToList();
        }

        public List<User> DeleteUser(User user)
        {
            var userCollection = ConnectToMongo<User>(UserCollection);
            userCollection.DeleteOne(x => x.Id == user.Id);
            return userCollection.Find(_ => true).ToList();
        }

        #endregion

        #region User
        

        public List<City> GetAllCities()
        {
            var cityCollection = ConnectToMongo<City>(CityCollection);
            var result = cityCollection.Find(_ => true);
            return result.ToList();
        }

        public List<Place> GetPlaces(Flight flight)
        {
            var placeCollection = ConnectToMongo<Place>(CityCollection);
            var result = placeCollection.Find(x => x.Flight.Id == flight.Id);
            return result.ToList();
        }

        public List<Order> GetUserReservation(User user)
        {
            var orderCollection = ConnectToMongo<Order>(UserCollection);
            var result = orderCollection.Find(x => x.User.Id == user.Id);
            return result.ToList();
        }

        #endregion 
    }
}
