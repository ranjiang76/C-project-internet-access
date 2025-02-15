using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantSkillRepository : IDataRepository<ApplicantSkillPoco>
    {
        private SqlConnection conn;
        protected readonly string _connectionString = string.Empty;

        public ApplicantSkillRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params ApplicantSkillPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (ApplicantSkillPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Applicant_Skills (Id,Applicant,Skill,Skill_Level,Start_Month,Start_Year,End_Month,End_Year)" +
                    "values(@id,@ap,@sk,@skl,@sm,@sy,@em,@ey)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@ap", tc.Applicant);
                cmd.Parameters.AddWithValue("@sk", tc.Skill);
                cmd.Parameters.AddWithValue("@skl", tc.SkillLevel);
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

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IList<ApplicantSkillPoco> data = new List<ApplicantSkillPoco>();


            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Applicant_Skills", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ApplicantSkillPoco poco = new ApplicantSkillPoco()
                            {
                                Id = (Guid)reader["Id"],
                                Applicant = (Guid)reader["Applicant"],
                                Skill = reader["Skill"] as string,
                                SkillLevel = reader["Skill_Level"] as string,
                                StartMonth = (byte)reader["Start_Month"],
                                StartYear = (int)reader["Start_Year"] ,
                                EndMonth =(byte) reader["End_Month"],
                                EndYear = (int)reader["End_Year"] ,
                                TimeStamp = (byte[])reader["Time_Stamp"]
                            };

                            data.Add(poco);
                        }
                    }
                }
            }


            return data;

        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantSkillPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (ApplicantSkillPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Applicant_Skills where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (ApplicantSkillPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Applicant_Skills SET Applicant = @ap, " +
                    " Skill = @sk, Skill_Level = @skl,Start_Month = @sm, Start_Year = @sy," +
                    " End_Month= @em,End_Year = @ey where @id = Id";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@ap", tc.Applicant);
                cmd.Parameters.AddWithValue("@sk", tc.Skill);
                cmd.Parameters.AddWithValue("@skl", tc.SkillLevel);
                cmd.Parameters.AddWithValue("@sm", tc.StartMonth);
                cmd.Parameters.AddWithValue("@sy", tc.StartYear);
                cmd.Parameters.AddWithValue("@em", tc.EndMonth);
                cmd.Parameters.AddWithValue("@ey", tc.EndYear);
                cmd.ExecuteNonQuery();



                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
