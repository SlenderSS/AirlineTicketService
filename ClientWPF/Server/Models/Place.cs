using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace Server
{
    [DataContract]
    public class Place
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public Flight Flight { get; set; }
        [DataMember]
        public int PlaceNumber { get; set; }
        [DataMember]
        public string State { get; set; }
    }
}