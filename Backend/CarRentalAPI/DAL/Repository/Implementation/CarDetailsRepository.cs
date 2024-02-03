using DAL.Data;
using DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Implementation
{
    public class CarDetailsRepository : ICarDetailsRepository
    {
        private readonly CarRentalDbContext dbContext;

        public CarDetailsRepository( CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public  async Task ChangeAvailability(Guid id)
        {
            var car=await dbContext.CarDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (car != null)
            {
                car.Availability = !car.Availability;
                await dbContext.SaveChangesAsync();
            }

             
        }

        public async Task<CarDetails> CreateAsync(CarDetails carDetails)
        {
            await dbContext.CarDetails.AddAsync(carDetails);

            await dbContext.SaveChangesAsync();

            return carDetails;
        }

       public async Task DeleteCarAsync(Guid id)
       {
            var car = await dbContext.CarDetails.FindAsync(id);
            if (car != null)
            {
                dbContext.CarDetails.Remove(car);
                await dbContext.SaveChangesAsync();
            }
       }
     
        public async Task<IEnumerable<CarDetails>> GetAllCarsAsync()
        {
            return await dbContext.CarDetails.ToListAsync();
        }

        public async Task<CarDetails> GetCarByIdAsync(Guid id)
        {
            return await dbContext.CarDetails.FirstOrDefaultAsync(p => p.Id == id);
        }
         
        public async Task UpdateCarAsync(CarDetails carDetails)
        {
            dbContext.CarDetails.Update(carDetails);
            await dbContext.SaveChangesAsync();
        }

           
    }
}
