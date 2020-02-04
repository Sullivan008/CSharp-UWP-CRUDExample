using CRUDOperationsCommon.Dtos;
using log4net;
using System;
using System.Data.SqlClient;

namespace CRUDOperationsServer
{
    public class DbService : IDBService
    {
        private readonly ILog _log;

        public DbService()
        {
            _log = LogManager.GetLogger(typeof(DbService));
        }

        public bool InsertEmployee(EmployeeDto employee)
        {
            using (SqlConnection conn = ConnectToDb())
            {
                try
                {
                    SqlCommand comm = conn.CreateCommand();

                    comm.CommandText = "INSERT INTO Employee VALUES(@Name, @Age, @Email)";
                    comm.Parameters.AddWithValue("Name", employee.Name);
                    comm.Parameters.AddWithValue("Age", employee.Age);
                    comm.Parameters.AddWithValue("Email", employee.Email);
                    comm.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    return comm.ExecuteNonQuery() != 0;
                }
                catch (Exception ex)
                {
                    _log.Error($"++++ ERROR - Error while running INSERT SCRIPT! See more in Stack Trace: {ex.StackTrace}\n\n" +
                               $"See more in Inner Exception: {ex.InnerException}\n\nSee more in Message: {ex.Message}");

                    return false;
                }
            }
        }

        public bool UpdateEmployee(EmployeeDto employee)
        {
            using (SqlConnection conn = ConnectToDb())
            {
                try
                {
                    SqlCommand comm = conn.CreateCommand();

                    comm.CommandText = "UPDATE Employee SET Name=@Name, Age=@Age, Email=@Email WHERE ID=@ID";
                    comm.Parameters.AddWithValue("ID", employee.Id);
                    comm.Parameters.AddWithValue("Name", employee.Name);
                    comm.Parameters.AddWithValue("Age", employee.Age);
                    comm.Parameters.AddWithValue("Email", employee.Email);
                    comm.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    return comm.ExecuteNonQuery() != 0;
                }
                catch (Exception ex)
                {
                    _log.Error($"++++ ERROR - Error while running UPDATE SCRIPT! See more in Stack Trace: {ex.StackTrace}\n\n" +
                               $"See more in Inner Exception: {ex.InnerException}\n\nSee more in Message: {ex.Message}");

                    return false;
                }

            }
        }

        public bool DeleteEmployee(int id)
        {
            using (SqlConnection conn = ConnectToDb())
            {
                try
                {
                    SqlCommand comm = conn.CreateCommand();

                    comm.CommandText = "DELETE Employee Where id=@id";
                    comm.Parameters.AddWithValue("ID", id);
                    comm.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    return comm.ExecuteNonQuery() != 0;
                }
                catch (Exception ex)
                {
                    _log.Error($"++++ ERROR - Error while running DELETE SCRIPT! See more in Stack Trace: {ex.StackTrace}\n\n" +
                               $"See more in Inner Exception: {ex.InnerException}\n\nSee more in Message: {ex.Message}");

                    return false;
                }
            }
        }

        public EmployeeDto SelectOneEmployee(int id)
        {
            using (SqlConnection conn = ConnectToDb())
            {
                SqlCommand comm = conn.CreateCommand();

                EmployeeDto employee = new EmployeeDto();

                try
                {
                    comm.CommandText = "SELECT * FROM Employee Where ID=@ID";
                    comm.Parameters.AddWithValue("ID", id);
                    comm.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    SqlDataReader reader = comm.ExecuteReader();

                    while (reader.Read())
                    {
                        employee.Id = Convert.ToInt32(reader[0]);
                        employee.Name = reader[1].ToString();
                        employee.Age = Convert.ToInt32(reader[2]);
                        employee.Email = reader[3].ToString();
                    }

                    return employee;
                }
                catch (Exception ex)
                {
                    _log.Error($"++++ ERROR - Error while running SELECT SCRIPT! See more in Stack Trace: {ex.StackTrace}\n\n" +
                               $"See more in Inner Exception: {ex.InnerException}\n\nSee more in Message: {ex.Message}");

                    return null;
                }
            }
        }

        #region PRIVATE Helper Methods

        private static SqlConnection ConnectToDb() =>
            new SqlConnection(new SqlConnectionStringBuilder
            {
                DataSource = "(localDB)\\MSSQLLocalDB",
                InitialCatalog = "ServiceDB",
                TrustServerCertificate = true,
                ConnectTimeout = 30,
                AsynchronousProcessing = true,
                MultipleActiveResultSets = true,
                IntegratedSecurity = true
            }.ToString());

        #endregion
    }
}