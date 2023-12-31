using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Database.EF;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using TNTRestaurant_API.Models;

namespace TNTRestaurant_API.Repositories
{
    public interface ITableRepository
    {
        Task<List<RestaurantModel>> GetList();
        Task<int> InsertUpdate(TableModel table);
    }

    public class TableRepository : ITableRepository
    {
        private readonly MyBDContext _context;
        private readonly IMapper _mapper;

        public TableRepository(MyBDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RestaurantModel>> GetList()
        {
           // var data = await _context.Tables!.Include(t => t.Restaurant).ToListAsync();
            var data = await _context.Restaurants!.Include(t => t.Tables).ToListAsync();
            return _mapper.Map<List<RestaurantModel>>(data);
        }

        public async Task<int> InsertUpdate(TableModel tableModel)
        {

            try
            {
                var table = _mapper.Map<Table>(tableModel);
                if (table.TableID == 0)
                {
                    _context.Tables.Add(table);
                }
                else
                {
                    _context.Tables.Update(table);
                }

                await _context.SaveChangesAsync();
                return table.TableID;
            }
            catch (Exception ex) {
                return 0;
            }
           
        }
    }
}
