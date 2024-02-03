using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface ICarDetailsRepository
    {
        Task<CarDetails> CreateAsync(CarDetails carDetails);
        Task<IEnumerable<CarDetails>> GetAllCarsAsync();

        Task<CarDetails> GetCarByIdAsync(Guid id);
        Task UpdateCarAsync(CarDetails carDetails);

        Task DeleteCarAsync(Guid id);
        Task ChangeAvailability(Guid id);
    }
}
