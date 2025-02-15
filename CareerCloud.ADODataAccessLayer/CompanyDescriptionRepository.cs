using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyDescriptionRepository : IDataRepository<CompanyDescriptionPoco>
    {
        private SqlConnection conn;
        protected readonly string _connectionString = string.Empty;

        public CompanyDescriptionRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params CompanyDescriptionPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (CompanyDescriptionPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Company_Descriptions (Id,Company,LanguageID,Company_Name,Company_Description)" +                      
                      "values(@id,@cy,@la,@cn,@cd)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@cy", tc.Company);
                cmd.Parameters.AddWithValue("@la", tc.LanguageId);
                cmd.Parameters.AddWithValue("@cn", tc.CompanyName);
                cmd.Parameters.AddWithValue("@cd", tc.CompanyDescription);

                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            IList<CompanyDescriptionPoco> data = new List<CompanyDescriptionPoco>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Company_Descriptions", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CompanyDescriptionPoco poco = new CompanyDescriptionPoco()
                            {
                                Id = (Guid)reader["Id"],
                                Company = (Guid)reader["Company"],
                                LanguageId = reader["LanguageID"] as string,
                                CompanyName = reader["Company_Name"] as string,
                                CompanyDescription = reader["Company_Description"] as string,

                                TimeStamp = (byte[])reader["Time_Stamp"]

                            };

                            data.Add(poco);
                        }
                    }
                }
            }
            return data;
        }

        public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
                IQueryable<CompanyDescriptionPoco> pocos = GetAll().AsQueryable();

                return pocos.Where(where).FirstOrDefault();
            }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
             conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (CompanyDescriptionPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Company_Descriptions where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
                conn = new SqlConnection(_connectionString);
                conn.Open();

                foreach (CompanyDescriptionPoco tc in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.CommandText = @"Update Company_Descriptions SET Company = @cy, " +
                        " LanguageID = @la, Company_Name = @cn,Company_Description = @cd "+ 
                        " where @id = Id";

                    cmd.Parameters.AddWithValue("@id", tc.Id);
                    cmd.Parameters.AddWithValue("@cy", tc.Company);
                    cmd.Parameters.AddWithValue("@la", tc.LanguageId);
                    cmd.Parameters.AddWithValue("@cn", tc.CompanyName);
                    cmd.Parameters.AddWithValue("@cd", tc.CompanyDescription);



                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
    }
}
