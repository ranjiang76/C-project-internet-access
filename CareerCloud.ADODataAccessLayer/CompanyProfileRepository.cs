using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyProfileRepository : IDataRepository<CompanyProfilePoco>
    {
        private SqlConnection conn;
        protected readonly string _connectionString = string.Empty;

        public CompanyProfileRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params CompanyProfilePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (CompanyProfilePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Company_Profiles (Id,Registration_Date,Company_Website,Contact_Phone," +
                        "Contact_Name,Company_Logo) values(@id,@rd,@cw,@cp,@cn,@cl)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@rd", tc.RegistrationDate);
                cmd.Parameters.AddWithValue("@cw", tc.CompanyWebsite);
                cmd.Parameters.AddWithValue("@cp", tc.ContactPhone);
                cmd.Parameters.AddWithValue("@cn", tc.ContactName);
                cmd.Parameters.AddWithValue("@cl", tc.CompanyLogo);

                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IList<CompanyProfilePoco> data = new List<CompanyProfilePoco>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Company_Profiles", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CompanyProfilePoco poco = new CompanyProfilePoco()
                            {
                                Id = (Guid)reader["Id"],
                                RegistrationDate = (DateTime)reader["Registration_Date"],
                                CompanyWebsite = reader["Company_Website"] as string,
                                ContactPhone = reader["Contact_Phone"] as string,
                                ContactName = reader["Contact_Name"] as string,
                                CompanyLogo = Convert.IsDBNull(reader["Company_Logo"])?null:(byte[])reader["Company_Logo"] ,

                                TimeStamp = (byte[])reader["Time_Stamp"]

                             };

                             data.Add(poco);
                        }
                    }
                }
            }
            return data;
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (CompanyProfilePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Company_Profiles where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (CompanyProfilePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Company_Profiles SET Registration_Date = @rd, " +
                    " Company_Website = @cw, Contact_Phone = @cp,Contact_Name=@cn, Company_Logo=@cl" +
                    " where @id = Id";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@rd", tc.RegistrationDate);
                cmd.Parameters.AddWithValue("@cw", tc.CompanyWebsite);
                cmd.Parameters.AddWithValue("@cp", tc.ContactPhone);
                cmd.Parameters.AddWithValue("@cn", tc.ContactName);
                cmd.Parameters.AddWithValue("@cl", tc.CompanyLogo);


                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
