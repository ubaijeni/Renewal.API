namespace Renewal.Service.DTO
{
    public class ClientDTO
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public bool Isactive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? Suspend { get; set; }
    }
}
