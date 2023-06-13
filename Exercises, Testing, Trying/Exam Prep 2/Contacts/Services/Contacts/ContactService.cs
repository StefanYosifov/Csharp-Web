namespace Contacts.Services.Contacts
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using global::Contacts.Data;
    using global::Contacts.Data.Models;
    using global::Contacts.Models.Contacts;
    using global::Contacts.Services.Users;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class ContactService : IContactService
    {
        private readonly ContactsDbContext context;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public ContactService(
            ContactsDbContext context,
            IMapper mapper,
            IUserService userService)
        {
            this.context = context;
            this.mapper = mapper;
            this.userService = userService;
        }

        public async Task AddContactAsync(AddContactViewModel contact)
        {
            var contactToAdd=mapper.Map<Contact>(contact);
            contactToAdd.PhoneNumber=contact.PhoneNumber.Replace("-",string.Empty);
            await context.AddAsync(contactToAdd);
            await context.SaveChangesAsync();
        }

        public async Task AddToCollection(int id)
        {
            var userId=userService.GetUserId();
            if(await context.ApplicationUserContacts.AnyAsync(au=>au.ContactId==id && au.ApplicationUserId==userId))
            {
                return;
            }

            var userContact=new ApplicationUserContact()
            {
                ApplicationUserId=userId,
                ContactId=id
            };

            await context.ApplicationUserContacts.AddAsync(userContact);
            await context.SaveChangesAsync();
        }

        public async Task EditContact(int id, AddContactViewModel contact)
        {
            var contactDb=await context.Contacts.FirstOrDefaultAsync(c=>c.Id==id);
            if (contact == null)
            {
                return;
            }

            contactDb.FirstName =contact.FirstName;
            contactDb.LastName = contact.LastName;
            contactDb.PhoneNumber = contact.PhoneNumber;
            contactDb.Email = contact.Email;
            contactDb.Address = contact.Address;
            contactDb.Website = contact.Website;

            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<ContactViewModel>> GetAllContactsAsync()
        => await context.Contacts.ProjectTo<ContactViewModel>(mapper.ConfigurationProvider).ToArrayAsync();

        public async Task<AddContactViewModel> GetEditModelById(int id)
        {
            var contact=await context.Contacts.FirstOrDefaultAsync(c=>c.Id==id);
            return mapper.Map<AddContactViewModel>(contact);
        }

        public async Task<IEnumerable<ContactViewModel>> GetTeamsContactsAsync()
        {
            var userId= userService.GetUserId();
            return await context.Contacts
                .Where(c=>c.ApplicationUserContacts.Any(au=>au.ApplicationUserId==userId))
                .ProjectTo<ContactViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }

        public async Task RemoveFromCollection(int id)
        {
            var userId=userService.GetUserId();
            var userContact=await context.ApplicationUserContacts
                .FirstOrDefaultAsync(au=>au.ContactId==id && au.ApplicationUserId==userId);

            if (userContact == null)
            {
                return;
            }

            context.ApplicationUserContacts.Remove(userContact);
            await context.SaveChangesAsync();
        }
    }
}
