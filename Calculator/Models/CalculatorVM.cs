using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Calculator.Models
{
    public class CalculatorVM : IValidatableObject
    {
        [Required(ErrorMessage = "First number is required")]
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "First number can not be less than 0")]
        public double FirstNumber { get; set; }

        [Required(ErrorMessage = "Second number is required")]
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "Second number can not be less than 0")]
        public double SecondNumber { get; set; }

        [Required(ErrorMessage = "CommandText is required")]
        public string CommandText { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var allowedCommands = new string[] { "add", "sub", "mul", "div", "dis", "rng" };
            if (string.IsNullOrEmpty(CommandText) || !allowedCommands.Contains(CommandText.ToLower()))
                yield return new ValidationResult("Invalid Operation !");

            if (!string.IsNullOrEmpty(CommandText) && CommandText.ToLower() == "div" && SecondNumber == 0D)
                yield return new ValidationResult("You can not divide a number by 0");
        }
    }
}
