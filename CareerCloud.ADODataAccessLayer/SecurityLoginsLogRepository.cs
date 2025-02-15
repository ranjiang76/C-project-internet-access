using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginsLogRepository : IDataRepository<SecurityLoginsLogPoco>
    {
        private SqlConnection conn;
        protected readonly string _connectionString = string.Empty;

        public SecurityLoginsLogRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (SecurityLoginsLogPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Security_Logins_Log (Id,Login,Source_IP,Logon_Date,Is_Succesful)" +
                      "values(@id,@lg,@si,@ld,@is)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@lg", tc.Login);
                cmd.Parameters.AddWithValue("@si", tc.SourceIP);
                cmd.Parameters.AddWithValue("@ld", tc.LogonDate);
                cmd.Parameters.AddWithValue("@is", tc.IsSuccesful);

                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IList<SecurityLoginsLogPoco> data = new List<SecurityLoginsLogPoco>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Security_Logins_Log", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SecurityLoginsLogPoco poco = new SecurityLoginsLogPoco()
                            {
                                Id = (Guid)reader["Id"],
                                Login = (Guid)reader["Login"],
                                SourceIP = reader["Source_IP"] as string,
                                LogonDate = (DateTime)reader["Logon_Date"],
                                IsSuccesful = (bool)reader["Is_Succesful"]

                            };
              
                            data.Add(poco);
                        }
                    }
                }
            }
            return data;
        }

        public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (SecurityLoginsLogPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Security_Logins_Log where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (SecurityLoginsLogPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Security_Logins_Log SET Login = @lg, " +
                    " Source_IP = @si, Logon_Date = @ld ,Is_Succesful =@is" +
                    " where @id = Id";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@lg", tc.Login);
                cmd.Parameters.AddWithValue("@si", tc.SourceIP);
                cmd.Parameters.AddWithValue("@ld", tc.LogonDate);
                cmd.Parameters.AddWithValue("@is", tc.IsSuccesful);

                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
