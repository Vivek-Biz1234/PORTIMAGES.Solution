using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
using PORTIMAGES.Application.Products.DTOs;
using PORTIMAGES.Application.Products.Interfaces;
using PORTIMAGES.Common.Helpers; 
using System.Security.Claims;

namespace PORTIMAGES.Web.Controllers.Admin
{
    [Authorize(Roles = "Admin,Staff")]
    [Authorize(AuthenticationSchemes = "StaffScheme")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductFilesRepository _productFilesRepository;
        public ProductController(IProductRepository productRepository, IProductFilesRepository productFilesRepository)
        {
            this._productRepository = productRepository;
            _productFilesRepository = productFilesRepository;   
        }

        #region Product Master

        public IActionResult AddProductByDocs()
        {
            return View();
        }
        public IActionResult AddProductAdditionalInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAdditionalInfo([FromBody] AddProductRequestDTO dto)
        {
            dto.CreatedBy = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _productRepository.AddProductAsync(dto);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductAdditionalInfo([FromBody] AddProductRequestDTO dto)
        {
            dto.UpdatedBy = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            dto.ID = long.Parse(CryptoHelper.Decrypt(dto.EncID));

            var result = await _productRepository.UpdateProductAsync(dto);
            return Json(result);
        }

        public IActionResult ViewProducts()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var result = await _productRepository.GetProductListAsync();
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByEncId(string pid)
        {
            var id = long.Parse(CryptoHelper.Decrypt(pid));
            var response = await _productRepository.GetProductByIdAsync(id);
            return Json(response);
        } 
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(string pid)
        {
            int deletedBy = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var id = long.Parse(CryptoHelper.Decrypt(pid));
            var result = await _productRepository.DeleteProductAsync(id, deletedBy);
            return Json(result);
        }

        #endregion

        #region Product Files
        public IActionResult UploadImage()
        {             
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> AddProductImage([FromForm] UploadProductImageRequesDTO request)
        {
            request.ProductId = long.Parse(CryptoHelper.Decrypt(request.EncID));
            request.CreatedBy = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _productFilesRepository.AddProductImageAsync(request);
            return Json(result);             
        }

        [HttpGet]
        public async Task<IActionResult> GetProductImages(string pid)
        {
            long productId = long.Parse(CryptoHelper.Decrypt(pid));
            var res = await _productFilesRepository.GetProductImagesAsync(productId);
            return Json(res);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteProductImage(string pid)
        {
            int deletedBy = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            long imageid = long.Parse(pid);
            var result = await _productFilesRepository.DeleteProductImageAsync(imageid, deletedBy);
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductInnerDetails(string pid)
        {
            long productId = long.Parse(CryptoHelper.Decrypt(pid));
            var res = await _productFilesRepository.GetProductInnerDetailsAsync(productId);
            return Json(res);
        }

        #endregion
    }
}
