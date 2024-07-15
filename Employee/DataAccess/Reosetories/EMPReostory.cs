using Employee.DataAccess.IReosetories;
using Employee.Dbcontext;
using Employee.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.DataAccess.Reosetories
{
    public class EMPReostory:IEMPReposetoroy
    {

        public projectDBcontext db;
        public EMPReostory(projectDBcontext _db)
        {
            this.db = _db;
        }

        public async Task<int> DeleteEmployee(int EmployeeNumber)
        {
            var Emp = db.Employess.Find(EmployeeNumber);
            db.Employess.Remove(Emp);
            return await db.SaveChangesAsync();
        }

        public async Task<List<employee>> GetAll()
        {
            return await db.Employess.ToListAsync();
        }

        public async Task<employee> GetEmployeeByEmpId(int EmployeeNumber)
        {
            return await db.Employess.FindAsync(EmployeeNumber);


        }

        public async Task<int> InsertEmployee(employee emp)
        {
            await db.Employess.AddAsync(emp);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateEmployee(employee emp)
        {

            db.Employess.Update(emp);
            return await db.SaveChangesAsync();
        }
    }
}
