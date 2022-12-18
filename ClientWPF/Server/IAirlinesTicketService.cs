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
        (Flight[],string) GetAllFlights();

        [OperationContract]
        (Order[], string) GetAllOrders();

        [OperationContract]
        (User[], string) GetAllUsers();

        [OperationContract]
        string AddNewFlight(Flight flight);

        [OperationContract]
        (Flight[], string) DeleteFlight(Flight flight);

        [OperationContract]
        string UpdateFlight(Flight flight);

        [OperationContract]
        (User[], string) DeleteUser(User user);

        [OperationContract]
        (City[], string) GetAllCities();

        [OperationContract]
        (Flight[], string) GetFlights(Flight flight);
        
        [OperationContract]
        (Place[], string) GetPlaces(Flight flight);

        [OperationContract]
        (Order[], string) GetUserReservation(User user);

        [OperationContract]
        (Order[], string) CancelReservation(Order order);

        [OperationContract]
        (Place[], string) ReservePlace(User user, Place place);

        [OperationContract]
        (Order[], string) BuyTicket(Order order);
      
    }
}
