using System;
using FluentAssertions;
using Infrastructure.Validators;
using NUnit.Framework;

namespace Infrastructure.UnitTests.Validators
{
    public class LengthValidatorTests
    {
        [Test]
        public void ShouldReturnTrueGivenSameLength()
        {
            //Arrange
            var lengthValidator = new LengthValidator();

            //Act
            //Assert
            lengthValidator.ValidateEqualLength(new[] { "a", "b" }, new[] { 3, 5 }).Should().BeTrue();
        }

        [Test]
        public void ShouldReturnFalseGivenDifferentLengths()
        {
            //Arrange
            var lengthValidator = new LengthValidator();

            //Act
            //Assert
            lengthValidator.ValidateEqualLength(new[] { "a", "b" }, new[] { 3, 5, 6, 7 }).Should().BeFalse();
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(new[] { "A", "B" }, null)]
        [TestCase(null, new[] { 90, 87 })]
        [TestCase(new string[0], null)]
        [TestCase(null, new int[0])]
        public void ShouldThrowNullReferenceExceptionIfAnyValueIsNull(string[] array1, int[] array2)
        {
            //Arrange
            var lengthValidator = new LengthValidator();

            //Act
            //Assert
            FluentActions
                .Invoking(() => lengthValidator.ValidateEqualLength(array1, array2))
                .Should()
                .Throw<NullReferenceException>();
        }
    }
}