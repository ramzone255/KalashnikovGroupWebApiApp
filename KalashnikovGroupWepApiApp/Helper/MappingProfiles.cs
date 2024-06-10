using AutoMapper;
using KalashnikovGroupWepApiApp.Dto;
using KalashnikovGroupWepApiApp.Models;


namespace KalashnikovGroupWepApiApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Components, ComponentsDto>();
            CreateMap<ComponentsDto, Components>();
            CreateMap<OperationsTypes, OperationsTypesDto>();
            CreateMap<OperationsTypesDto, OperationsTypes>();
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
            CreateMap<PaymentType, PaymentTypeDto>();
            CreateMap<PaymentTypeDto, PaymentType>();
            CreateMap<Employees, EmployeesDto>();
            CreateMap<EmployeesDto, Employees>();
            CreateMap<Payments, PaymentsDto>();
            CreateMap<PaymentsDto, Payments>();
            CreateMap<Operations, OperationsDto>();
            CreateMap<OperationsDto, OperationsDto>();
            CreateMap<Deal, DealDto>();
            CreateMap<DealDto, Deal>();
            CreateMap<Payday, PaydayDto>();
            CreateMap<PaydayDto, Payday>();
        }
    }
}
