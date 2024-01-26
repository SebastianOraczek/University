using BOOKSTORE_PROJECT_PO.Validators;
using NUnit.Framework;

namespace Project_Tests
{
    public class AuthorValidatorTests
    {
        private AuthorValidator validator = new AuthorValidator();

        // First Name test
        [Test]
        public void WhenFirstNameHas30CharsShouldReturnOk()
        {
            // Act
            var validationResult = validator.Validate("aaaaaaaaaabbbbbbbbbbcccccccccc", "aaaa");

            // Assert
            Assert.IsTrue(validationResult.IsCorrect);
            Assert.AreEqual("", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenFirstNameHas4CharactersShouldReturnOk()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "aaaa");

            // Assert
            Assert.IsTrue(validationResult.IsCorrect);
            Assert.AreEqual("", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenFirstNameIsEmptyShouldReturnEmptyFieldErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("", "aaa");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("First Name cannot be empty", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenFirstHasOnlySpacesShouldReturnEmptyFieldErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("      ", "aaa");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("First Name cannot be empty", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenFirstNameHas31CharsShouldReturnToLongErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("aaaaaaaaaabbbbbbbbbbcccccccccc1", "aaa");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("First Name cannot be longer then 30 chars", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenFirstNameHasLessThan3CharactersShouldReturnTooShortError()
        {
            // Act
            var validationResult = validator.Validate("aa", "aaaa");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("First Name too short. Minimal lenght is equal 3", validationResult.ErrorMessage);
        }

        // Last Name tests
        [Test]
        public void WhenLastNameHas30CharsShouldReturnOk()
        {
            // Act
            var validationResult = validator.Validate("aaa", "aaaaaaaaaabbbbbbbbbbcccccccccc");

            // Assert
            Assert.IsTrue(validationResult.IsCorrect);
            Assert.AreEqual("", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenLastNameHas4CharactersShouldReturnOk()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "aaaa");

            // Assert
            Assert.IsTrue(validationResult.IsCorrect);
            Assert.AreEqual("", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenLastNameIsEmptyShouldReturnEmptyFieldErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("Last Name cannot be empty", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenLastNameHasOnlySpacesShouldReturnEmptyFieldErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "    ");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("Last Name cannot be empty", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenLastNameHas31CharsShouldReturnToLongErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "aaaaaaaaaabbbbbbbbbbcccccccccc1");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("Last Name cannot be longer then 30 chars", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenLastNameHasLessThan3CharactersShouldReturnTooShortError()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "aa");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("Last Name too short. Minimal lenght is equal 3", validationResult.ErrorMessage);
        }
    }
}