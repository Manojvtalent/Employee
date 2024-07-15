using Employee.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.DataAccess.IReosetories
{
    public interface IEMPReposetoroy
    {
        Task<List<employee>> GetAll();
        Task<int> InsertEmployee(employee emp);
        Task<int> UpdateEmployee(employee emp);
        Task<int> DeleteEmployee(int EmployeeNumber);
        Task<employee> GetEmployeeByEmpId(int EmployeeNumber);
    }
}
