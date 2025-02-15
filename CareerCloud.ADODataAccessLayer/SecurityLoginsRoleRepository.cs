using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{

    public class SecurityLoginsRoleRepository : IDataRepository<SecurityLoginsRolePoco>
    {
        private SqlConnection conn;
        protected readonly string _connectionString = string.Empty;

        public SecurityLoginsRoleRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params SecurityLoginsRolePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (SecurityLoginsRolePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Security_Logins_Roles (Id,Login,Role)" +
                      "values(@id,@lg,@rl)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@lg", tc.Login);
                cmd.Parameters.AddWithValue("@rl", tc.Role);
              

                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            IList<SecurityLoginsRolePoco> data = new List<SecurityLoginsRolePoco>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Security_Logins_Roles", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SecurityLoginsRolePoco poco = new SecurityLoginsRolePoco()
                            {
                                Id = (Guid)reader["Id"],
                                Login = (Guid)reader["Login"],
                                Role = (Guid)reader["Role"],
                                

                                TimeStamp = (byte[])reader["Time_Stamp"]
                              
                            };

                            data.Add(poco);
                        }
                    }
                }
            }
            return data;
        }

        public IList<SecurityLoginsRolePoco> GetList(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsRolePoco GetSingle(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsRolePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsRolePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (SecurityLoginsRolePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Security_Logins_Roles where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params SecurityLoginsRolePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (SecurityLoginsRolePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Security_Logins_Roles SET Login = @lg, " +
                    " Role = @rl   where @id = Id";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@lg", tc.Login);
                cmd.Parameters.AddWithValue("@rl", tc.Role);


                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
