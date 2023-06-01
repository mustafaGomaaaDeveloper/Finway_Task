using System.ComponentModel.DataAnnotations;

namespace Finway.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
    }
}
