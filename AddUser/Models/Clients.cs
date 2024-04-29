using System.ComponentModel.DataAnnotations;

namespace AddUser.Models
{
    public class Client
    {
        public string DNI { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime SubDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ModDate { get; set; }
    }
}
