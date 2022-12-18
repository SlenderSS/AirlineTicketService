using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    [DataContract]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [DataMember]
        public string Id { get; set; }        
        [DataMember]
        public User User { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public Place Place { get; set; }
        [DataMember]
        public string State { get; set; }
    }
}
