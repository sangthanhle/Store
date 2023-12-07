using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.BusinessLogic.Implement;
using OnlineStore.BusinessLogic.Service;
using OnlineStore.Cms.ViewModel;
using OnlineStore.Domain.Data;
using OnlineStore.Domain.DTO;
using System.Drawing.Printing;

namespace OnlineStore.Cms.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 20)
        {
            var (users, totalUserCount) = await _userService.GetPagedAsync(page, pageSize);
            var userVM = _mapper.Map<IEnumerable<UserDTO>, IEnumerable<UsersVM>>(users);
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalUserCount / pageSize);

          return View(userVM);
        }

}
}
