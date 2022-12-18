using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

using System.Runtime.Serialization;


namespace Server.Models
{
    [DataContract(Namespace = "ServiceModels")]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Card { get; set; }
        [DataMember]
        public string Connection { get; set; }
        [DataMember]
        public DateTime RegistrationDate { get; set; }

    }
}
