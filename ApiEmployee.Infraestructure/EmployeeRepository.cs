using ApiEmployee.DataContrats;
using System;
using System.Linq;

namespace ApiEmployee.DataAccess
{
    public  class EmployeeRepository : RepositoryBase<EmployeeViewModel>, IEmployeeRepository
    {
        //private readonly RepositoryContext  _repositoryContext;
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
           // _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }

    }
}
