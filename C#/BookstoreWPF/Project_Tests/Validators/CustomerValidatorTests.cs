using BOOKSTORE_PROJECT_PO.Validators;
using NUnit.Framework;

namespace Project_Tests
{
    public class CustomerValidatorTests
    {
        private CustomerValidator validator = new CustomerValidator();

        // First Name test
        [Test]
        public void WhenFirstNameHas30CharsShouldReturnOk()
        {
            // Act
            var validationResult = validator.Validate("aaaaaaaaaabbbbbbbbbbcccccccccc", "aaaa", "aaaa@wp.pl");

           // Assert
            Assert.IsTrue(validationResult.IsCorrect);
            Assert.AreEqual("", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenFirstNameHas4CharactersShouldReturnOk()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "aaaa", "aaaa@wp.pl");

            // Assert
            Assert.IsTrue(validationResult.IsCorrect);
            Assert.AreEqual("", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenFirstNameIsEmptyShouldReturnEmptyFieldErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("", "aaa", "aaa@wp.pl");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("First Name cannot be empty", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenFirstHasOnlySpacesShouldReturnEmptyFieldErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("      ", "aaa", "aaa@wp.pl");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("First Name cannot be empty", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenFirstNameHas31CharsShouldReturnToLongErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("aaaaaaaaaabbbbbbbbbbcccccccccc1", "aaa", "aaaa@wp.pl");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("First Name cannot be longer then 30 chars", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenFirstNameHasLessThan3CharactersShouldReturnTooShortError()
        {
            // Act
            var validationResult = validator.Validate("aa", "aaaa", "aaaa@wp.pl");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("First Name too short. Minimal lenght is equal 3", validationResult.ErrorMessage);
        }

        // Last Name tests
        [Test]
        public void WhenLastNameHas30CharsShouldReturnOk()
        {
            // Act
            var validationResult = validator.Validate("aaa", "aaaaaaaaaabbbbbbbbbbcccccccccc", "aaaa@wp.pl");

            // Assert
            Assert.IsTrue(validationResult.IsCorrect);
            Assert.AreEqual("", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenLastNameHas4CharactersShouldReturnOk()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "aaaa", "aaaa@wp.pl");

            // Assert
            Assert.IsTrue(validationResult.IsCorrect);
            Assert.AreEqual("", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenLastNameIsEmptyShouldReturnEmptyFieldErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "", "aaaa@wp.pl");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("Last Name cannot be empty", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenLastNameHasOnlySpacesShouldReturnEmptyFieldErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "    ", "aaaa@wp.pl");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("Last Name cannot be empty", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenLastNameHas31CharsShouldReturnToLongErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "aaaaaaaaaabbbbbbbbbbcccccccccc1", "aaaa@wp.pl");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("Last Name cannot be longer then 30 chars", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenLastNameHasLessThan3CharactersShouldReturnTooShortError()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "aa", "aaaa@wp.pl");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("Last Name too short. Minimal lenght is equal 3", validationResult.ErrorMessage);
        }

        // Email tests
        [Test]
        public void WhenEmaileHas50CharsShouldReturnOk()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "aaaa", "aaaaaaaaaabbbbbbbbbbccccccccccddddddddddcccc@wp.pl");

            // Assert
            Assert.IsTrue(validationResult.IsCorrect);
            Assert.AreEqual("", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenEmailHas10CharactersShouldReturnOk()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "aaaa", "aaaa@wp.pl");

            // Assert
            Assert.IsTrue(validationResult.IsCorrect);
            Assert.AreEqual("", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenEmailHasCorrectShouldReturnOk()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "aaaa", "aaaa@wp.pl");

            // Assert
            Assert.IsTrue(validationResult.IsCorrect);
            Assert.AreEqual("", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenEmailIsEmptyShouldReturnEmptyFieldErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("aaa", "aaa", "");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("Email cannot be empty", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenEmailHasOnlySpacesShouldReturnEmptyFieldErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("aaa", "aaa", "       ");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("Email cannot be empty", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenEmailHas51CharsShouldReturnToLongErrorMessage()
        {
            // Act
            var validationResult = validator.Validate("aaa", "aaa", "aaaaaaaaaabbbbbbbbbbccccccccccddddddddddcccc@wp.pl1");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("Email cannot be longer then 50 chars", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenEmailHasLessThan10CharactersShouldReturnTooShortError()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "aaaa", "a@wp.pl");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("Email too short. Minimal lenght is equal 10", validationResult.ErrorMessage);
        }

        [Test]
        public void WhenEmailHasInCorrectShouldReturnOk()
        {
            // Act
            var validationResult = validator.Validate("aaaa", "aaaa", "aaaa!wp.pl");

            // Assert
            Assert.IsFalse(validationResult.IsCorrect);
            Assert.AreEqual("Email has incorrect syntax. Please provide correct email", validationResult.ErrorMessage);
        }
    }
}