
using csharp_assignment.Interfaces;
using csharp_assignment.Models;
using csharp_assignment.Services;
using System.Diagnostics;


int option;

var contactService = new ContactService();

var _contactList = contactService.GetContactsFromList();


//Create and add a new contact to the list
void AddContact()
{
    Contact contact = new Contact();

    try {

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


    Console.Clear();
    Console.WriteLine($"Kontakten {contact.FirstName} {contact.LastName} lades till");

    contactService.AddContactToList(contact);
    }
    catch (Exception ex) { Debug.WriteLine(ex); }
}

//Remove a contact from the list by typing the contacts email address
void RemoveContact()
{
    Console.Clear();
    Console.WriteLine("För att radera en kontakt, skriv in kontaktens email-adress nedan och tryck 'enter'");
    try
    {

        var enteredEmail = Console.ReadLine();
        var contactByEmail = _contactList.FirstOrDefault(i => i.Email == enteredEmail);         
    
    if (contactByEmail != null)
        {
        contactService.RemoveContactFromList(contactByEmail);
        Console.WriteLine($"Kontakten {contactByEmail.FirstName} {contactByEmail.LastName} har tagits bort");
        Console.WriteLine();

        }
    else
        {
            Console.Clear();
            Console.WriteLine($"Ingen kontakt med email-adressen {enteredEmail} kunde inte hittas. Kontrollera email-adressen och försök igen.");
            Console.WriteLine();
        }


    }
    catch (Exception ex) { Debug.WriteLine(ex); }
    
}


//Find a contact and show all the information of the contact by typing in the contacts number in the list
void FindContact()
{
    try
    {
        Console.Clear();
        Console.WriteLine("För att visa en kontakt, skriv in kontaktens nummer och tryck 'enter'");


        int specificContactIndex = Convert.ToInt32(Console.ReadLine()) - 1;
        int numberOfContacts = _contactList.Count();

        if (specificContactIndex >= 0 && specificContactIndex < numberOfContacts)
        {
            var specificContact = _contactList.ElementAt(specificContactIndex);
            Console.Clear();
            Console.WriteLine(specificContact);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Det finns ingen kontakt med det numret.");
            Console.WriteLine();
        }
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex);
    }
}


//Prints the first and last name for each of the contacts in the list, together with their individual index
void PrintList()
{
    bool isEmpty = !_contactList.Any();
    

    if (!isEmpty)
    {
        for (int i = 0; i < _contactList.Count(); i++)
        {
            Console.WriteLine($"{i+1}. {_contactList.ElementAt(i).FirstName} {_contactList.ElementAt(i).LastName}");
            Console.WriteLine();
        }
      
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Kontaktlistan är tom");
        Console.WriteLine();
    }
}

//Menu instructions
void MainMenu()
{
    Console.WriteLine("För att göra ett val nedan, skriv en siffra och tryck 'enter'");
    Console.WriteLine("1: Lägg till en ny kontakt");
    Console.WriteLine("2: Se hela kontaktlistan");
    Console.WriteLine("3: Visa en kontakt");
    Console.WriteLine("4: Radera en kontakt");
    Console.WriteLine("5: Stäng programmet");
    Console.WriteLine();
}

//Menu that reads the users choice by number
do
{

    MainMenu();

    option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Lägg till en ny kontakt i listan");
            Console.WriteLine("");
            AddContact();
            break;
        case 2:
            Console.Clear();
            PrintList();
            break;
        case 3:
            FindContact();

            break;
        case 4:
            RemoveContact();
            break;
        case 5:
            break;
        default:
            Console.Clear();
            Console.WriteLine("Du måste skriva en giltig siffra");
            Console.WriteLine("");
            break;

    }
    
} while (option != 5);


Console.ReadKey();