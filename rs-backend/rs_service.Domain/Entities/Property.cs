namespace rs_service.Domain.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string ZipPlus4 { get; set; }
        public int? YearBuilt { get; set; }
        public decimal? ListPrice { get; set; }
        public decimal? MonthlyRent { get; set; }
    }
}
