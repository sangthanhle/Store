using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.BusinessLogic.Implement;
using OnlineStore.BusinessLogic.Service;
using OnlineStore.Cms.ViewModel;
using OnlineStore.Domain.Data;
using OnlineStore.Domain.DTO;

namespace OnlineStore.Cms.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // indext
        //public async Task<IActionResult> Index(int page = 1, int pageSize = 20)
        //{           
        //    var (products, totalProductCount) = await _productService.GetPagedAsync(page, pageSize);
        //    var productsVM = _mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductsVM>>(products);
        //    ViewBag.PageNumber = page;
        //    ViewBag.PageSize = pageSize;
        //    ViewBag.TotalPages = (int)Math.Ceiling((double)totalProductCount / pageSize);

        //    return View(productsVM);
        //}
        // search
        public async Task<IActionResult> Index(string searchString, int page = 1, int pageSize = 20)
        {
            var (products, totalProductCount) = await _productService.GetPagedAsync(page, pageSize);

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower().Trim(); // Chuyển chuỗi tìm kiếm về chữ thường và loại bỏ khoảng trắng
                products = products.Where(p => p.Name.ToLower().Replace(" ", "").Contains(searchString)).ToList();
            }

            var productsVM = _mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductsVM>>(products);
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalProductCount / pageSize);

            return View(productsVM);
        }
        //detail
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            var productVM = _mapper.Map<ProductDTO, ProductsVM>(product);

            return View(productVM);
        }
        // thêm mới
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create(ProductsVM model)
        {
            if (ModelState.IsValid)
            {
                var productDTO = _mapper.Map<ProductsVM, ProductDTO>(model);
                await _productService.AddProductAsync(productDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        // edit 
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            var productVM = _mapper.Map<ProductDTO, ProductsVM>(product);
            return View(productVM);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductsVM model)
        {
            if (ModelState.IsValid)
            {
                var productDTO = _mapper.Map<ProductsVM, ProductDTO>(model);
                await _productService.UpdateProductAsync(model.Id, productDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        //delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            var productVM = _mapper.Map<ProductDTO, ProductsVM>(product);

            return View(productVM);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
        // ISdelete
        //[HttpPost]
        //public async Task<IActionResult> SoftDeleteMultiple(int[] selectedProducts)
        //{
        //    foreach (var id in selectedProducts)
        //    {
        //        await _productService.DeleteProductAsync(id);
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

      
      

    }
}

