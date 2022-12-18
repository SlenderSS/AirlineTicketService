using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAirlinesTicketService" in both code and config file together.
    [ServiceContract]
    public interface IAirlinesTicketService
    {

        [OperationContract]
        User Autorization(User user);

        [OperationContract]
        void Disconnect(User user);

        [OperationContract]
        string Registration(User newUser);

        [OperationContract]
        string UpdateUserInformation(User user);

        [OperationContract]
        Flight[] GetAllFlights();

        [OperationContract]
        Order[] GetAllOrders();

        [OperationContract]
        User[] GetAllUsers();

        [OperationContract]
        string AddNewFlight(Flight flight);

        [OperationContract]
        Flight[] DeleteFlight(Flight flight);

        [OperationContract]
        string UpdateFlight(Flight flight);

        [OperationContract]
        User[] DeleteUser(User user);

        [OperationContract]
        City[] GetAllCities();

        [OperationContract]
        Flight[] GetFlights(Flight flight);
        
        [OperationContract]
        Place[] GetPlaces(Flight flight);

        [OperationContract]
        Order[] GetUserReservation(User user);

        [OperationContract]
        Order[] CancelReservation(Order order);

        [OperationContract]
        (Place[], string) ReservePlace(User user, Place place);

        [OperationContract]
        Order[] BuyTicket(Order order);
      
    }
}
