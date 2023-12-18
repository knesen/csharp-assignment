using csharp_assignment.Interfaces;

namespace csharp_assignment.Models
{
    public class Contact : IContact
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set ; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Adress { get; set; } = null!;


        
        public override string ToString()
        {
            return String.Format($"Förnamn: {FirstName}, Efternamn: {LastName}, E-mail: {Email}, Telefonnummer: {PhoneNumber}, Adress: {Adress} ");
        }
    }
}
