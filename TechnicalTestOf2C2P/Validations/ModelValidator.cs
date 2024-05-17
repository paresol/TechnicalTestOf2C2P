using System.ComponentModel.DataAnnotations;

namespace TechnicalTestOf2C2P.Validations
{
    public static class ModelValidator
    {
        public static IList<ValidationResult> Validate<T>(T model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);

            return validationResults;
        }
    }
}
