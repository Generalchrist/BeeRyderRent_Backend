﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
    public class CarsController : ControllerBase {
        ICarService _carService;

        public CarsController(ICarService carService) {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() {
            Thread.Sleep(500);

            var result = _carService.GetAll();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetCarDetailsDto")]
        public IActionResult GetCarDetailDto() {
            var result = _carService.GetCarDetailsDto();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetCarsModelYears")]
        public IActionResult GetCarsModelYears() {
            var result = _carService.GetCarsModelYears();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetCarsModels")]
        public IActionResult GetCarsModels() {
            var result = _carService.GetCarsModels();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("GetFilteredCars")]
        public IActionResult GetFilteredCars(FilterOptions filter) {
            var result = _carService.GetFilteredCars(filter);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetCarDetailDto")]
        public IActionResult GetCarDetailDto(int id) {
            var result = _carService.GetCarDetailDto(id);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int colorId) {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int brandId) {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getcarsbydailyprice")]
        public IActionResult GetCarsByDailyPrice(int min, int max) {
            var result = _carService.GetCarsByDailyPrice(min, max);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Car car) {
            var result = _carService.Add(car);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car) {
            var result = _carService.Delete(car);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Car car) {
            var result = _carService.Update(car);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
