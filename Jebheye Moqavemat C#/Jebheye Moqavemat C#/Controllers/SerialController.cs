using Application.Services;
using Domain.Entities;
using Domain.Interfaces.IProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Jebheye_Moqavemat_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerialController : ControllerBase
    {
        private SerialService _serialService;
        public SerialController (ISerialRepository serialService)
        {
            _serialService = new SerialService(serialService);
        }
        [HttpPost("CreateSerial")]
        public SerialEntity CreateSerial(int productId) => _serialService.CreateSerial(productId);

        [HttpGet("GetBySerial/{serialId}")]
        public SerialEntity GetSerialById(int serialId) => _serialService.GetSerialById(serialId);

        [HttpDelete("DeleteSerial/{serialId}")]
        public bool DeleteSerial(int serialId) => _serialService.DeleteSerial(serialId);

        [HttpGet("GetAllSerial")]
        public IEnumerable<SerialEntity> GetAllSerials() => _serialService.GetAllSerials();


    }
}
