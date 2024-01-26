namespace BOOKSTORE_PROJECT_PO.Validators
{
    public class CustomerValidator : CommonValidator
    {
        /// <summary>
        /// Function to validate input during adding a new customer
        /// </summary>
        /// <param name="firstName">Customer first name</param>
        /// <param name="lastName">Customer last name</param>
        /// <param name="email">Customer name</param>
        /// <returns>Validation message and boolean value</returns>
        public ValidateResult Validate(string firstName, string lastName, string email)
        {
            var firstNameResult = this.ValidateInput(firstName, "First Name", 30, 3);
            if (!firstNameResult.IsCorrect)
                return firstNameResult;

            var lastNameResult = this.ValidateInput(lastName, "Last Name", 30, 3);
            if (!lastNameResult.IsCorrect)
                return lastNameResult;

            var emailResult = this.ValidateInput(email, "Email", 50, 10);
            if (!emailResult.IsCorrect)
                return emailResult;

            return new ValidateResult { ErrorMessage = "", IsCorrect = true  };
        }
    }
}
