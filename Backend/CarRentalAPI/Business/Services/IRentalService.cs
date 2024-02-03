using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IRentalService
    {
        Task<RentalModel> RentCar(RentalModel model);
        Task<IEnumerable<RentalModel>> GetRentalAggrementByEmail(String email);
        Task<IEnumerable<RentalModel>> GetAllRentalAggrement();
        Task<RentalModel> GetRentalAgreementById(Guid id);
        Task DeleteRentalAgreementAsync(Guid id);
        Task UpdateRentalAgreementAsync(RentalModel model);
    }
}
