using PinArt.Core.Entities;
using PinArt.Core.Interfaces;
using System.Threading.Tasks;

namespace Vidly.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _UoW;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            _UoW = unitOfWork;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _UoW.Security.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(Security security)
        {
            _UoW.Security.Add(security);
            await _UoW.CompleteAsync();
        }
    }
}

