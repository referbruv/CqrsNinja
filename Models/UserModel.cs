using System;

namespace ReadersCqrsApp.Models
{
    public class UserRequestModel
    {
        public string EmailAddress { get; set; }
        public string Username { get; set; }
    }

    public class UserResponseModel
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public DateTime AddedOn { get; set; }
    }
}