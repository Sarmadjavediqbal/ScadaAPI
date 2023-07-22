using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScadaAPI.Models;
using System;

namespace ScadaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScadaSensorLogController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private int sensorID;
        private decimal sensorData;

        public int SensorLogID { get; internal set; }

        public ScadaSensorLogController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SCADA_SensorLog>>> GetData()
        {
            if (_dbContext.sCADA_SensorLog == null)
            {
                return NotFound();
            }

            return await _dbContext.sCADA_SensorLog.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> AddData(List<SCADA_SensorLog> data)
        {
            List<SCADA_SensorLog> properties = new List<SCADA_SensorLog>();
            foreach(var item in properties)
            {
                try
                {
                    if (SensorLogID != 0)
                    {
                        var sensorDataLog = new SCADA_SensorLog(

                        properties.Select(x => x.SensorID = sensorID),
                        properties.Select(x => x.SensorData = sensorData)
                        );
                        _dbContext.sCADA_SensorLog.Add(item);
                    }
                }
                catch(Exception ex)
                {
                    throw new ArgumentNullException();
                }
            }

            _dbContext.sCADA_SensorLog.AddRange(data);

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(AddData), new { SensorLogId = data.Select(x => x.SensorLogID).ToList() }, data);
        }
    }
}
