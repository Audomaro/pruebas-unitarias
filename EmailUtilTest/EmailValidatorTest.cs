using EmailUtil;

using Xunit;

namespace EmailUtilTest
{
    public class EmailValidatorTest
    {
        [Fact]
        public void EmailValidOld()
        {
            // Arrange 
            EmailValidator emailValidator = new EmailValidator();
            string email = "audomaro@email.com";

            // Act
            bool isValid = emailValidator.IsValidEmail(email);

            // Assert 
            Assert.True(isValid, "Correo invalido");
        }

        [Theory]
        [InlineData("valid@email.com", true)]
        [InlineData("invalid@email.invalid", false)]
        public void ValidateEmailShould(string email, bool expected)
        {
            // Arrange
            EmailValidator emailValidator = new EmailValidator();

            // Act
            bool isValid = emailValidator.IsValidEmail(email);

            // Assert 
            Assert.Equal(isValid, expected);
        }


        [Theory]
        [InlineData("valid@email.com", "INBOX")]
        [InlineData("invalid@spam.com", "SPAM")]
        [InlineData("otro@spam.com", "SPAM")]
        public void SpamEmaiShouldl(string email, string expected)
        {
            // Arrange
            EmailValidator emailValidator = new EmailValidator();

            // Act
            string value = emailValidator.IsSpam(email);

            // Assert 
            Assert.Equal(value, expected);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void RaiseErrorWhenEmailIsNull(string email)
        {
            // Arrange
            EmailValidator emailValidator = new EmailValidator();

            // Act

            // Assert 
            Assert.Throws<EmailNotProviderException>(() => emailValidator.IsValidEmail(email));
        }
    }
}