using System.ComponentModel.DataAnnotations;

namespace CustomersApi.Dtos
{
    public class CreateCustomerDto
    {
        [Required (ErrorMessage = "El nombre propio tiene que estar especificado")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido tiene que estar especificado")]
        public string LastName { get; set; }

        //[RegularExpression("^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$", ErrorMessage = "Email no valido")]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
