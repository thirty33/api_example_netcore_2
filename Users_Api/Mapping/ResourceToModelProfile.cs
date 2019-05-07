using AutoMapper;
using Users_Api.Models;
using Users_Api.Resources;

namespace Users_Api.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
        }
    }
}
