using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Interface;
using Shared.Models;

namespace Business.Services
{
 
    public  class CarsService:ICarsService
    {
        private readonly ICarDetailsRepository carDetailsRepository;
        public CarsService(ICarDetailsRepository carDetailsRepository)
        {
            this.carDetailsRepository = carDetailsRepository;
        }
        public Task<CarDetails> CreateAsync(CarDetails carDetails)
        {
            return carDetailsRepository.CreateAsync(carDetails);
        }
        public Task<IEnumerable<CarDetails>> GetAllCarsAsync()
        {
            return carDetailsRepository.GetAllCarsAsync();
        }

        public Task<CarDetails> GetCarByIdAsync(Guid id)
        {
             return carDetailsRepository.GetCarByIdAsync(id);
        }
        public Task UpdateCarAsync(CarDetails carDetails)
        {
             return carDetailsRepository.UpdateCarAsync(carDetails);
        }

        public Task DeleteCarAsync(Guid id)
        {
            return carDetailsRepository.DeleteCarAsync(id);
        }
        public Task ChangeAvailability(Guid id)
        {
            return carDetailsRepository.ChangeAvailability(id);
        }

    }
}
