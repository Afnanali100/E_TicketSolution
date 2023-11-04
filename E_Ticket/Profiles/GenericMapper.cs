using AutoMapper;

namespace E_Ticket.Profiles
{
    public class GenericMapper<T,TEntity>:Profile
    {

        public GenericMapper()
        {
            CreateMap<T, TEntity>().ReverseMap();
        }

    }
}
