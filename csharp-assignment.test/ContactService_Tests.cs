using csharp_assignment.Interfaces;
using csharp_assignment.Models;
using Newtonsoft.Json;

namespace csharp_assignment.test;

public class ContactService_Tests
    {
    public List<Contact> contactList = new List<Contact>();
    public Contact contact1 = new Contact();
    
    [Fact]
    public void AddContactToListShould_AddContactToTheList()
    {
        
    // Arrange
    contact1.Email = "testEmail";        
    contactList.Add(contact1);
     

    // Act
    bool result = contactList.Contains(contact1);

    // Assert
    Assert.True(result);
    
    }

    [Fact]
    public void AddContactToListShouldNot_AddContactToTheList_IfAContactWithThatEmailAlreadyExistsInTheList()
    {
        // Arrange

        contact1.Email = "testEmail";
        contactList.Add(contact1);
        Contact contact2 = new Contact();

        if (!contactList.Any(x => x.Email == contact1.Email))
        {
            contact2.Email = "testEmail";
            contactList.Add(contact2);

        }
        

        // Act
        bool result = contactList.Contains(contact2);

        // Assert
        Assert.False(result);

    }




}
