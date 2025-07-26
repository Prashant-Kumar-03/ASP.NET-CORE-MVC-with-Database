using System.ComponentModel.DataAnnotations;

namespace ProjectMVCwithDatabase.Models
{
    public class Student
    {

        [Key]
        public int Id { get; set; } // Auto-incremented primary key

        public int RollNumber { get; set; } // User-entered or assigned
                                            // ... other properties ...


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required.")]
        [MaxLength(10)]
        public string Gender { get; set; } = string.Empty;

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter a valid 10-digit phone number.")]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
