using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantJobApplicationRepository : IDataRepository<ApplicantJobApplicationPoco>
    {

       
        protected readonly string _connectionString = string.Empty;

        public ApplicantJobApplicationRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        
        public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            IList<ApplicantJobApplicationPoco> data = new List<ApplicantJobApplicationPoco>();


            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Applicant_Job_Applications", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco()
                            {
                                Id = (Guid)reader["Id"],
                                ApplicationDate = (DateTime)reader["Application_Date"],
                                Applicant = (Guid)reader["Applicant"] ,
                                Job = (Guid)reader["Job"] 
                            };

                            data.Add(poco);
                        }
                    }
                }
            }


            return data;
        }

        public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
             throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
 
            IQueryable<ApplicantJobApplicationPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                foreach (ApplicantJobApplicationPoco tc in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.CommandText = @"Insert into Applicant_Job_Applications (Id,Application_Date,Applicant," +
                                     "Job) values(@id,@ad,@ap,@job)";

                    cmd.Parameters.AddWithValue("@id", tc.Id);
                    cmd.Parameters.AddWithValue("@ad", tc.ApplicationDate);
                    cmd.Parameters.AddWithValue("@ap", tc.Applicant);
                    cmd.Parameters.AddWithValue("@job", tc.Job);


                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }
            }

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                foreach (ApplicantJobApplicationPoco tc in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.CommandText = @"Update Applicant_Job_Applications SET Application_Date = @ad, " +
                        " Applicant= @ap, Job = @job where @id = Id";

                    cmd.Parameters.AddWithValue("@id", tc.Id);
                    cmd.Parameters.AddWithValue("@ap", tc.Applicant);
                    cmd.Parameters.AddWithValue("@ad", tc.ApplicationDate);
                    cmd.Parameters.AddWithValue("@job", tc.Job);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            } 
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();


                foreach (ApplicantJobApplicationPoco tc in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", tc.Id);
                    cmd.CommandText = @"Delete from Applicant_Job_Applications where Id = @id";
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

    }
}
