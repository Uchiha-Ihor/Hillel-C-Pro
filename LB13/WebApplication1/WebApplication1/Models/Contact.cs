namespace WebApplication1.Models
{
    public class Contact
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string AlternativeMobilePhone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public string GetFormattedInfo()
        {
            return $"Name: {Name}\nMobile: {MobilePhone}\nAlt Mobile: {AlternativeMobilePhone}\nEmail: {Email}\nDescription: {Description}";
        }

    }
}
