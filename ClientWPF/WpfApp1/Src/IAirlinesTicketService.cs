
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ClientWPF.ServiceAirlines;

namespace ClientWPF.Src
{  
    [ServiceContract]
    public interface IAirlinesTicketService
    {
        [OperationContract]
        User Autorization(string login, string password);

        [OperationContract]
        string Registration(User newUser);

        [OperationContract]
        string UpdateUserInformation(User user);

        [OperationContract]
        List<Flight> GetAllFlights();

        [OperationContract]
        List<Order> GetAllOrders();

        [OperationContract]
        List<User> GetAllUsers();

        [OperationContract]
        string AddNewFlight(Flight flight);

        [OperationContract]
        List<Flight> DeleteFlight(Flight flight);

        [OperationContract]
        List<Flight> UpdateFlight(Flight flight);

        [OperationContract]
        List<User> DeleteUser(User user);

        [OperationContract]
        City[] GetAllCities();

        [OperationContract]
        List<Place> GetPlaces(Flight flight);

        [OperationContract]
        List<Order> CancelReservation(Place place);

        [OperationContract]
        string BuyTicket(Order order);
    }
}
