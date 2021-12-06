using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase {
        ICarImageService _carimageService;

        public CarImagesController(ICarImageService carimageService) {
            _carimageService = carimageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage) {
            var result = _carimageService.Add(file,carImage);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("CarImageId"))] int Id) {
            var carImage = _carimageService.Get(Id).Data;
            var result = _carimageService.Delete(carImage);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm(Name = ("CarImageId"))] int Id) {
            var carImage = _carimageService.Get(Id).Data;
            carImage.ImageDate = DateTime.Now;
            var result = _carimageService.Update(file,carImage);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll() {
            var result = _carimageService.GetAll();
            if (result.Success) {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getcarimagesbycarid")]
        public IActionResult GetCarImagesByCarId(int carid) {
            var result = _carimageService.GetCarImagesByCarId(carid);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
