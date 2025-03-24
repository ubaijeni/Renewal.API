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
            CreateMap<AmountReceive, AmountReceiveDTO>().ReverseMap();
            CreateMap<AddRenewalValueDTO, RenewalValue>().ReverseMap();
            CreateMap<AddAmountReceiveDTO, AmountReceive>().ReverseMap();

            CreateMap<AmountReceive, AmountReceiveDTO>()
                .ForMember(dest => dest.BalanceAmount, opt => opt.MapFrom((src, dest, destMember, context) =>
                {
                    var poValue = src.PODetail?.POValue ?? 0;
                    var totalReceived = context.Items.ContainsKey("TotalAmountReceived")
                        ? (decimal)context.Items["TotalAmountReceived"]
                        : 0;
                    return poValue - totalReceived - src.Amountreceived;
                }));

            CreateMap<RenewalValue, TransactionDetails>().ReverseMap();
        }
    }
}
