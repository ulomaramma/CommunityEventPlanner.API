using System.ComponentModel.DataAnnotations;

namespace CommunityEventPlanner.Client.Validations
{
    public class DateValidation
    {
        public class DateGreaterOrEqualToTodayAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value is DateTime date)
                {
                    return date.Date >= DateTime.Today;
                }
                return true;
            }
        }

        public class DateGreaterThanAttribute : ValidationAttribute
        {
            private readonly string _comparisonProperty;

            public DateGreaterThanAttribute(string comparisonProperty)
            {
                _comparisonProperty = comparisonProperty;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var comparisonProperty = validationContext.ObjectType.GetProperty(_comparisonProperty);
                if (comparisonProperty == null)
                {
                    return new ValidationResult($"Unknown property: {_comparisonProperty}");
                }

                var comparisonValue = comparisonProperty.GetValue(validationContext.ObjectInstance);

                if (value is DateTime date && comparisonValue is DateTime comparisonDate)
                {
                    if (date <= comparisonDate)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }

                return ValidationResult.Success;
            }
        }
    }
}
