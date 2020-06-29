using System.Collections.Generic;
using TestApp_MVC.Models;

namespace TestApp_MVC.ViewModels
{
    public class StudentModuleViewModel
    {
        public Student Student { get; set; } = new Student();

        public Student NthHighestPoketModeyStudent { get; set; } = new Student();

        public List<Student> Students { get; set; } = new List<Student>();

    }
}