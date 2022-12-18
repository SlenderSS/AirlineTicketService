using MongoDB.Driver;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AirlinesTicketService : IAirlinesTicketService
    {
        #region fields
        private string ConnectionString = "mongodb://127.0.0.1:27017";
        private string DataBaseName = "airlinesticketdb";
        private string UserCollection = "users";
        private string OrderCollection = "orders";
        private string PlaceCollection = "places";
        private string CityCollection = "cities";
        private string FlightCollection = "flights";
        

        #endregion

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {

            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DataBaseName);
            return db.GetCollection<T>(collection);
        }

        public string AddNewFlight(Flight flight)
        {
            try
            {
                var flightCollection = ConnectToMongo<Flight>(FlightCollection);
                var notExist = flightCollection.AsQueryable()
                    .FirstOrDefault(x => x.FlightNumber == flight.FlightNumber
                                       & x.StartCity == flight.StartCity
                                       & x.EndCity == flight.EndCity
                                       & x.DateFlight == flight.DateFlight) == null;
                if (notExist)
                {
                    flightCollection.InsertOne(flight);
                    GeneretePlaces(flight);
                    WriteAdminRequest($"Додано новий рейс з {flight.FlightNumber}: {flight.StartCity.CityName} --> {flight.EndCity.CityName}");
                    return "Рейс додано";
                }
                else
                    return "Рейс вже існує";
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
                return ex.Message;
            }
                  
        }
        
        private void GeneretePlaces(Flight flight)
        {
            var placeCollection = ConnectToMongo<Place>(PlaceCollection);
            for (int i = 1; i < flight.NumOfPlaces + 1; i++)
            {
                placeCollection.InsertOne(new Place()
                {
                    Flight = flight,
                    PlaceNumber = i,
                    State = "Вільно"
                });      
            }
        }

        #region UpdateRecord
        private void UpdateFlightCollection(IMongoCollection<Flight> flightCol)
        {
            var flightCollection = flightCol;
            var placeCollection = ConnectToMongo<Place>(PlaceCollection);
            var flightList = flightCollection.Find(x => x.DateFlight < DateTime.Now).ToList();
            foreach (var flight in flightList)
            {                
                flightCollection.UpdateOneAsync(
                    Builders<Flight>.Filter.Eq(x => x.Id, flight.Id),
                    Builders<Flight>.Update.Set(x => x.DateFlight, DateTime.Now.AddDays(new Random().Next(1,10))));
                 UpdatePlaceCollection(placeCollection, flightCollection.Find(x => x.Id == flight.Id).FirstOrDefault());
            }
            Console.WriteLine("***********************************************");
            Console.WriteLine("Оновленно список рейсів");
            Console.WriteLine("***********************************************");
        }
        private void UpdatePlaceCollection(IMongoCollection<Place> placeCol, Flight flight)
        {
            var placeCollection = placeCol;
            var placeList = placeCollection.Find(x => x.Flight.Id == flight.Id).ToList();
            foreach (var place in placeList)
            {
                placeCollection.UpdateOne(
                    Builders<Place>.Filter.Eq(x => x.Id, place.Id),
                    Builders<Place>.Update.Set(x => x.Flight.DateFlight, flight.DateFlight));
            }
        }
        public string UpdateFlight(Flight flight)
        {
            var flightCollection = ConnectToMongo<Flight>(FlightCollection);         
            
            flightCollection.UpdateOne(
                Builders<Flight>.Filter.Eq(u => u.Id, flight.Id),
                 Builders<Flight>.Update
                .Set(p => p.DateFlight, flight.DateFlight)
                .Set(c => c.Cost, flight.Cost));

            var placeCollection = ConnectToMongo<Place>(PlaceCollection);

            placeCollection.UpdateMany(
                Builders<Place>.Filter.Eq(x => x.Flight.Id, flight.Id),
                Builders<Place>.Update.Set(x => x.Flight.DateFlight, flight.DateFlight));

            WriteAdminRequest($"Оновлено рейс з Id {flight.Id.ToString()}");
            return "Рейс редаговано";
        }
        public string UpdateUserInformation(User user)
        {
            var userCollection = ConnectToMongo<User>(UserCollection);
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            var update = Builders<User>.Update
                .Set(p => p.Password, user.Password)
                .Set(c => c.Card, user.Card);
            userCollection.UpdateOne(filter, update);
            WriteUserRequest(user, "Оновлено дані користувача");
            return "Дані оновлено";
        }

        #endregion

        #region DeleteRecord

        public (Flight[], string) DeleteFlight(Flight flight)
        {
            try
            {
                var flightCollection = ConnectToMongo<Flight>(FlightCollection);
                flightCollection.DeleteOne(x => x.Id == flight.Id);
                WriteAdminRequest($"Видалено рейс з Id {flight.Id.ToString()}");

                var placeCollection = ConnectToMongo<Place>(PlaceCollection);
                placeCollection.DeleteMany(x => x.Flight.Id == flight.Id);

                return (flightCollection.Find(_ => true).ToList().ToArray(), null);
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
                return (null, "Не вдалось видалити рейс");
            } 
            
        }

        public (User[], string) DeleteUser(User user)
        {
            try
            {
                var userCollection = ConnectToMongo<User>(UserCollection);
                userCollection.DeleteOne(x => x.Id == user.Id);
                WriteAdminRequest($"Видалено користувача з Id {user.Id.ToString()}");
                return (userCollection.Find(_ => true).ToList().ToArray(), null);
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
                return (null, "Не вдалось видалити користувача");
            }
           
        }

        #endregion
     
        #region GetRecords

        public (Flight[], string) GetAllFlights()
        {
            try
            {
                IMongoCollection<Flight> flightCollection;
                UpdateFlightCollection(flightCollection = ConnectToMongo<Flight>(FlightCollection));
                return (flightCollection.Find(_ => true).ToList().ToArray(), null);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return (null, "Не вдалось отримати список всіх ресів");
        }

        public (Order[], string) GetAllOrders()
        {
            try
            {
                var orderCollection = ConnectToMongo<Order>(OrderCollection);
                orderCollection.DeleteMany(x => x.Place.Flight.DateFlight < DateTime.Now);
                var placeCollection = ConnectToMongo<Place>(PlaceCollection);
                placeCollection.UpdateMany(
                    Builders<Place>.Filter.Lt(x => x.Flight.DateFlight, DateTime.Now),
                    Builders<Place>.Update.Set(x => x.State, "Вільно"));

            
                var result = orderCollection.Find(_ => true).ToList();
                return (result.ToArray(), null);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return (null, "Не вдалось отримати список всіх замовлень");
            }
        }

        public (User[], string) GetAllUsers()
        {
            try
            {
                var userCollection = ConnectToMongo<User>(UserCollection);
                return (userCollection.Find(_ => true).ToList().ToArray(), null);
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
                return (null, "Не вдалось отримати список користувачів");
            }
        }

        public (City[], string) GetAllCities()
        {
            try
            {
                var cityCollection = ConnectToMongo<City>(CityCollection);
                var result = cityCollection.Find(_ => true);
                var res = result.ToList();
                Console.WriteLine("***********************************************");
                Console.WriteLine("Отримати список наявних міст");
                Console.WriteLine("***********************************************");
                return (res.ToArray(), null);
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
                return (null, "Не вдалось отримати список міст");
            }
            
        }

        public (Place[], string) GetPlaces(Flight flight)
        {
            try
            {
                var placeCollection = ConnectToMongo<Place>(PlaceCollection);
                Console.WriteLine("***********************************************");
                Console.WriteLine($"Отримати список місць рейсу {flight.FlightNumber}: " +
                    $"{flight.StartCity.CityName} --> {flight.EndCity.CityName}" +
                    $"\n {flight.DateFlight.ToString()}");
                Console.WriteLine("***********************************************");

                return (placeCollection.Find(x => x.Flight.Id == flight.Id).ToList().ToArray(), null);
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
                return (null, "Не вдалось отримати список місць");
            }
            
        }

        public (Order[], string) GetUserReservation(User user)
        {
            try
            {
                var orderCollection = ConnectToMongo<Order>(OrderCollection);
                WriteUserRequest(user, "Отримати список заброньованих місць");
                return (orderCollection.Find(x => x.User.Id == user.Id).ToList().ToArray(), null);
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
                return (null,"Не вдалось отримати бронювання");
            }
           
        }
        
        public (Flight[], string) GetFlights(Flight flight)
        {
            try
            {
                var flightCollection = ConnectToMongo<Flight>(FlightCollection);
                Console.WriteLine("***********************************************");
                Console.WriteLine($"Отримати список рейсів {flight.StartCity.CityName} --> {flight.EndCity.CityName}");
                Console.WriteLine("***********************************************");
                var result = flightCollection.Find(
                    x => x.StartCity == flight.StartCity
                    & x.EndCity == flight.EndCity
                    & x.DateFlight >= flight.DateFlight)
                    .ToList();

                return (result.ToArray(), null);
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }
            return (null,"Не вдалось отримати список рейсів");
           
        }

        #endregion

        #region OutputRequests

        private void WriteAdminRequest(string request)
        {
            Console.WriteLine("***********************************************"
                            +$"\nadmin: {request}"
                            +"\n***********************************************");
        }

        private void WriteUserRequest(User user, string str)
        {
            Console.WriteLine("***********************************************"
                            + $"\n{str}: "
                            + $"\n\tID               {user.Id.ToString()}"
                            + $"\n\tEmail            {user.Email}"
                            + $"\n\tЧас              {DateTime.Now.ToString()}"
                            + "\n***********************************************");
        }

        private void PrintError(string ex)
        {
            Console.WriteLine($"--------------------------------------------------" +
                              $"Error: {ex}" +
                              $"--------------------------------------------------");
        }
        #endregion

        #region Connections

        public User Autorization(User user)
        {
            try
            {
                var userCollection = ConnectToMongo<User>(UserCollection);
                var exist = userCollection.AsQueryable().FirstOrDefault(x => x.Email == user.Email) != null;
                if (exist)
                {
                    var userObject = userCollection.Find(x => x.Email == user.Email).FirstOrDefault();
                    if (userObject.Password == user.Password)
                    {
                        Connect(userObject);
                        return userObject;
                    }
                    else
                        return null;
                }
                
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }
            return null;
           
        }

        public string Registration(User newUser)
        {
            try
            {
                var userCollection = ConnectToMongo<User>(UserCollection);
                var exist = userCollection.AsQueryable().FirstOrDefault(x => x.Email == newUser.Email) != null;
                if (exist)
                    return "Користувач вже є";
                else
                {
                    userCollection.InsertOne(newUser);
                    var registeredUser = userCollection.Find(x => x.Email == newUser.Email).FirstOrDefault();
                    WriteUserRequest(registeredUser, "Зареєстрованого нового користувача");
                    return "Вас зареєстровано";
                }

            }
            catch (Exception ex)
            {
                PrintError(ex.Message);    
            }
            return "Помилка реєстрації!";
            
        }

        public void Connect(User user)
        {
            try
            {
                var userCollection = ConnectToMongo<User>(UserCollection);
                userCollection.UpdateOne(
                    Builders<User>.Filter.Eq(u => u.Id, user.Id),
                    Builders<User>.Update.Set(u => u.Connection, "Online"));
                WriteUserRequest(user, "Підключився користувач");
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }
            
        }

        public void Disconnect(User user)
        {
            try
            {
                var userCollection = ConnectToMongo<User>(UserCollection);
                userCollection.UpdateOne(
                    Builders<User>.Filter.Eq(u => u.Id, user.Id),
                    Builders<User>.Update.Set(u => u.Connection, "Offline"));
                WriteUserRequest(user, "Відключився користувач");
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }            
        }

        #endregion

        #region ReservationOperation

        public (Order[], string)  CancelReservation(Order order)
        {
            try
            {
                var orderColletion = ConnectToMongo<Order>(OrderCollection);
                orderColletion.DeleteOne(o => o.Id == order.Id);
                SetPlaceState(order.Place, "Вільно");

                WriteUserRequest(order.User, "Отримати список заброньованих місць");
                return (orderColletion.Find(_ => true).ToList().ToArray(), "Бронювання скасовано");
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
                return (null, "Невдалось скасувати");
            }
            
        }

        public (Order[], string) BuyTicket(Order order)
        {
            try
            {
                var orderCollection = ConnectToMongo<Order>(OrderCollection);
                var filter = Builders<Order>.Filter.Eq(u => u.Id, order.Id);
                var update = Builders<Order>.Update
                    .Set(p => p.State, "Куплено");

                SetPlaceState(order.Place, "Куплено");

                orderCollection.UpdateOne(filter, update);

                WriteUserRequest(order.User, $"Оплачена резервація {order.Id.ToString()}");

                return (orderCollection.Find(u => u.User.Id == order.User.Id).ToList().ToArray(), "Квиток куплено");
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
                return (null, "Невдалось купити квиток");
            }
           

        }

        public (Place[],string) ReservePlace(User user, Place place)
        {
            try
            {
                var orderCollection = ConnectToMongo<Order>(OrderCollection);
                var exist = orderCollection.AsQueryable().FirstOrDefault(
                     x => x.Place.Flight.Id == place.Flight.Id & x.User.Id == user.Id) != null;
                if (exist)
                {
                    var result1 = GetPlaces(place.Flight);
                    result1.Item2 = $"У вас вже є {Environment.NewLine}заброньоване місце";
                    return result1;
                }
                orderCollection.InsertOne(new Order
                {
                    User = user,
                    Place = place,
                    OrderDate = DateTime.Now,
                    State = "Заброньовано"
                });
                WriteUserRequest(user, $"Заброньоване місце {place.Id.ToString()}");

                SetPlaceState(place, "Заброньовано");

                var result = GetPlaces(place.Flight);
                result.Item2 = $"Заброньовано";
                return result;
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
                return (null, "Не вдалось забронювати");
            }
            
        }
        
        private void SetPlaceState(Place place, string state)
        {
            try
            {
                var placeCollection = ConnectToMongo<Place>(PlaceCollection);
                var filter = Builders<Place>.Filter.Eq(x => x.Id, place.Id);
                var update = Builders<Place>.Update.Set(x => x.State, state);
                placeCollection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }          
        }

        #endregion


    }
}
