namespace ReadersCqrsApp.Models
{
    public class ReaderResponseModel
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Bio { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
    }

    public class CreateReaderModel
    {
        public string Alias { get; set; }
        public string Bio { get; set; }
        public int UserId { get; set; }
    }

    public class UpdateReaderModel
    {
        public string Alias { get; set; }
        public string Bio { get; set; }
    }
}