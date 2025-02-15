using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginRepository : IDataRepository<SecurityLoginPoco>
    {
        private SqlConnection conn;
        protected readonly string _connectionString = string.Empty;

        public SecurityLoginRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params SecurityLoginPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (SecurityLoginPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Security_Logins (Id,Login,Password,Created_Date,Password_Update_Date,"+
                   "Agreement_Accepted_Date,Is_Locked,Is_Inactive,Email_Address,Phone_Number,Full_Name,"+
                    "Force_Change_Password,Prefferred_Language)  values(@id,@lg,@pw,@cr,@pwu,@aa,@il,@is,@ea,@pn,@fn,@fc,@pf)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@lg", tc.Login);
                cmd.Parameters.AddWithValue("@pw", tc.Password);
                cmd.Parameters.AddWithValue("@cr", tc.Created);
                cmd.Parameters.AddWithValue("@pwu", tc.PasswordUpdate);
                cmd.Parameters.AddWithValue("@aa", tc.AgreementAccepted);
                cmd.Parameters.AddWithValue("@il", tc.IsLocked);
                cmd.Parameters.AddWithValue("@is", tc.IsInactive);
                cmd.Parameters.AddWithValue("@ea", tc.EmailAddress);
                cmd.Parameters.AddWithValue("@pn", tc.PhoneNumber);
                cmd.Parameters.AddWithValue("@fn", tc.FullName);
                cmd.Parameters.AddWithValue("@fc", tc.ForceChangePassword);
                cmd.Parameters.AddWithValue("@pf", tc.PrefferredLanguage);

                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IList<SecurityLoginPoco> data = new List<SecurityLoginPoco>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Security_Logins", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SecurityLoginPoco poco = new SecurityLoginPoco()
                            {
                                Id = (Guid)reader["Id"],
                                Login = reader["Login"] as string,
                                Password = reader["Password"] as string,
                                Created = (DateTime)reader["Created_Date"] ,
                                PasswordUpdate = Convert.IsDBNull(reader["Password_Update_Date"])?null:(DateTime)reader["Password_Update_Date"],
                                AgreementAccepted =Convert.IsDBNull(reader["Agreement_Accepted_Date"])?null:(DateTime)reader["Agreement_Accepted_Date"],
                                IsLocked = (bool)reader["Is_Locked"],
                                IsInactive = (bool)reader["Is_Inactive"],
                                EmailAddress = reader["Email_Address"] as string,
                                PhoneNumber = reader["Phone_Number"] as string,
                                FullName = reader["Full_Name"] as string,
                                ForceChangePassword = (bool)reader["Force_Change_Password"],
                                PrefferredLanguage = reader["Prefferred_Language"] as string,

                                TimeStamp = (byte[])reader["Time_Stamp"]
                        };

                            data.Add(poco);
                        }
                    }
                }
            }
            return data;
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();


            foreach (SecurityLoginPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Security_Logins where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (SecurityLoginPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Security_Logins SET Login = @lg,Password=@pw, Created_Date=@cr,Password_Update_Date =@pwu," +
                    " Agreement_Accepted_Date = @aa, Is_Locked = @il,Is_Inactive=@is,Email_Address=@ea,Phone_Number=@pn, " +
                    "Full_Name=@fn, Force_Change_Password=@fc,Prefferred_Language=@pf where @id = Id";


                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@lg", tc.Login);
                cmd.Parameters.AddWithValue("@pw", tc.Password);
                cmd.Parameters.AddWithValue("@cr", tc.Created);
                cmd.Parameters.AddWithValue("@pwu", tc.PasswordUpdate);
                cmd.Parameters.AddWithValue("@aa", tc.AgreementAccepted);
                cmd.Parameters.AddWithValue("@il", tc.IsLocked);
                cmd.Parameters.AddWithValue("@is", tc.IsInactive);
                cmd.Parameters.AddWithValue("@ea", tc.EmailAddress);
                cmd.Parameters.AddWithValue("@pn", tc.PhoneNumber);
                cmd.Parameters.AddWithValue("@fn", tc.FullName);
                cmd.Parameters.AddWithValue("@fc", tc.ForceChangePassword);
                cmd.Parameters.AddWithValue("@pf", tc.PrefferredLanguage);


                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
