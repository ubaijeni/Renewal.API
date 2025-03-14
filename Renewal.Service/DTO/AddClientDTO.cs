namespace Renewal.Service.DTO
{
    public class AddClientDTO
    {
        public string CLIENTNAME { get; set; }
        public bool ISACTIVE { get; set; }
        public int CREATEDBY { get; set; }
        public DateTime CREATEDDATE { get; set; }
        public int UPDATEDBY { get; set; }
        public DateTime UPDATEDDATE { get; set; }
        public int Suspend { get; set; }
    }
}
