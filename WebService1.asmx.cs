using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SOAP_API
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetEmpData(string EmployeeNationalIDAlternateKey)
        {
            List<string> employees = new List<string>();
            string connectionString = "Data Source=DESKTOP-10ST34L\\SQLEXPRESS;Initial Catalog=Adventure works;User ID=sa;Password=P@$$w0rd;Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT FirstName ,LastName,Title, BirthDate, MaritalStatus, Gender\r\n " + 
                    "FROM dbo.DimEmployee  WHERE EmployeeNationalIDAlternateKey = N'" + EmployeeNationalIDAlternateKey + "')", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string NationalIDNo = reader["EmployeeNationalIDAlternateKey"].ToString();
                    string Title = reader["Title"].ToString();
                    string BirthDate = reader["BirthDate"].ToString();
                    string MaritalStatus = reader["MaritalStatus"].ToString();
                    string Gender = reader["Gender"].ToString();

                    employees.Add(NationalIDNo);
                    employees.Add(Title);
                    employees.Add(BirthDate);
                    employees.Add(MaritalStatus);
                    employees.Add(Gender);

                }
                return employees;
            }
        }
    }
}
