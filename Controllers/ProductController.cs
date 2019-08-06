using System;
using System.Threading.Tasks;
using AspDotnetCoreGenericRepository.Models;
using AspDotnetCoreGenericRepository.Repository;
using AspDotnetCoreGenericRepository.ViewModel;
using AutoMapper;
using ClientNotifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static ClientNotifications.Helpers.NotificationHelper;

namespace AspDotnetCoreGenericRepository.Controllers
{
    public class ProductController : BaseController<Product>
    {
        private readonly IProductRepository _repository;

        private readonly UserManager<ApplicationUser> _usermanager;

        private readonly IMapper _mapper;
        public ProductController(IClientNotification clientNotification, IProductRepository repository, IMapper mapper, UserManager<ApplicationUser> usermanager) : base(clientNotification)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._usermanager = usermanager;
        }

        public async Task<IActionResult> Index()
        {
             var products = await _repository.FindAllAsync();
            return View(products);
        }

        public IActionResult New()
        {
            return View(new ProductVM());
        }

        [HttpPost]
        public async Task<IActionResult> New(ProductVM model)
        {
            try{
                if(!ModelState.IsValid)
                    return View(model);
            var product = _mapper.Map<Product>(model);
            product.ApplicationUserId =_usermanager.GetUserId(HttpContext.User); 
            if(model.IsEdit.Equals("false")){
                await  Create(product,"Product",_repository);
            }else{
                await Update(product,"Product",_repository);
            }
            }catch(Exception)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
                var data = await _repository.FindSingleAsync(x => x.Id == Id);
                var products = _mapper.Map<ProductVM>(data);
                products.IsEdit = "true";
                return View(nameof(New),products);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _repository.FindSingleAsync(x => x.Id == Id);
            await Remove(data,"Product",_repository);
            return RedirectToAction(nameof(Index));
           
        }

        
    }
}