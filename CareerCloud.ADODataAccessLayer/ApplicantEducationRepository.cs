using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
    {
        private SqlConnection conn;
         

        protected readonly string _connectionString = string.Empty;

        public ApplicantEducationRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }

        public void Add(params ApplicantEducationPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (ApplicantEducationPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Applicant_Educations (Id,Applicant,Major,Certificate_Diploma,Start_Date," +
                                 "Completion_Date, Completion_Percent) values(@id,@ap,@ma,@cd,@sd,@comd,@comp)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@ap", tc.Applicant);
                cmd.Parameters.AddWithValue("@ma", tc.Major);
                cmd.Parameters.AddWithValue("@cd", tc.CertificateDiploma);
                cmd.Parameters.AddWithValue("@sd", tc.StartDate);
                cmd.Parameters.AddWithValue("@comd", tc.CompletionDate);
                cmd.Parameters.AddWithValue("@comp", tc.CompletionPercent);

                cmd.ExecuteNonQuery();

            }
            conn.Close();

        }


        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }


        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IList<ApplicantEducationPoco> data = new List<ApplicantEducationPoco>();

 
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Applicant_Educations", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ApplicantEducationPoco poco = new ApplicantEducationPoco()
                            {
                                Id = (Guid)reader["Id"],
                                Applicant = (Guid)reader["Applicant"],
                                Major = reader["Major"] as string,
                                CertificateDiploma = reader["Certificate_Diploma"] as string,
                                StartDate = (DateTime)reader["Start_Date"],
                                CompletionDate = (DateTime)reader["Completion_Date"],
                                CompletionPercent = (byte)reader["Completion_Percent"]
                            };

                            data.Add(poco);
                        }
                    }
                }
            }


            return data;
        }


        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            /*
            List< ApplicantEducationPoco > list;
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();
            list = pocos.AsNoTracking().Where(where).ToList<ApplicantEducationPoco>();
            

            return list;
            */
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {

            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (ApplicantEducationPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Applicant_Educations where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (ApplicantEducationPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Applicant_Educations SET Certificate_Diploma = @cd, " +
                    " Start_Date = @sd, Completion_Date = @comd, Completion_Percent = @comp," +
                    " Applicant= @ap,Major = @ma where @id = Id";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@ap", tc.Applicant);
                cmd.Parameters.AddWithValue("@ma", tc.Major);
                cmd.Parameters.AddWithValue("@cd", tc.CertificateDiploma);
                cmd.Parameters.AddWithValue("@sd", tc.StartDate);

                cmd.Parameters.AddWithValue("@comd", tc.CompletionDate); 
                cmd.Parameters.AddWithValue("@comp", tc.CompletionPercent);



                cmd.ExecuteNonQuery();
            }
            conn.Close(); 
        }
    }
}
