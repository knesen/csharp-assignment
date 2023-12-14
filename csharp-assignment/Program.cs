
using csharp_assignment.Interfaces;
using csharp_assignment.Models;
using System.Collections;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

var contactList = new List<IContact>();
int option;

//Skapa och lägg till en ny kontakt i listan
void addContact()
{
    Contact contact = new Contact();

    Console.WriteLine("Skriv kontaktens förnamn");
    contact.FirstName = Console.ReadLine();

    Console.WriteLine("Skriv kontaktens efternamn");
    contact.LastName = Console.ReadLine();

    Console.WriteLine("Skriv kontaktens email-adress");
    contact.Email = Console.ReadLine();

    Console.WriteLine("Skriv kontaktens telefonnummer");
    contact.PhoneNumber = Console.ReadLine();

    Console.WriteLine("Skriv kontaktens adress");
    contact.Adress = Console.ReadLine();

    contactList.Add(contact);
    Console.Clear();
    Console.WriteLine($"Kontakten {contact.FirstName} {contact.LastName} lades till");
}

//Ta bort en kontakt från listan genom att skriva in kontaktens email-adress
void removeContact()
{
    Console.Clear();
    Console.WriteLine("För att radera en kontakt, skriv in kontaktens email-adress nedan och tryck 'enter'");

    var contactByEmail = contactList.Find(i => i.Email == Console.ReadLine());
    
    contactList.Remove(contactByEmail);

    Console.WriteLine($"Kontakten {contactByEmail.FirstName} {contactByEmail.LastName} har tagits bort");
}
//Hitta en kontakt genom att skriva in dess nummer i listan och visa samtlig information om den kontakten
void findContact()
{
    Console.Clear();
    Console.WriteLine("För att visa en kontakt, skriv in kontaktens nummer och tryck 'enter'");

    int specificContact = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine(contactList[specificContact-1]);       

} 


//Skriver ut för- och efternamn för samtliga kontakter i listan, tillsammans med listnummer
void printList()
{
    bool isEmpty = !contactList.Any();
    

    if (!isEmpty)
    {
        for (int i = 0; i < contactList.Count; i++)
        {
            Console.WriteLine($"{i+1}. {contactList[i].FirstName} {contactList[i].LastName}");
        }
      
    }
    else
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("Kontaktlistan är tom");
        Console.WriteLine("");
    }
}
//Instruktioner för  menyn nedan
void mainMenu()
{
    Console.WriteLine("");
    Console.WriteLine("För att göra ett val nedan, skriv en siffra och tryck 'enter'");
    Console.WriteLine("1: Lägg till en ny kontakt");
    Console.WriteLine("2: Se hela kontaktlistan");
    Console.WriteLine("3: Visa en kontakt");
    Console.WriteLine("4: Radera en kontakt");
    Console.WriteLine("5: Stäng programmet");
    Console.WriteLine("");
}

//Meny som läser in användarens val i form av en siffra
do
{

    mainMenu();

    option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Lägg till en ny kontakt i listan");
            Console.WriteLine("");
            addContact();
            break;
        case 2:
            Console.Clear();
            printList();
            break;
        case 3:
            findContact();
            break;
        case 4:
            removeContact();
            break;
        case 5:
            break;
        default:
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Du måste skriva en giltig siffra");
            Console.WriteLine("");
            break;

    }

} while (option != 5);


Console.ReadKey();