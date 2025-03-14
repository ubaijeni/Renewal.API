using AutoMapper;
using Renewal.DataHub.Models.Domain;
using Renewal.Services.DTOs;

namespace Renewal.Services.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Branch, BranchDTO>();
            CreateMap<AddBranchDTO, Branch>();
            CreateMap<UpdateBranchDTO, Branch>();


            CreateMap<PettyCashTransaction, PettyCashTransactionDTO>()
            .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch != null ? src.Branch.BranchName : string.Empty))
            .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType)) // "Credit" or "Debit"
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount)) // Maps the actual transaction amount
            .ForMember(dest => dest.BalanceAmount, opt => opt.Ignore()); // Balance will be calculated separately
            CreateMap<AddPettyCashTransactionDTO, PettyCashTransaction>();
            CreateMap<UpdatePettyCashTransactionDTO, PettyCashTransaction>();
        }
    }
}

