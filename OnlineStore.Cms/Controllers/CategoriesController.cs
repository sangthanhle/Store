using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.BusinessLogic.Implement;
using OnlineStore.BusinessLogic.Service;
using OnlineStore.Cms.ViewModel;
using OnlineStore.Domain.Data;
using OnlineStore.Domain.DTO;

namespace OnlineStore.Cms.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesService categoriesService, IMapper mapper)
        {
            _categoriesService = categoriesService;
            _mapper = mapper;
        }  
        public async Task<IActionResult> Index(int page = 1, int pageSize = 20, string categoryName = null)
        {
            IEnumerable<CategorieDTO> categoriesDTO;
            int totalCategoryCount;

            if (!string.IsNullOrEmpty(categoryName))
            {
                // Nếu có tên danh mục được cung cấp, thực hiện tìm kiếm danh mục
                categoriesDTO = await _categoriesService.SearchCategoriesByNameAsync(categoryName);
                totalCategoryCount = categoriesDTO.Count();
                categoriesDTO = categoriesDTO.Skip((page - 1) * pageSize).Take(pageSize);
            }
            else
            {
                // Nếu không, hiển thị tất cả các danh mục
                (categoriesDTO, totalCategoryCount) = await _categoriesService.GetPagedAsync(page, pageSize);
            }

            var categoriesVM = _mapper.Map<IEnumerable<CategorieDTO>, IEnumerable<CategoriesVM>>(categoriesDTO);

            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCategoryCount / pageSize);

            return View("Index", categoriesVM);
        }


        // them moi
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriesVM model)
        {
            if (ModelState.IsValid)
            {
                var categorieDTO = _mapper.Map<CategoriesVM, CategorieDTO>(model);
                await _categoriesService.AddCategoryAsync(categorieDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        //edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoriesService.GetCategoryByIdAsync(id);
            var categoriesVM = _mapper.Map<CategorieDTO, CategoriesVM>(category);
            return View(categoriesVM);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoriesVM model)
        {
            if (ModelState.IsValid)
            {
                var categoriesDTO = _mapper.Map<CategoriesVM, CategorieDTO>(model); // Chỉnh sửa ở đây
                await _categoriesService.UpdateCategoryAsync(model.Id, categoriesDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
    }
