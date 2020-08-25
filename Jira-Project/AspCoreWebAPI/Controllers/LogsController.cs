using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {

        private readonly ILogService _logService;

        public LogsController(ILogService logService)
        {
            _logService = logService;
        }


        [HttpGet("AddLogs")]
        public IActionResult AddLogs()
        {
            bool result = _logService.AddLogs();
            if (result)
                return Ok("Loglar Veritabanına Başarıyla Eklendi.");
            else
                return BadRequest("Loglar Veritabanına Eklenemedi.");

        }


        [HttpGet("GetLogs")]
        public IActionResult GetLogs()
        {
            try
            {
                return Ok(_logService.ListLogs());
            }
            catch
            {
                return BadRequest("Loglar Listelenemedi.");
            }
        }


        [HttpGet("ClearLogs")]
        public IActionResult ClearLogs()
        {
            bool result = _logService.ClearLogs();
            if (result)
                return Ok("Logs Tablosu Başarıyla Sıfırlandı.");
            else
                return BadRequest("Logs Tablosu Sıfırlanamadı.");
        }
    }
}
