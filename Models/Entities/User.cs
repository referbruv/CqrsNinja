using System;
using System.ComponentModel.DataAnnotations;

namespace ReadersCqrsApp.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public DateTime AddedOn { get; set; }
    }
}