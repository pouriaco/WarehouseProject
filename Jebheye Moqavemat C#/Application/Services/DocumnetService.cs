using Application.Dtos.DocumnetDtos;
using Domain.Entities;
using Domain.Interfaces.IDocumnets;
using Domain.Interfaces.IProducts;
using Domain.Interfaces.IWarehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DocumnetService
    {
        private IDocumnetRepository _documnetRepository;
        //private IProductRepository _productRepository;
        //private IShelfRepository _shelfRepository;

        public DocumnetService(IDocumnetRepository documnetRepository)
        {
            _documnetRepository = documnetRepository;
        }
        public SerialDocumnetEntity RecordDocumentAndGenerateProducts(Plan1DocumnetDTO input)
        {
            return _documnetRepository.RecordDocumentAndGenerateProducts(input._ProductId , input._toShelfId , input._DocumnetDate);
        }
        public SerialDocumnetEntity RecordDocumnet(Plan2DocumnetDTO input)
        {
            return _documnetRepository.RecordDocumnet(input._SerialNumber, input._fromShelfId, input._toShelfId, input._DocumnetDate);
        }
        public DocumnetEntity ReverseDocumnet(int documnetId)
        {
            return _documnetRepository.ReverseDocumnet(documnetId);
        }
        public bool DeletDocumnet(int documnetId)
        {
            return _documnetRepository.DeletDocumnet(documnetId);
        }
        public IEnumerable<DocumnetEntity> GetDocumnetHistory(int warehouseId)
        {
            return _documnetRepository.GetDocumnetHistory(warehouseId);
        }



    }
}
