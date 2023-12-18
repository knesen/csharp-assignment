using csharp_assignment.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace csharp_assignment.Services
{
    public class ContactService
    {
        private readonly FileService _fileService = new FileService(@"C:\Projects\content.json");
        private List<Contact> _contactList = new List<Contact>();
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

        public void RemoveContactFromList(Contact contact)
        {
            try
            {
                if (_contactList.Any(x => x.Email == contact.Email))
                {
                    _contactList.Remove(contact);
                    _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList));
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }
        public IEnumerable<Contact> GetContactsFromList()
        {
            try
            {
                var content = _fileService.GetContentFromFile();
                if (!string.IsNullOrEmpty(content)) 
                { 
                _contactList = JsonConvert.DeserializeObject<List<Contact>>(content);
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            return _contactList;
        }
    }
}
