using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobSkillRepository : IDataRepository<CompanyJobSkillPoco>
    {

        protected readonly string _connectionString = string.Empty;

        public CompanyJobSkillRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params CompanyJobSkillPoco[] items)
        {
            using (var conn = new SqlConnection(_connectionString))
            { 
 
                conn.Open();

            foreach (CompanyJobSkillPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Company_Job_Skills (Id,Job,Skill,Skill_Level,Importance)" +
                      "values(@id,@job,@sk,@sl,@im)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@job", tc.Job);
                cmd.Parameters.AddWithValue("@sk", tc.Skill);
                cmd.Parameters.AddWithValue("@sl", tc.SkillLevel);
                cmd.Parameters.AddWithValue("@im", tc.Importance);

                cmd.ExecuteNonQuery();

            }
            conn.Close();
            }

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            IList<CompanyJobSkillPoco> data = new List<CompanyJobSkillPoco>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Company_Job_Skills", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CompanyJobSkillPoco poco = new CompanyJobSkillPoco()
                            {
                                Id = (Guid)reader["Id"],
                                Job = (Guid)reader["Job"],
                                Skill = reader["Skill"] as string,
                                SkillLevel = reader["Skill_Level"] as string,
                                Importance = (int)reader["Importance"],
                                TimeStamp = (byte[])reader["Time_Stamp"] 
                            };

                            data.Add(poco);
                        }
                    }
                }
            }
            return data;
        }

        public IList<CompanyJobSkillPoco> GetList(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobSkillPoco GetSingle(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobSkillPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobSkillPoco[] items)
        {
            using (var conn = new SqlConnection(_connectionString))
            { 

                conn.Open();


            foreach (CompanyJobSkillPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Company_Job_Skills where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            }
        }

        public void Update(params CompanyJobSkillPoco[] items)
        {
            using (var conn = new SqlConnection(_connectionString))
            { 

                conn.Open();

            foreach (CompanyJobSkillPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Company_Job_Skills SET Job = @job, " +
                    " Skill = @sk, Skill_Level = @sl,Importance = @im " +
                    " where @id = Id";


                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@job", tc.Job);
                cmd.Parameters.AddWithValue("@sk", tc.Skill);
                cmd.Parameters.AddWithValue("@sl", tc.SkillLevel);
                cmd.Parameters.AddWithValue("@im", tc.Importance);


                cmd.ExecuteNonQuery();
            }
            }
        }
    }
}
