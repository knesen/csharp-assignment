using csharp_assignment.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace csharp_assignment.Services
{
    public class ContactService
    {
        private readonly FileService _fileService = new FileService(@"C:\Projects\content.json");
        private List<Contact> _contactList = new List<Contact>();

        /// <summary>
        /// Add a contact to the contact list
        /// </summary>
        /// <param name="contact">Contact of type IContact</param>
        public void AddContactToList(Contact contact)
        {
            try
            {
                if (!_contactList.Any(x => x.Email == contact.Email))
                {
                    _contactList.Add(contact);
                    _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList));
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            
        }

        /// <summary>
        /// Deletes a contact from the contact list and saves the list to the file
        /// </summary>
        /// <param name="contact">Contact of the type IContact, identified for deletion by its Email attribute</param>
        public void RemoveContactFromList(Contact contact)
        {
            try
            {
                if (_contactList.Any(x => x.Email == contact.Email))
                {
                    _contactList.Remove(contact);
                    _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList));

                }
                else Console.WriteLine("Kontakten kunde inte hittas");
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }

        /// <summary>
        /// Reads the file in the filepath if it exists
        /// </summary>
        /// <returns>Returns the contact list from the file</returns>
        public IEnumerable<Contact> GetContactsFromList()
        {
            try
            {
                var content = _fileService.GetContentFromFile();
                if (!string.IsNullOrEmpty(content)) 
                { 
                _contactList = JsonConvert.DeserializeObject<List<Contact>>(content)!;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            return _contactList;
        }
    }
}
