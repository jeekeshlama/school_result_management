using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboSchool;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.InfraStructure.Repository
{
    public interface IManageMarksRepository : IRepository<ManageMarks>
    {
        Task<List<ManageMarks>> GetAllMarksAsync();
    }
    public class ManageMarksRepository : Repository<ManageMarks>, IManageMarksRepository
    {
        public ManageMarksRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<ManageMarks>> GetAllMarksAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
