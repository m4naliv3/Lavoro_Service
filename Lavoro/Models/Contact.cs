namespace Lavoro.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Company { get; set; }
        public string ContactImage { get; set; }
        public bool Favorite { get; set; }
        public int AccountID { get; set; }
        public int ProviderID { get; set; }
    }
}