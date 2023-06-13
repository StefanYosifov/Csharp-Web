namespace Contacts.Services.Contacts
{
    using global::Contacts.Models.Contacts;

    public interface IContactService
    {

        Task<IEnumerable<ContactViewModel>> GetAllContactsAsync();

        Task<IEnumerable<ContactViewModel>> GetTeamsContactsAsync();

        Task AddContactAsync(AddContactViewModel contact);

        Task AddToCollection(int id);

        Task RemoveFromCollection(int id);

        Task<AddContactViewModel> GetEditModelById(int id);

        Task EditContact(int id, AddContactViewModel contact);
    }
}
