using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboSchool;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.InfraStructure.Repository
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Task<List<Subject>> GetAllSubjectAsync();
    }
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Subject>> GetAllSubjectAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
