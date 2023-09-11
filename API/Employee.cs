using System.ComponentModel.DataAnnotations;

namespace API
{
    public class Employee
    {
        
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set ; }
        public string? Mobile { get; set; }
    }
}
