using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SampleApplication.Models
{
    public class Customer
    {
        [DisplayName("CustomerId")]
        public string Id { get; set; }
        public string Salutation { get; set; } = "";
        public string Initials { get; set; } = "";
        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; } = "";
        public string FirstName_Ascii { get; set; } = "";
        [Required(ErrorMessage = "Please enter Gender")]
        public string Gender { get; set; } = "";
        public string Firstname_Country_Rank { get; set; } = "";
        public string Firstname_Country_Frequency { get; set; } = "";
        [Required(ErrorMessage = "Please enter Last Name")]
        public string Lastname { get; set; } = "";
        public string Lastname_ascii { get; set; } = "";
        public string Lastname_country_rank { get; set; } = "";
        public string Lastname_country_frequency { get; set; } = "";
        [Required(ErrorMessage = "Please enter Email Address")]
        [EmailAddress(ErrorMessage ="Please enter valid email address")]
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        [Required(ErrorMessage = "Please enter Country Code")]
        public string Country_Code { get; set; } = "";
        public string Country_Code_Alpha { get; set; } = "";
        public string Country_Name { get; set; } = "";
        public string Primary_Language_Code { get; set; } = "";
        public string Primary_Language { get; set; } = "";
        [Required(ErrorMessage = "Please enter Balance")]
        [DisplayName("Balance")]
        [ConcurrencyCheck]
        public int Balancepublic { get; set; } = 0;
        [Required(ErrorMessage = "Phone Number")]
        public string Phone_Number { get; set; } = "";
        public string Currency { get; set; } = "";
        public string timestamp { get; set; }=DateTime.Now.ToString();
    }
}
