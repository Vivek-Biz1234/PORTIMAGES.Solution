using Dapper;
using Microsoft.Extensions.Logging;
using PORTIMAGES.Application.Admin.DTOs;
using PORTIMAGES.Application.Admin.Interfaces;
using PORTIMAGES.Common.Enums;
using PORTIMAGES.Common.Extensions;
using PORTIMAGES.Common.Helpers;
using PORTIMAGES.Common.Responses;
using PORTIMAGES.Infrastructure.Persistence;
using System.Data;

namespace PORTIMAGES.Infrastructure.Repositories.Admin
{
    public class EmployeeMasterRepository : IEmployeeMasterRepository
    {
        private readonly IDapperRepository _dapper;
        private readonly ILogger<EmployeeMasterRepository> _logger;
        public EmployeeMasterRepository(IDapperRepository dapper, ILogger<EmployeeMasterRepository> logger)
        {
            this._dapper = dapper;
            this._logger = logger;
        } 
        public async Task<ApiResponse<object>> AddEmployeeAsync(EmployeeMasterRequestDTO request)
        {
            try
            {
                string passwordHash = CryptoHelper.Encrypt(request.Mobile!);
                var param = new DynamicParameters();
                param.Add("@FullName", request.FullName);
                param.Add("@Email", request.Email);
                param.Add("@Mobile", request.Mobile);
                param.Add("@PasswordHash", passwordHash);
                param.Add("@IsActive", request.IsActive);
                param.Add("@CreatedBy", request.CreatedBy);
                param.Add("@Status", dbType: DbType.Int16, direction: ParameterDirection.Output);
                await _dapper.ExecuteAsync("dbo.usp_add_employee", param, CommandType.StoredProcedure);                
                var status = (ResultStatus)(param.Get<short?>("@Status") ?? -99);
                return ApiResponseMapper.Map(status, "Employee", CrudAction.Added);
            }
            catch (Exception ex)
            {
                return ApiExceptionHandler.Handle<object>(ex, _logger, "AddEmployee");
            } 
        }
        public async Task<ApiResponse<object>> UpdateEmployeeAsync(EmployeeMasterRequestDTO request)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ID", request.ID);
                param.Add("@FullName", request.FullName);
                param.Add("@Email", request.Email);
                param.Add("@Mobile", request.Mobile);
                param.Add("@IsActive", request.IsActive);
                param.Add("@UpdatedBy", request.UpdatedBy);
                param.Add("@Status", dbType: DbType.Int16, direction: ParameterDirection.Output);
                await _dapper.ExecuteAsync("dbo.usp_update_employee", param, CommandType.StoredProcedure);           
                var status = (ResultStatus)(param.Get<short?>("@Status") ?? -99);
                return ApiResponseMapper.Map(status, "Employee", CrudAction.Updated);
            }
            catch (Exception ex)
            {
                return ApiExceptionHandler.Handle<object>(ex, _logger, "UpdateEmployee");
            }
        }

        public async Task<ApiResponse<object>> DeleteEmployeeAsync(int id, int DeletedBy)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ID", id);
                param.Add("@DeletedBy", DeletedBy);
                param.Add("@Status", dbType: DbType.Int16, direction: ParameterDirection.Output);
                await _dapper.ExecuteAsync("dbo.usp_delete_employee", param, CommandType.StoredProcedure);
                var status = (ResultStatus)(param.Get<short?>("@Status") ?? -99);
                return ApiResponseMapper.Map(status, "Employee", CrudAction.Deleted);
            }
            catch (Exception ex)
            {
                return ApiExceptionHandler.Handle<object>(ex, _logger, "DeleteEmployee");
            }
        }
        public async Task<ApiResponse<EmployeeMasterRequestDTO?>> GetEmployeeByIdAsync(int id)
        {
            try
            {
                var data = await _dapper.QueryFirstOrDefaultAsync<EmployeeMasterRequestDTO?>("dbo.usp_get_employee_by_id", new { ID = id }, CommandType.StoredProcedure);
                if (data == null)
                {
                    return new ApiResponse<EmployeeMasterRequestDTO?>(-1, "Employee not found !!", null);
                }
                return new ApiResponse<EmployeeMasterRequestDTO?>(1, "Success", data);
            }
            catch (Exception ex)
            {
                return ApiExceptionHandler.Handle<EmployeeMasterRequestDTO?>(ex, _logger, "DeleteEmployee");
            }

        }
        public async Task<ApiResponse<List<EmployeeMasterResponseDTO>>> GetEmployeeListAsync()
        {
            try
            {
                var data = await _dapper.QueryAsync<EmployeeMasterResponseDTO>("dbo.usp_get_employee_list", null, CommandType.StoredProcedure);
                var list = data.ToList();
                list.EncryptIds();
                return new ApiResponse<List<EmployeeMasterResponseDTO>>(1, "Success", list);
            }
            catch (Exception ex)
            {
                return ApiExceptionHandler.Handle<List<EmployeeMasterResponseDTO>>(ex, _logger, "DeleteEmployee");
            }

        }
    }
}
