using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Vintagerie.Models
{
    public class UserExistValidationExternal : ValidationAttribute
    {

        private readonly ApplicationDbContext _context;

        public UserExistValidationExternal()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (ExternalLoginConfirmationViewModel)validationContext.ObjectInstance;
            var findUser = _context.Users.FirstOrDefault(u => u.Name == user.Name);

            if (findUser != null)
            {
                return new ValidationResult("This name already exists.");
            }


            return ValidationResult.Success;
        }
    }
}