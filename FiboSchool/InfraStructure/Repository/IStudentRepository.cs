using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiboInfraStructure.Entity.FiboSchool;

namespace FiboSchool.InfraStructure.Repository
{
   
    public interface IStudentRepository : IRepository<Student>
    {
        Task<List<Student>> GetAllStudentAsync();
    }
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await GetAllAsync().ToListAsync();
        }
    }
}
