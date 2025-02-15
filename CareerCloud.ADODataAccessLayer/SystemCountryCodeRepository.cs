using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemCountryCodeRepository : IDataRepository<SystemCountryCodePoco>
    {
        private SqlConnection conn;
        protected readonly string _connectionString = string.Empty;

        public SystemCountryCodeRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params SystemCountryCodePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (SystemCountryCodePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into System_Country_Codes (Code,Name)" +
                      "values(@cd,@na)";

                cmd.Parameters.AddWithValue("@cd", tc.Code);
                cmd.Parameters.AddWithValue("@na", tc.Name);


                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IList<SystemCountryCodePoco> data = new List<SystemCountryCodePoco>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM System_Country_Codes", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SystemCountryCodePoco poco = new SystemCountryCodePoco()
                            {
                                Code = reader["Code"] as string,
                                Name = reader["Name"] as string
                            };

                            data.Add(poco);
                        }
                    }
                }
            }
            return data;
        }

        public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemCountryCodePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (SystemCountryCodePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@cd", tc.Code);
                cmd.CommandText = @"Delete from System_Country_Codes where @cd = Code";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (SystemCountryCodePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update System_Country_Codes SET  Name = @na  where @cd = Code";

                cmd.Parameters.AddWithValue("@cd", tc.Code);
                cmd.Parameters.AddWithValue("@na", tc.Name);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
