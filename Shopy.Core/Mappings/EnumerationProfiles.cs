using AutoMapper;
using Shopy.Core.Domain.Entitties;
using Shopy.Core.Models;

namespace Shopy.Core.Mappings
{
    public class EnumerationProfiles : Profile
    {
        public EnumerationProfiles()
        {
            CreateMap<SizeType, SizeResponse>();
        }
    }
}
