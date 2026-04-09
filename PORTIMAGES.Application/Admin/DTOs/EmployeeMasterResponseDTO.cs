using PORTIMAGES.Common.Interfaces;

namespace PORTIMAGES.Application.Admin.DTOs
{
    public class EmployeeMasterResponseDTO: IEncrypTableDTO
    {
        public int ID { get; set; }
        public string? EncID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }         
        public bool IsActive { get; set; }
        public string? CreatedOn { get; set; }
        public string? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
