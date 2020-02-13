using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using WebAPIDemowithEF1.Entities;
namespace WebAPIDemowithEF1.Repositories
{
    public class EmployeeRepository
    {
        private readonly string cnnString = @"Data Source=bhavin;Initial Catalog=LearningDB;User ID=sa;Password=sa123_!@#";
        public List<Employee> GetEmployees()
        {
             using (SqlConnection Db= new SqlConnection(cnnString))
             {
                var result = Db.Query<Employee>("Select * From Employee");
                return result.ToList();
             }
        }
    }
}
