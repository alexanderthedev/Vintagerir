using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Vintagerie.Models
{
    public class UserExistValidation : ValidationAttribute
    {

        private ApplicationDbContext _context;

        public UserExistValidation()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var user = (RegisterViewModel)validationContext.ObjectInstance;
            var findUser = _context.Users.FirstOrDefault(u => u.Name == user.Name);

                if (findUser != null)
                {
                    return new ValidationResult("This name already exist.");
                }


            return ValidationResult.Success;
        }
    }
}