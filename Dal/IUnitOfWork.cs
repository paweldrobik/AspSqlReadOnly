using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSqlReadOnly.Lab.Dal
{
    public interface IUnitOfWork
    {
        IEmployeesRepository EmployeesRepository { get;  }
        //...more repo
    }
}
