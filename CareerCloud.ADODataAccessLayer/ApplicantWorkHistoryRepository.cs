using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantWorkHistoryRepository : IDataRepository<ApplicantWorkHistoryPoco>
    {
        private SqlConnection conn;
        protected readonly string _connectionString = string.Empty;

        public ApplicantWorkHistoryRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (ApplicantWorkHistoryPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Applicant_Work_History (Id,Applicant,Company_Name,Country_Code,Location," +
                      "Job_Title, Job_Description,Start_Month,Start_Year,End_Month,End_Year) " +
                      "values(@id,@ap,@cn,@cc,@lo,@jt,@jd,@sm,@sy,@em,@ey)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@ap", tc.Applicant);
                cmd.Parameters.AddWithValue("@cn", tc.CompanyName);
                cmd.Parameters.AddWithValue("@cc", tc.CountryCode);
                cmd.Parameters.AddWithValue("@lo", tc.Location);
                cmd.Parameters.AddWithValue("@jt", tc.JobTitle);
                cmd.Parameters.AddWithValue("@jd", tc.JobDescription);
                cmd.Parameters.AddWithValue("@sm", tc.StartMonth);
                cmd.Parameters.AddWithValue("@sy", tc.StartYear);
                cmd.Parameters.AddWithValue("@em", tc.EndMonth);
                cmd.Parameters.AddWithValue("@ey", tc.EndYear);
                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IList<ApplicantWorkHistoryPoco> data = new List<ApplicantWorkHistoryPoco>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Applicant_Work_History", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ApplicantWorkHistoryPoco poco = new ApplicantWorkHistoryPoco()
                            {
                                Id = (Guid)reader["Id"],
                                Applicant = (Guid)reader["Applicant"],
                                CompanyName = reader["Company_Name"] as string,
                                CountryCode = reader["Country_Code"] as string,
                                Location = reader["Location"] as string,
                                JobTitle = reader["Job_Title"] as string,
                                JobDescription = reader["Job_Description"] as string,
                                StartMonth = (short)reader["Start_Month"],
                                StartYear = (int)reader["Start_Year"],
                                EndMonth = (short)reader["End_Month"],
                                EndYear = (int)reader["End_Year"],
                                TimeStamp = (byte[])reader["Time_Stamp"]
                            };

                            data.Add(poco);
                        }
                    }
                }
            }


            return data;

        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (ApplicantWorkHistoryPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Applicant_Work_History where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (ApplicantWorkHistoryPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Applicant_Work_History SET Applicant = @ap, " +
                    " Company_Name = @cn, Country_Code = @cc,Location = @lo, Job_Title = @jt," +
                    " Job_Description= @jd,Start_Month = @sm, Start_Year =@sy,End_Month = @em, " +
                    "End_Year = @ey where @id = Id";



                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@ap", tc.Applicant);
                cmd.Parameters.AddWithValue("@cn", tc.CompanyName);
                cmd.Parameters.AddWithValue("@cc", tc.CountryCode);
                cmd.Parameters.AddWithValue("@lo", tc.Location);
                cmd.Parameters.AddWithValue("@jt", tc.JobTitle);
                cmd.Parameters.AddWithValue("@jd", tc.JobDescription);
                cmd.Parameters.AddWithValue("@sm", tc.StartMonth);
                cmd.Parameters.AddWithValue("@sy", tc.StartYear);
                cmd.Parameters.AddWithValue("@em", tc.EndMonth);
                cmd.Parameters.AddWithValue("@ey", tc.EndYear);



                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
