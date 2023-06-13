namespace Contacts.Common
{
    using AutoMapper;
    using Contacts.Data.Models;
    using Contacts.Models.Contacts;

    public class Mapping:Profile
    {
        public Mapping()
        {
            this.CreateMap<Contact,ContactViewModel>()
                .ForMember(dest=>dest.ContactId,opt=>opt.MapFrom(src=>src.Id));
            this.CreateMap<Contact,AddContactViewModel>();
            this.CreateMap<AddContactViewModel,Contact>();
        }
    }
}
