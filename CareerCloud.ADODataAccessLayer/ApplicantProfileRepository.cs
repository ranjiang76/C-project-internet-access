using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantProfileRepository : IDataRepository<ApplicantProfilePoco>
    {

        protected readonly string _connectionString = string.Empty;

        public ApplicantProfileRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params ApplicantProfilePoco[] items)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                foreach (ApplicantProfilePoco tc in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.CommandText = @"Insert into Applicant_Profiles (Id,Current_Salary,Current_Rate,Country_Code,State_Province_Code," +
                          "Street_Address, City_Town,Zip_Postal_Code,Login,Currency) values(@id,@cs,@cr,@cc,@spc,@sa,@ct,@zpc,@lg,@cy)";

                    cmd.Parameters.AddWithValue("@id", tc.Id);
                    cmd.Parameters.AddWithValue("@cs", tc.CurrentSalary);
                    cmd.Parameters.AddWithValue("@cr", tc.CurrentRate);
                    cmd.Parameters.AddWithValue("@cc", tc.Country);
                    cmd.Parameters.AddWithValue("@spc", tc.Province);
                    cmd.Parameters.AddWithValue("@sa", tc.Street);
                    cmd.Parameters.AddWithValue("@ct", tc.City);
                    cmd.Parameters.AddWithValue("@zpc", tc.PostalCode);
                    cmd.Parameters.AddWithValue("@lg", tc.Login);
                    cmd.Parameters.AddWithValue("@cy", tc.Currency);
                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IList<ApplicantProfilePoco> data = new List<ApplicantProfilePoco>();


            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Applicant_Profiles", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ApplicantProfilePoco poco = new ApplicantProfilePoco()
                            {
                                Id = (Guid)reader["Id"],
                                CurrentSalary = (decimal?)reader["Current_Salary"],
                                CurrentRate = (decimal?)reader["Current_Rate"] ,
                                Country = reader["Country_Code"] as string,
                                Province = reader["State_Province_Code"] as string,
                                Street = reader["Street_Address"] as string,
                                City = reader["City_Town"] as string,
                                PostalCode = reader["Zip_Postal_Code"] as string,
                                Login = (Guid)reader["Login"],
                                Currency = reader["Currency"] as string
                            };

                            data.Add(poco);
                        }
                    }
                }
            }


            return data;
        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            using (var conn = new SqlConnection(_connectionString))
            { 
  
                conn.Open();


            foreach (ApplicantProfilePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Applicant_Profiles where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            using (var conn = new SqlConnection(_connectionString))
            { 

                conn.Open();

            foreach (ApplicantProfilePoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Applicant_Profiles SET Current_Salary = @cs, " +
                    " Current_Rate = @cr, Country_Code = @cc,State_Province_Code = @spc, Street_Address = @sa," +
                    " City_Town= @ct,Zip_Postal_Code = @zpc, Login =@lg,Currency = @cy where @id = Id";

     
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@cs", tc.CurrentSalary);
                cmd.Parameters.AddWithValue("@cr", tc.CurrentRate);
                cmd.Parameters.AddWithValue("@cc", tc.Country);
                cmd.Parameters.AddWithValue("@spc", tc.Province);
                cmd.Parameters.AddWithValue("@sa", tc.Street);
                cmd.Parameters.AddWithValue("@ct", tc.City);
                cmd.Parameters.AddWithValue("@zpc", tc.PostalCode);
                cmd.Parameters.AddWithValue("@lg", tc.Login);
                cmd.Parameters.AddWithValue("@cy", tc.Currency);



                cmd.ExecuteNonQuery();
            }
            conn.Close();
            }
        }
    }
}
