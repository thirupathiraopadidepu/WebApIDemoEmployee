
using System.ComponentModel.DataAnnotations;

namespace WebApIDemoEmployee.Moidel
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } // nullable property
        public string? Designation { get; set; }

        public float? Salary { get; set; }

    }
}
