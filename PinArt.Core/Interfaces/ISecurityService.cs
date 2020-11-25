using PinArt.Core.Entities;
using System.Threading.Tasks;

namespace PinArt.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);

        Task RegisterUser(Security security);
    }
}