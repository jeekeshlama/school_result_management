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
    
    public interface IManageMarksDetailRepository : IRepository<ManageMarksDetail>
    {
        Task<List<ManageMarksDetail>> GetAllMarksDetailAsync();
    }
    public class ManageMarksDetailRepository : Repository<ManageMarksDetail>, IManageMarksDetailRepository
    {
        public ManageMarksDetailRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<ManageMarksDetail>> GetAllMarksDetailAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
