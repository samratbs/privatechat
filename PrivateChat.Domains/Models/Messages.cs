using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateChat.Domains.Models
{
    public class Messages
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Message { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
