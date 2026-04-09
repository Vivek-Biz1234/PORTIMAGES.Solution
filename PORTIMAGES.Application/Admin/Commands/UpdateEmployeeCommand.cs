using MediatR;
using PORTIMAGES.Common.Responses;

namespace PORTIMAGES.Application.Admin.Commands
{
    public class UpdateEmployeeCommand : IRequest<ApiResponse<object>>
    {
        public int ID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; } 
        public bool IsActive { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
