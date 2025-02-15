using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobDescriptionRepository : IDataRepository<CompanyJobDescriptionPoco>
    {
        private SqlConnection conn;
        protected readonly string _connectionString = string.Empty;

        public CompanyJobDescriptionRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params CompanyJobDescriptionPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (CompanyJobDescriptionPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Company_Jobs_Descriptions (Id,Job,Job_Name,Job_Descriptions)" +
                      "values(@id,@job,@jn,@jd)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@job", tc.Job);
                cmd.Parameters.AddWithValue("@jn", tc.JobName);
                cmd.Parameters.AddWithValue("@jd", tc.JobDescriptions);

                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            IList<CompanyJobDescriptionPoco> data = new List<CompanyJobDescriptionPoco>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Company_Jobs_Descriptions", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CompanyJobDescriptionPoco poco = new CompanyJobDescriptionPoco()
                            {
                                Id = (Guid)reader["Id"],
                                Job = (Guid)reader["Job"],
                                JobName = reader["Job_Name"] as string,
                                JobDescriptions = reader["Job_Descriptions"] as string,

                                TimeStamp = (byte[])reader["Time_Stamp"]
                              
                            };

                            data.Add(poco);
                        }
                    }
                }
            }
            return data;
        }

        public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobDescriptionPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobDescriptionPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (CompanyJobDescriptionPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Company_Jobs_Descriptions where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (CompanyJobDescriptionPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Company_Jobs_Descriptions SET Job = @job, " +
                    " Job_Name = @jn, Job_Descriptions = @jd " +
                    " where @id = Id";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@job", tc.Job);
                cmd.Parameters.AddWithValue("@jn", tc.JobName);
                cmd.Parameters.AddWithValue("@jd", tc.JobDescriptions);


                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
