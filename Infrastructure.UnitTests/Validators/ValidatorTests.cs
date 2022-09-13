using System;
using FluentAssertions;
using Infrastructure.Validators;
using NUnit.Framework;

namespace Infrastructure.UnitTests.Validators
{
    public class ValidatorTests
    {
        [Test]
        public void ShouldReturnTrueGivenSameLength()
        {
            //Arrange
            var validator = new Validator();

            //Act
            //Assert
            validator.ValidateEqualLength(new[] { "a", "b" }, new[] { 3, 5 }).Should().BeTrue();
        }

        [Test]
        public void ShouldReturnFalseGivenDifferentLengths()
        {
            //Arrange
            var validator = new Validator();

            //Act
            //Assert
            validator.ValidateEqualLength(new[] { "a", "b" }, new[] { 3, 5, 6, 7 }).Should().BeFalse();
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
            var validator = new Validator();

            //Act
            //Assert
            FluentActions
                .Invoking(() => validator.ValidateEqualLength(array1, array2))
                .Should()
                .Throw<NullReferenceException>();
        }

        [Test]
        public void ShouldReturnTrueGivenAnIncreasingCollectionStartingAtOne()
        {
            //Arrange
            var validator = new Validator();

            //Act
            //Assert
            validator.ValidateConsecutiveAndIncreasingSequentiality(new[] { 1, 2, 3, 4, 5, 6, 7 })
                .Should()
                .BeTrue();
        }

        [Test]
        [TestCase(new[] { 2, 3, 4, 5 })]
        [TestCase(new[] { 6, 7, 65, 2, 1 })]
        [TestCase(new[] { -1, 0, 1, 2, 3 })]
        [TestCase(new[] { 432, 0, -111, 344 })]
        public void ShouldReturnFalseGivenNonSequentialCollectionStartingAtOne(int[] collection)
        {
            //Arrange
            var validator = new Validator();

            //Act
            //Assert
            validator.ValidateConsecutiveAndIncreasingSequentiality(collection)
                .Should()
                .BeFalse();
        }

        [Test]
        public void ShouldThrowNullReferenceExceptionIfCollectionIsNull()
        {
            //Arrange
            var validator = new Validator();

            //Act
            //Assert
            FluentActions
                .Invoking(() => validator.ValidateConsecutiveAndIncreasingSequentiality(null))
                .Should()
                .Throw<NullReferenceException>();
        }

        [Test]
        [TestCase(new[] { 1, 2, 3 })]
        [TestCase(new[] { 8, 10, 11, 45, 132 })]
        [TestCase(new[] { 100, 200, 300, 400, 500 })]
        [TestCase(new[] { -1, 0, 1, 2 })]
        [TestCase(new[] { 1 })]
        public void ShouldReturnTrueGivenCollectionWithNoDuplicatedValues(int[] collection)
        {
            //Arrange
            var validator = new Validator();

            //Act
            //Assert
            validator.ValidateDuplicateValues(collection)
                .Should()
                .BeTrue();
        }

        [Test]
        [TestCase(new[] { 1, 2, 3, 1 })]
        [TestCase(new[] { 2, 2, 4, 4 })]
        [TestCase(new[] { 1000, 800, 800, 1, 10 })]
        [TestCase(new[] { -1, 0, -1, 2 })]
        public void ShouldReturnFalseGivenCollectionWithDuplicatedValues(int[] collection)
        {
            //Arrange
            var validator = new Validator();

            //Act
            //Assert
            validator.ValidateDuplicateValues(collection)
                .Should()
                .BeFalse();
        }

        [Test]
        public void ShouldThrowNullReferenceExceptionWhenCollectionIsNull()
        {
            //Arrange
            var validator = new Validator();

            //Act
            //Assert
            FluentActions
                .Invoking(() => validator.ValidateDuplicateValues(null))
                .Should()
                .Throw<NullReferenceException>();
        }
    }
}