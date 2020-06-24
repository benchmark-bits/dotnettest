using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static TestApp_MVC.Controllers.HomeController;

namespace TestApp_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        

        [HttpPost]
        public ActionResult SaveStudent(StudentData clsStudentData)
        {
            return View("Index");
        }

        public class StudentData
        {            
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }           
            public string PckMoney { get; set; }            

            public string Password { get; set; }

            public string Age { get; set; }
            
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
            public string Country { get; set; }
        }
    }

    public class sqlConnections
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);

        public int saveData(StudentData clsStudentData)
        {
            int result = 0;

            string sql = "INSERT INTO student (first_name, last_name, email,pocket_moneys,password) Values ('"+ clsStudentData.FirstName  + "', '" + clsStudentData.FirstName + "', '" + clsStudentData.Email + "', '" + clsStudentData.PckMoney + "', '" + clsStudentData.Password + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            result = 1;
            return result;
        }

        public List<StudentData> data()
        {
            // Get Data Here
            List<StudentData> lstStudent = new List<StudentData>();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Students", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Students");
            if (ds.Tables["Students"].Rows.Count > 0)
            {
                DataView dv = new DataView();
                dv = ds.Tables[0].DefaultView;

                foreach (DataRowView drow in dv)
                {
                    StudentData glob_StudentData = new StudentData();

                    glob_StudentData.ID = Convert.ToInt32(drow["StudentID"]);
                    glob_StudentData.FirstName = Convert.ToString(drow["FirstName"]);
                    glob_StudentData.LastName = Convert.ToString(drow["LastName"]);
                    glob_StudentData.Email = Convert.ToString(drow["Email"]);
                    glob_StudentData.PckMoney = Convert.ToString(drow["PckMoney"]);

                    lstStudent.Add(glob_StudentData);
                }

                return lstStudent;
            }
            return lstStudent;
        }
    }
}