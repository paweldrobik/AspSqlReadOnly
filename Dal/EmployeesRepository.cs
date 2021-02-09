using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AppSqlReadOnly.Lab.Dal
{
    public class EmployeesRepository : Repository, IEmployeesRepository
    {
        public EmployeesRepository(IDbConnection connection, ISqlQueries sqlQueries)
            : base(connection, sqlQueries, nameof(EmployeesRepository))
        {
        }


        public async Task<IEnumerable<EmployeeDao>> GetAllAsync()
        {
            return await Connection.QueryAsync<EmployeeDao>(GetSqlQuery());
        }

        public async Task<EmployeeDao> GetAsync(int id)
        {
            return await Connection.QueryFirstOrDefaultAsync<EmployeeDao>(GetSqlQuery(), new EmployeeDao { Id = id });
        }

        public async Task<IEnumerable<EmployeeDao>> GetByCityAsync(string city)
        {
            return await Connection.QueryAsync<EmployeeDao>(GetSqlQuery(), new EmployeeDao { City = city });
        }
    }
}
