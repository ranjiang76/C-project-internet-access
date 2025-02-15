using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemLanguageCodeRepository : IDataRepository<SystemLanguageCodePoco>
    {
        private SqlConnection conn;
        protected readonly string _connectionString = string.Empty;

        public SystemLanguageCodeRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params SystemLanguageCodePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (SystemLanguageCodePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into System_Language_Codes (LanguageID,Name,Native_Name)" +
                      "values(@ld,@na,@nn)";

                cmd.Parameters.AddWithValue("@ld", tc.LanguageID);
                cmd.Parameters.AddWithValue("@na", tc.Name);
                cmd.Parameters.AddWithValue("@nn", tc.NativeName);

                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IList<SystemLanguageCodePoco> data = new List<SystemLanguageCodePoco>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM System_Language_Codes", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SystemLanguageCodePoco poco = new SystemLanguageCodePoco()
                            {
                                LanguageID = reader["LanguageID"] as string,
                                Name = reader["Name"] as string,
                                NativeName = reader["Native_Name"] as string,
  
                            };

                            data.Add(poco);
                        }
                    }
                }
            }
            return data;
        }

        public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (SystemLanguageCodePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@lg", tc.LanguageID);
                cmd.CommandText = @"Delete from System_Language_Codes where @lg = LanguageID";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (SystemLanguageCodePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update System_Language_Codes SET LanguageID = @lg, " +
                    " Name = @na, Native_Name = @nn where @lg = LanguageID";

                cmd.Parameters.AddWithValue("@lg", tc.LanguageID);
                cmd.Parameters.AddWithValue("@na", tc.Name);
                cmd.Parameters.AddWithValue("@nn", tc.NativeName);


                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
