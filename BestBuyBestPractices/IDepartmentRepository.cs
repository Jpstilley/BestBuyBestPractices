using System;
using System.Collections.Generic;

namespace BestBuyBestPractices
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();

        public void InsertDepartment(string newDepartmentName);
    }

    

}
