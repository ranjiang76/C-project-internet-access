using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantResumeRepository : IDataRepository<ApplicantResumePoco>
    {
        private SqlConnection conn;
        protected readonly string _connectionString = string.Empty;

        public ApplicantResumeRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }

        public void Add(params ApplicantResumePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (ApplicantResumePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Applicant_Resumes (Id,Applicant,Resume,Last_Updated)" +
                                 " values(@id,@ap,@rs,@lu)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@ap", tc.Applicant);
                cmd.Parameters.AddWithValue("@rs", tc.Resume);
                cmd.Parameters.AddWithValue("@lu", tc.LastUpdated);
   
                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IList<ApplicantResumePoco> data = new List<ApplicantResumePoco>();


            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Applicant_Resumes", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ApplicantResumePoco poco = new ApplicantResumePoco()
                            {
                                Id = (Guid)reader["Id"],
                                Applicant = (Guid)reader["Applicant"],
                                Resume = reader["Resume"] as string,
                                LastUpdated = Convert.IsDBNull(reader["Last_Updated"])?null:(DateTime)reader["Last_Updated"]                           
                            };

                            data.Add(poco);
                        }
                    }
                }
            }


            return data;

        }

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantResumePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (ApplicantResumePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Applicant_Resumes where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (ApplicantResumePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Applicant_Resumes SET Applicant = @ap, " +
                    " Resume = @rs, Last_Updated = @lu" +
                    " where @id = Id";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@ap", tc.Applicant);
                cmd.Parameters.AddWithValue("@rs", tc.Resume);
                cmd.Parameters.AddWithValue("@lu", tc.LastUpdated);

                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
