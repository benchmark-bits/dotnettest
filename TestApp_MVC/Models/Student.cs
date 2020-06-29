using System.ComponentModel.DataAnnotations;

namespace TestApp_MVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, MaxLength(30, ErrorMessage = "Max allowed length is 30 chars")]
        public string FirstName { get; set; }

        [Required, MaxLength(30, ErrorMessage = "Max allowed length is 30 chars")]
        public string LastName { get; set; }

        [MaxLength(50, ErrorMessage = "Max allowed length is 50 chars"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Currency)]
        public int PocketMoney { get; set; }

        [MaxLength(50, ErrorMessage = "Max allowed length is 50 chars"), DataType(DataType.Password)]
        public string Password { get; set; }
                
        public bool IsDeleted { get; set; }
    }
}