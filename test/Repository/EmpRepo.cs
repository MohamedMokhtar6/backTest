using test.Data;
using test.Migrations;
using test.Repository;
using TestCoreApp.Repository.Base;

namespace TestCoreApp.Repository
{
    public class EmpRepo : MainRepository<Employees>, IEmpRepo
    {
        public EmpRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        public decimal getSalary(Employees employee)
        {
            throw new NotImplementedException();
        }

        public void setPayRoll(Employees employee)
        {
            throw new NotImplementedException();
        }
    }
}