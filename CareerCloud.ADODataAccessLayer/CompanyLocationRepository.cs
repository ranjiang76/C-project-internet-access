using Microsoft.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyLocationRepository : IDataRepository<CompanyLocationPoco>
    {
        protected readonly string _connectionString = string.Empty;

        public CompanyLocationRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params CompanyLocationPoco[] items)
        {
            using (var conn = new SqlConnection(_connectionString))
            { 
  
                conn.Open();

            foreach (CompanyLocationPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Insert into Company_Locations (Id,Company,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code)" +
                      "values(@id,@cy,@cc,@pr,@st,@ct,@pc)";

                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@cy", tc.Company);
                cmd.Parameters.AddWithValue("@cc", tc.CountryCode);
                cmd.Parameters.AddWithValue("@pr", tc.Province);
                cmd.Parameters.AddWithValue("@st", tc.Street);
                cmd.Parameters.AddWithValue("@ct", tc.City);
                cmd.Parameters.AddWithValue("@pc", tc.PostalCode);

                cmd.ExecuteNonQuery();

            }
            conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IList<CompanyLocationPoco> data = new List<CompanyLocationPoco>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Company_Locations", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CompanyLocationPoco poco = new CompanyLocationPoco()
                            {
                                Id = (Guid)reader["Id"],
                                Company = (Guid)reader["Company"],
                                CountryCode = reader["Country_Code"] as string,
                                Province = reader["State_Province_Code"] as string,
                                Street = reader["Street_Address"] as string,
                                City = reader["City_Town"] as string,
                                PostalCode = reader["Zip_Postal_Code"] as string,
                                TimeStamp = (byte[])reader["Time_Stamp"]
 
                            };

                            data.Add(poco);
                        }
                    }
                }
            }
            return data;
        }

        public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyLocationPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyLocationPoco[] items)
        {
            using (var conn = new SqlConnection(_connectionString))
            { 
 
                conn.Open();


            foreach (CompanyLocationPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.CommandText = @"Delete from Company_Locations where @id = Id";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            }
        }

        public void Update(params CompanyLocationPoco[] items)
        {
            using (var conn = new SqlConnection(_connectionString))
            { 

                conn.Open();

            foreach (CompanyLocationPoco tc in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"Update Company_Locations SET Company = @cy, " +
                    " Country_Code = @cc, State_Province_Code = @pr , Street_Address=@st  ,City_Town= @ct,Zip_Postal_Code=@pc" +
                    " where @id = Id";


                cmd.Parameters.AddWithValue("@id", tc.Id);
                cmd.Parameters.AddWithValue("@cy", tc.Company);
                cmd.Parameters.AddWithValue("@cc", tc.CountryCode);
                cmd.Parameters.AddWithValue("@pr", tc.Province);
                cmd.Parameters.AddWithValue("@st", tc.Street);
                cmd.Parameters.AddWithValue("@ct", tc.City);
                cmd.Parameters.AddWithValue("@pc", tc.PostalCode);


                cmd.ExecuteNonQuery();
            }
            }
        }
    }
}
