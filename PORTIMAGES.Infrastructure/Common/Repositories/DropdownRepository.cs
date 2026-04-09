using PORTIMAGES.Application.Common.Interfaces;
using PORTIMAGES.Application.Common.Models;
using PORTIMAGES.Common.DTOs;
using PORTIMAGES.Infrastructure.Persistence; 
using System.Data; 

namespace PORTIMAGES.Infrastructure.Common.Repositories
{
    public class DropdownRepository : IDropdownRepository
    {
        private readonly IDapperRepository _dapper;

        public DropdownRepository(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<DropdownDTO>> GetAsync(string tableName,string valueField,string textField,string? filterField,int? filterValue,string? orderBy)
        {
            //var param = new DropdownConfig()
            //{
            //    TableName = tableName,
            //    ValueField = valueField,
            //    TextField = textField,
            //    FilterField = filterField,
            //    FilterValue = filterValue,
            //    OrderBy = orderBy
            //};
            //return await _dapper.QueryAsync<DropdownDTO>("usp_get_dropdown", dto,commandType: CommandType.StoredProcedure);
            return await _dapper.QueryAsync<DropdownDTO>("dbo.usp_get_dropdown", new
            {
                TableName = tableName,
                ValueField = valueField,
                TextField = textField,
                FilterField = filterField,
                FilterValue = filterValue,
                OrderBy = orderBy
            },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
