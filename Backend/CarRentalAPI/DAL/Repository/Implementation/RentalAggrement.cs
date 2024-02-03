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
    public class RentalAggrement : IRentalAggrement
    {
        private readonly CarRentalDbContext dbContext;

        public RentalAggrement( CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task DeleteRentalAgreementAsync(Guid id)
        {
            var rentalagreement=await dbContext.RentalAggrements.FirstOrDefaultAsync(r => r.Id == id);
            if (rentalagreement != null)
            {
                dbContext.Remove(rentalagreement);
                await dbContext.SaveChangesAsync();
            }
            
        }

        public async Task<IEnumerable<RentalModel>> GetAllRentalAggrement()
        {
            return await dbContext.RentalAggrements.ToListAsync();
        }

        public async Task<IEnumerable<RentalModel>> GetRentalAggrementByEmail(string email)
        {
            var RentalAgreements = await dbContext.RentalAggrements.Where(x => x.UserEmail == email).ToListAsync();
            return RentalAgreements;
        }

        public async Task<RentalModel> GetRentalAgreementById(Guid id)
        {
            var rentalagreement=await dbContext.RentalAggrements.FirstOrDefaultAsync(x=>x.Id == id);
            return rentalagreement;
        }

        public async Task<RentalModel> RentCar(RentalModel model)
        {
            await this.dbContext.RentalAggrements.AddAsync(model);
            await this.dbContext.SaveChangesAsync();
            return model;
        }
        public async Task UpdateRentalAgreementAsync(RentalModel model)
        {
            dbContext.Entry(model).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
