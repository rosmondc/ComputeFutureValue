using AutoMapper;
using ComputeFutureValue.Common.Entities;
using ComputeFutureValue.Common.ViewModels;

namespace ComputeFutureValue.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InvoiceHistory, InvoiceHistoryViewModel>().ReverseMap();
        }
    }
}
