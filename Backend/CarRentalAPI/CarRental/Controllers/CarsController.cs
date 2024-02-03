using Business.Services;
using DAL.Data;
using DAL.Repository.Implementation;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
namespace CarRental.Controllers
{
  

    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService carsService;

        public CarsController(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostCar(CarDetails postCar)
        {
            try
            {
                var carDetail = new CarDetails
                {
                    Id = Guid.NewGuid(),
                    Maker = postCar.Maker,
                    Model = postCar.Model,
                    RentalPrice = postCar.RentalPrice,
                    Availability = true,
                };

                await carsService.CreateAsync(carDetail);

                return Ok(carDetail);

            }
            catch (Exception ex) { 
                return StatusCode(500, ex.Message);
            
            }
            
            
            
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            try
            {
                var cars = await carsService.GetAllCarsAsync();
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
           
        }

        [Authorize]
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCar([FromRoute] Guid id)
        {
            try
            {
                var car = await carsService.GetCarByIdAsync(id);
                if (car == null)
                {
                    return NotFound();
                }
                return Ok(car);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
           
        }

        [Authorize(Roles ="Admin")]
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCar([FromRoute] Guid id,CarDetails carDetails)
        {
            try
            {
                var car = await carsService.GetCarByIdAsync(id);
                if (car == null)
                {
                    return NotFound();
                }
                car.Maker = carDetails.Maker;
                car.Model = carDetails.Model;
                car.RentalPrice = carDetails.RentalPrice;
                car.Availability = carDetails.Availability;

                await carsService.UpdateCarAsync(car);
                return Ok(car);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
            
        }

         [Authorize(Roles ="Admin")]
         [HttpDelete]
         [Route("{id:Guid}")]
         public async Task<IActionResult> DeleteCar([FromRoute] Guid id)
        {
            try
            {
                var car = await carsService.GetCarByIdAsync(id);
                if (car == null)
                {
                    return NotFound();
                }
                await carsService.DeleteCarAsync(id);
                return Ok(car);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
           
         }
             
    }
}
