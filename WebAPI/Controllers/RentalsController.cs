using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService) {
            _rentalService = rentalService;
        }
        [HttpPost("add")]
        public IActionResult Add(RentCarDto rentCarDto) {
            var result = _rentalService.Add(rentCarDto.Rental, rentCarDto.CreditCard);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Rental rental) {
            var result = _rentalService.Delete(rental);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Rental rental) {
            var result = _rentalService.Update(rental);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult Get(int id) {
            var result = _rentalService.Get(id);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll() {
            Thread.Sleep(500);

            var result = _rentalService.GetAll();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getrentaldetaildto")]
        public IActionResult GetRentalDetailDto() {

            var result = _rentalService.GetRentalDetailDto();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getoccupieddates")]
        public IActionResult GetEmptyDates(int carId) {
            var result = _rentalService.GetOccupiedDates(carId);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetRentalDetailDtoByUserId")]
        public IActionResult GetRentalDetailDtoByUserId(int userid) {
            var result = _rentalService.GetRentalDetailDtoByUserId(userid);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
