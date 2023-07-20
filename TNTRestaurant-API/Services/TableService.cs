using System.Collections.Generic;
using System.Threading.Tasks;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Repositories;

namespace TNTRestaurant_API.Services
{
    public interface ITableService
    {
        Task<List<TableModel>> GetList();
        Task InsertUpdate(TableModel table);
    }

    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<List<TableModel>> GetList()
        {
            return await _tableRepository.GetList();
        }

        public async Task InsertUpdate(TableModel table)
        {
            await _tableRepository.InsertUpdate(table);
        }
    }
}
