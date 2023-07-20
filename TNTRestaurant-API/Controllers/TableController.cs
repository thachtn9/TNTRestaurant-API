using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Services;

namespace TNTRestaurant_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TableModel>>> GetTables()
        {
            var tables = await _tableService.GetList();
            return Ok(tables);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUpdateTable(TableModel table)
        {
            await _tableService.InsertUpdate(table);
            return Ok();
        }
    }
}
