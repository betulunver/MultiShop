﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> List() 
        { 
            var values= await _discountService.GetAllCouponAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(int id)
        {
            var values =await _discountService.GetByIdCouponAsync(id);
            return Ok(values);  
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Kupon başarıyla oluşturuldu.");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _discountService.DeleteCouponAsync(id);
            return Ok("Kupon başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Kupon başarıyla güncellendi.");
        }

    }
}