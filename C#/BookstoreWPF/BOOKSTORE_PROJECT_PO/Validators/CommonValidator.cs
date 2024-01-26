namespace BOOKSTORE_PROJECT_PO.Validators
{
    /// <summary>
    /// Model to a validation result
    /// </summary>
    public class ValidateResult
    {
        public bool IsCorrect { get; set; }    
        public string ErrorMessage { get; set; }    
    }

    public class CommonValidator
    { 
        /// <summary>
        /// Function to validate input by params
        /// </summary>
        /// <param name="text">Text need to be validate</param>
        /// <param name="fieldName">Field we want to validate</param>
        /// <param name="maxTextLenght">Max length of input</param>
        /// <param name="minTextLenght">Min length of input</param>
        /// <returns>Validate result based on model</returns>
        protected ValidateResult ValidateInput(string text, string fieldName, int maxTextLenght, int minTextLenght)
        {
            if (text.Trim().Length == 0)
                return new ValidateResult { ErrorMessage = $"{fieldName} cannot be empty", IsCorrect = false };

            if (text.Trim().Length > maxTextLenght)
                return new ValidateResult { ErrorMessage = $"{fieldName} cannot be longer then {maxTextLenght} chars", IsCorrect = false };

            if (text.Trim().Length < minTextLenght)
                return new ValidateResult { ErrorMessage = $"{fieldName} too short. Minimal lenght is equal {minTextLenght}", IsCorrect = false};

            if(fieldName == "Email" && !text.Contains("@"))
                return new ValidateResult { ErrorMessage = $"{fieldName} has incorrect syntax. Please provide correct email", IsCorrect = false };


            return new ValidateResult { ErrorMessage = "", IsCorrect = true  };
        }
    }
}
