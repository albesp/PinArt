using System.Threading.Tasks;
using PinArt.Core.Entities;

namespace PinArt.Core.Interfaces
{
    public interface ISecurityRepository
    {
        Task<Security> GetLoginByCredentials(UserLogin Login);
        void Add(Security security);
    }
}
