using csharp_assignment.Interfaces;

namespace csharp_assignment.Models
{
    public class Contact : IContact
    {
        public string FirstName { get; set ; }
        public string LastName { get; set ; }
        public string Email { get; set ; }
        public string PhoneNumber { get; set ; }
        public string Adress { get; set ; }


        public override string ToString()
        {
            return String.Format($"Förnamn: {FirstName}, Efternamn: {LastName}, E-mail: {Email}, Telefonnummer: {PhoneNumber}, Adress: {Adress} ");
        }
    }
}
