using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Interface;

namespace Business.Services
{
    public interface ICarsService
    {
        Task<CarDetails> CreateAsync(CarDetails carDetails);
        Task<IEnumerable<CarDetails>> GetAllCarsAsync();

        Task<CarDetails> GetCarByIdAsync(Guid id);
        Task UpdateCarAsync(CarDetails carDetails);

        Task DeleteCarAsync(Guid id);
        Task ChangeAvailability(Guid id);
    }
}
