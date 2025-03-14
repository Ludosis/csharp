namespace SdetBootcampDay2.TestObjects.Examples
{
    public interface IRecipient
    {
        string GetMessages();
    }


    public class Recipient : IRecipient
    {
        public string GetMessages()
        {
            return "REAL messages";
        }
    }
}
