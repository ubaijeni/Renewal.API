using AutoMapper;
using Renewal.DataHub.Models.Domain;
using Renewal.Service.DTO;

namespace Renewal.Service.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddClientDTO, Client>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<RenewalValue, RenewalValueDTO>().ReverseMap();
            CreateMap<TransactionDetails, TransactionDTO>().ReverseMap();
            CreateMap<AddRenewalValueDTO, RenewalValue>().ReverseMap();

            // ✅ Add this line to fix the error
            CreateMap<RenewalValue, TransactionDetails>().ReverseMap();

        }
    }
}
