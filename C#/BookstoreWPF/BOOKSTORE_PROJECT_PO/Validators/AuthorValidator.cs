namespace BOOKSTORE_PROJECT_PO.Validators
{
    public class AuthorValidator : CommonValidator
    {
        /// <summary>
        /// Function to validate input during adding a new autor
        /// </summary>
        /// <param name="firstName">Autor first name</param>
        /// <param name="lastName">Autor last name</param>
        /// <returns>Validation message and boolean value</returns>
        public ValidateResult Validate(string firstName, string lastName)
        {
            var firstNameResult = this.ValidateInput(firstName, "First Name", 30, 3);
            if (!firstNameResult.IsCorrect)
                return firstNameResult;

            var lastNameResult = this.ValidateInput(lastName, "Last Name", 30, 3);
            if (!lastNameResult.IsCorrect)
                return lastNameResult;

            return new ValidateResult { ErrorMessage = "", IsCorrect = true };
        }
    }
}
