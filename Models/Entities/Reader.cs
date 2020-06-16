using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadersCqrsApp.Models.Entities
{
    public class Reader
    {
        [Key]
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Bio { get; set; }
        public DateTime AddedOn { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}