using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Common.Model;

namespace MISA.eShopApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetShop()
        {
            var shopService = new ShopService();
            var serviceResult = shopService.GetShops();
            if(serviceResult.Data == null)
            {
                return StatusCode(204, serviceResult.Data);
            }else
                return StatusCode(200, serviceResult.Data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid? id)
        {
            var shopService = new ShopService();
            var serviceResult = shopService.GetShops(id);
            if (serviceResult.Data == null)
            {
                return StatusCode(204, serviceResult.Data);
            }
            else
                return StatusCode(200, serviceResult.Data);
        }
        [HttpPost]
        public IActionResult PostShop(Shop shop)
        {
            var shopService = new ShopService();
            var res = shopService.InsertShop(shop);
            if(res.Success == false)
            {
                return StatusCode(400, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }
  
        [HttpPut]
        public IActionResult Put(Shop shop)
        {
            var shopService = new ShopService();
            var res = shopService.UpdateShop(shop);
            if (res.Success == false)
            {
                return StatusCode(400, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }
        [HttpDelete]
        public IActionResult Delete(Guid ShopId)
        {
            var shopService = new ShopService();
            var res = shopService.DeleteShop(ShopId);
            if (res.Success == false)
                return StatusCode(400, res.Data);
            else
                return StatusCode(200, res.Data);
        }
    }
}
