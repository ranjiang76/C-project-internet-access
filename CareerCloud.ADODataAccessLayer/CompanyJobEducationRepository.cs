using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobEducationRepository : IDataRepository<CompanyJobEducationPoco>
    {
        private SqlConnection conn;
        protected readonly string _connectionString = string.Empty;

        public CompanyJobEducationRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params CompanyJobEducationPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (CompanyJobEducationPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Company_Job_Educations (Id,Job,Major,Importance)" +
                      "values(@id,@job,@ma,@im)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@job", tc.Job);
                cmd.Parameters.AddWithValue("@ma", tc.Major);
                cmd.Parameters.AddWithValue("@im", tc.Importance);

                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IList<CompanyJobEducationPoco> data = new List<CompanyJobEducationPoco>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Company_Job_Educations", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CompanyJobEducationPoco poco = new CompanyJobEducationPoco()
                            {
                                Id = (Guid)reader["Id"],
                                Job = (Guid)reader["Job"],
                                Major = reader["Major"] as string,
                                Importance = (Int16)reader["Importance"] ,

                                TimeStamp = (byte[])reader["Time_Stamp"]   
                            };

                            data.Add(poco);
                        }
                    }
                }
            }
            return data;
        }

        public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobEducationPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobEducationPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (CompanyJobEducationPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Company_Job_Educations where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params CompanyJobEducationPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (CompanyJobEducationPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Company_Job_Educations SET Job = @job, " +
                    " Major = @ma, Importance = @im " +
                    " where @id = Id";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@job", tc.Job);
                cmd.Parameters.AddWithValue("@ma", tc.Major);
                cmd.Parameters.AddWithValue("@im", tc.Importance);


                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
