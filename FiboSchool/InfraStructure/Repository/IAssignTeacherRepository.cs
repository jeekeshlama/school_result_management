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
    public interface IAssignTeacherRepository : IRepository<AssignTeacher>
    {
        Task<List<AssignTeacher>> GetAllAssignTeacherAsync();
    }
    public class AssignTeacherRepository : Repository<AssignTeacher>, IAssignTeacherRepository
    {
        public AssignTeacherRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<AssignTeacher>> GetAllAssignTeacherAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}

