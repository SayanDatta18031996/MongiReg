using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegMongo.Models
{
    [BsonIgnoreExtraElements]
    public class LoginModel
    {
        [BsonElement("Email")]
        public string Email { get; set; }
        
        [BsonElement("Password")]
        public string Password { get; set; }
    }
}
