using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PinArt.Core.Entities;
using PinArt.Core.Interfaces;
using PinArt.Infrastructure.Data;

namespace PinArt.Infrastructure.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly PinArtDbContext _context;

        public SecurityRepository(PinArtDbContext context)
        {
            _context = context;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin Login)
        {
            return await _context.Security.FirstOrDefaultAsync(x => x.UserName == Login.UserName && x.Password == Login.Password);
        }

        public void Add(Security security)
        {
            _context.Security.Add(security);
        }
    }
}
