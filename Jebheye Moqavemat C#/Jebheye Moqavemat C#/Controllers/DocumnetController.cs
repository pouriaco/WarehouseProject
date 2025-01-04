using Application.Dtos.DocumnetDtos;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces.IDocumnets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jebheye_Moqavemat_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumnetController : ControllerBase
    {
        private DocumnetService _service;
        public DocumnetController(IDocumnetRepository service)
        {
            _service = new DocumnetService(service);
        }
        [HttpPost("RecordDocumentAndGenerateSrial")]
        public SerialDocumnetEntity RecordDocumentAndGenerateProducts(Plan1DocumnetDTO input) => _service.RecordDocumentAndGenerateProducts(input);

        [HttpPost("RecordDocumnet")]
        public SerialDocumnetEntity RecordDocumnet(Plan2DocumnetDTO input) => _service.RecordDocumnet(input);

        [HttpGet("ReverseDocumnet")]
        public DocumnetEntity ReverseDocumnet(int documnetId) => _service.ReverseDocumnet(documnetId);

        [HttpDelete("DeleteDocumnet/{documnetId}")]
        public bool DeletDocumnet(int documnetId) => _service.DeletDocumnet(documnetId);

        [HttpGet("GetDocumnetHistory/{warehouseId}")]
        public IEnumerable<DocumnetEntity> GetDocumnetHistory(int warehouseId) => _service.GetDocumnetHistory(warehouseId);

    }
}
