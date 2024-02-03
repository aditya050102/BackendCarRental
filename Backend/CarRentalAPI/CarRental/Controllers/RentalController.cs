using DAL.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Business.Services;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService rentalService;
        private readonly ICarsService carsService;

        public RentalController(IRentalService rentalService, ICarsService carsService)
        {
            this.rentalService = rentalService;
            this.carsService = carsService;
        }

        [HttpPost]
        [Authorize(Roles ="User")]
        public async Task<IActionResult> CreateRentalAgreement([FromBody] RentalModel model)
        {
            try
            {
                var car = await carsService.GetCarByIdAsync(model.CarId);
                if (car == null)
                {
                    return BadRequest(new { Message = "Car not Found" });
                }
                if (!car.Availability)
                {
                    return BadRequest(new { Message = "Car not Available" });
                }
                var RentalPrice = car.RentalPrice;
                if (model.EndDate <= model.StartDate)
                {
                    return BadRequest(new { Message = "End Date Is greater than start date" });
                }
                var TotalDays = (model.EndDate - model.StartDate).Days;

                var rentalModel = new RentalModel
                {
                    Id = Guid.NewGuid(),
                    CarId = model.CarId,
                    Car = car.Maker,
                    UserEmail = model.UserEmail,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Amount = RentalPrice * TotalDays,
                    ReturnRequestStatus = "NotRequested"

                };

                await rentalService.RentCar(rentalModel);
                await carsService.ChangeAvailability(model.CarId);
                return Ok(rentalModel);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
           
        }

        [HttpGet("GetRentalAgreementByEmail")]
        [Authorize]
        public async Task<IActionResult> GetRentalAgreementByEmail(String email)
        {
            try
            {
                var RentalAgreement = await rentalService.GetRentalAggrementByEmail(email);
                return Ok(RentalAgreement);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
           
        }


        [HttpGet("GetAllRentalAgreements")]
        [Authorize]
        public async Task<IActionResult> GetAllRentalAgreements()
        {
            try
            {
                var rentalAgreements = await rentalService.GetAllRentalAggrement();
                return Ok(rentalAgreements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
          
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRentalAgreement(Guid id)
        {
            try
            {
                var rentalagreement = await rentalService.GetRentalAgreementById(id);
                if (rentalagreement == null)
                {
                    return NotFound(new { Message = "Not Found" });
                }
                await rentalService.DeleteRentalAgreementAsync(id);
                var carId = rentalagreement.CarId;
                await carsService.ChangeAvailability(carId);
                return Ok(rentalagreement);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
            
        }
        [HttpPut("RequestReturn/{id}")]
        [Authorize]
        public async Task<IActionResult> RequestReturn(Guid id)
        {
            try
            {
                var rentalAgreement = await rentalService.GetRentalAgreementById(id);
                if (rentalAgreement == null)
                {
                    return NotFound(new { Message = "Rental Agreement not found" });
                }

                rentalAgreement.ReturnRequestStatus = "Requested";
                await rentalService.UpdateRentalAgreementAsync(rentalAgreement);
                return Ok(new { Message = "Return Requested" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
           
        }

        [Authorize(Roles = "Admin")] 
        [HttpPut("ApproveReturn/{id}")]
        public async Task<IActionResult> ApproveReturn(Guid id)
        {
            try
            {
                var rentalAgreement = await rentalService.GetRentalAgreementById(id);
                if (rentalAgreement == null)
                {
                    return NotFound(new { Message = "Rental Agreement not found" });
                }


                await rentalService.DeleteRentalAgreementAsync(id);
                var carId = rentalAgreement.CarId;
                await carsService.ChangeAvailability(carId);

                rentalAgreement.ReturnRequestStatus = "Approved";


                return Ok(new { Message = "Return Approved" });
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
           
        }
    }
}
