using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboSchool;
using Microsoft.EntityFrameworkCore;

namespace FiboSchool.InfraStructure.Repository
{
   public interface ITermRepository : IRepository<Term>
    {
        Task<List<Term>> GetAllTermAsync();
    }
    public class TermRepository : Repository<Term>, ITermRepository
    {
        public TermRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Term>> GetAllTermAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}

