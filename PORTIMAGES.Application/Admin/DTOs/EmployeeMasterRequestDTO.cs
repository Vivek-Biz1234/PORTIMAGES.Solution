namespace PORTIMAGES.Application.Admin.DTOs
{
    public class EmployeeMasterRequestDTO
    {
        public int ID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }      
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
