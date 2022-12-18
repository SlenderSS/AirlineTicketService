using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Server.Models;
using System;
using System.Runtime.Serialization;

namespace Server
{
    [DataContract]
    public class Flight
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public int FlightNumber { get; set; }
        [DataMember]
        public City StartCity { get; set; }
        [DataMember]
        public City EndCity { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        [DataMember]
        public DateTime DateFlight { get; set; }
        [DataMember]
        public int Cost { get; set; }
        [DataMember]
        public int NumOfPlaces { get; set; }
    }
   
}