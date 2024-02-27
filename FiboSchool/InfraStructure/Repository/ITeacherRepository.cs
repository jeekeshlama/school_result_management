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
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<List<Teacher>> GetAllTeacherAsync();
    }
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Teacher>> GetAllTeacherAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}

