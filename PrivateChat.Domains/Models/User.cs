using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateChat.Domains.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        private string? _avatar { get; set; }
        public string Avatar
        {
            get
            {
                if (string.IsNullOrEmpty(_avatar))
                {
                    return "";
                }
                return _avatar;
            }
            set
            {
                _avatar=Avatar;
            }
        }
    }
}
