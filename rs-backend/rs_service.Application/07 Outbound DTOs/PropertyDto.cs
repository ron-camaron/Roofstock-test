using AutoMapper;
using rs_service.Application.Interfaces.Mapping;

namespace rs_service.Application.DTOs
{
    public class PropertyDto : IMapFrom<Domain.Entities.Property>
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ZipPlus4 { get; set; }
        public int? YearBuilt { get; set; }
        public decimal? ListPrice { get; set; }
        public decimal? MonthlyRent { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Property, PropertyDto>()
                .ForMember(d => d.Zip, opt => opt.MapFrom(s => s.ZipCode)); // necessary only for discrepancies between entity and dto
        }
    }
}
