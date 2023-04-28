using test.Migrations;
using test.Repository.Base;

namespace TestCoreApp.Repository.Base
{
    public interface IEmpRepo : IRepository<Employees>
    {
        void setPayRoll(Employees employee);

        decimal getSalary(Employees employee);
    }
}