using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace RESTFUL
{
    public class EmpController : Controller
    {

        // GET: EmpController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmpController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpController
        [HttpGet("{EmployeeNationalIDAlternateKey}")]
        public List<String> GetEmployeeById(String EmployeeNationalIDAlternateKey)
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
