using DAL.Repository.Implementation;
using DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalAggrement rentalAggrement;
        public RentalService(IRentalAggrement rentalAggrement)
        {
            this.rentalAggrement = rentalAggrement;
        }
        public Task<RentalModel> RentCar(RentalModel model)
        {
            return rentalAggrement.RentCar(model);
        }
        public Task<IEnumerable<RentalModel>> GetRentalAggrementByEmail(String email)
        {
            return rentalAggrement.GetRentalAggrementByEmail(email);
        }
        public Task<IEnumerable<RentalModel>> GetAllRentalAggrement()
        {
            return rentalAggrement.GetAllRentalAggrement();
        }
        public Task<RentalModel> GetRentalAgreementById(Guid id)
        {
            return rentalAggrement.GetRentalAgreementById(id);
        }
        public Task DeleteRentalAgreementAsync(Guid id)
        {
            return rentalAggrement.DeleteRentalAgreementAsync((Guid)id);
        }
        public  Task UpdateRentalAgreementAsync(RentalModel model)
        {
            return rentalAggrement.UpdateRentalAgreementAsync(model);
        }

    }
}
