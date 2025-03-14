namespace Renewal.Service.DTO
{
    public class RenewalValueDTO
    {
        public Guid RENEWALID { get; set; }
        public Guid? BRANCHID { get; set; }
        public Guid? CATEGORYID { get; set; }
        public string DESCRIPTION { get; set; }
        public string STARTDATE { get; set; }
        public string ENDDATE { get; set; }
        public string VALIDITY { get; set; }
        public string RENEWALDATE { get; set; }
        public decimal? AMOUNT { get; set; }
        public int REMINDER { get; set; }
        public string ALERTTO { get; set; }
        public int STATUS { get; set; }
        public bool ACTIVE { get; set; }
        public int CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        public int? UPDATEDBY { get; set; }
        public DateTime UPDATEDDATE { get; set; }
        public bool? SUSPEND { get; set; }
    }
}
