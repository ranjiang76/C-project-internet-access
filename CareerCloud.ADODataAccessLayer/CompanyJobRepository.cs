using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobRepository : IDataRepository<CompanyJobPoco>
    {
        private SqlConnection conn;
        protected readonly string _connectionString = string.Empty;

        public CompanyJobRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params CompanyJobPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (CompanyJobPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Company_Jobs (Id,Company,Profile_Created,Is_Inactive,Is_Company_Hidden)" +
                      "values(@id,@cy,@pc,@is,@ic)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@cy", tc.Company);
                cmd.Parameters.AddWithValue("@pc", tc.ProfileCreated);
                cmd.Parameters.AddWithValue("@is", tc.IsInactive);
                cmd.Parameters.AddWithValue("@ic", tc.IsCompanyHidden);

                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IList<CompanyJobPoco> data = new List<CompanyJobPoco>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Company_Jobs", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CompanyJobPoco poco = new CompanyJobPoco()
                            {
                                Id = (Guid)reader["Id"],
                                Company = (Guid)reader["Company"],
                                ProfileCreated = (DateTime)reader["Profile_Created"],
                                IsInactive = (bool)reader["Is_Inactive"],
                                IsCompanyHidden = (bool)reader["Is_Company_Hidden"],

                                TimeStamp = (byte[])reader["Time_Stamp"]
                            };

                            data.Add(poco);
                        }
                    }
                }
            }
            return data;
        }

        public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (CompanyJobPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Company_Jobs where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params CompanyJobPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (CompanyJobPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Company_Jobs SET Company = @cy, " +
                    " Profile_Created = @pc, Is_Inactive = @is, " +
                    " Is_Company_Hidden=@ic  where @id = Id";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@cy", tc.Company);
                cmd.Parameters.AddWithValue("@pc", tc.ProfileCreated);
                cmd.Parameters.AddWithValue("@is", tc.IsInactive);
                cmd.Parameters.AddWithValue("@ic", tc.IsCompanyHidden);


                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
