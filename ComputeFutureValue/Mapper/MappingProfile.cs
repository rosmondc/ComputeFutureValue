using AutoMapper;
using ComputeFutureValue.Api.Data.Entities;
using ComputeFutureValue.ViewModel;

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
