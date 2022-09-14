using System;
using System.Collections.Generic;
using Application.Common.Interfaces;
using Domain.Exceptions;
using FluentAssertions;
using Infrastructure.Services;
using Moq;
using NUnit.Framework;

namespace Infrastructure.UnitTests.Services
{
    public class SortServiceTests
    {
        private Mock<IValidator> lengthValidatorMock = null!;

        [SetUp]
        public void Setup()
        {
            lengthValidatorMock = new Mock<IValidator>();
        }

        [Test]
        public void ShouldReturnValidCollectionGivenValidParameters()
        {
            //Arrange
            var words = new[] { "Sonia", "Maria", "Wood", "Dempster" };
            var sortOrder = new[] { 4, 1, 2, 3 };
            lengthValidatorMock
                .Setup(l => l.ValidateEqualLength(words, sortOrder))
                .Returns(true)
                .Verifiable();
            lengthValidatorMock
                .Setup(l => l.ValidateDuplicateValues(sortOrder))
                .Returns(true)
                .Verifiable();
            lengthValidatorMock
                .Setup(l => l.ValidateConsecutiveAndIncreasingSequentiality(sortOrder))
                .Returns(true)
                .Verifiable();
            var sortService = new SortService(lengthValidatorMock.Object);

            //Act
            var sortedWords = sortService.SortByPosition(words, sortOrder);

            //Assert
            lengthValidatorMock.VerifyAll();
            sortedWords.Should().BeEquivalentTo("Dempster", "Sonia", "Maria", "Wood");
        }

        [Test]
        public void ShouldThrowDuplicatedPositionExceptionGivenDuplicatedPositions()
        {
            //Arrange
            var words = new[] { "Canada", "Mexico", "USA", "Poland" };
            var sortOrder = new[] { 4, 1, 2, 2, };
            lengthValidatorMock
               .Setup(l => l.ValidateEqualLength(words, sortOrder))
               .Returns(true);
            lengthValidatorMock
               .Setup(l => l.ValidateDuplicateValues(sortOrder))
               .Returns(false)
               .Verifiable();
            var sortService = new SortService(lengthValidatorMock.Object);

            //Act
            //Assert
            FluentActions
                .Invoking(() => sortService.SortByPosition(words, sortOrder))
                .Should()
                .Throw<DuplicatedPositionException>();
        }

        [Test]
        public void ShouldThrowNonSequentialCollectionExceptionGivenANonSequentialCollection()
        {
            //Arrange
            var words = new[] { "Barcelona", "Real Madrid", "PSG", "Bayern", "Juventus" };
            var sortOrder = new[] { 1000, 2000, 3000, 4000, 5000 };
            lengthValidatorMock
                .Setup(l => l.ValidateEqualLength(words, sortOrder))
                .Returns(true)
                .Verifiable();
            lengthValidatorMock
                .Setup(l => l.ValidateDuplicateValues(sortOrder))
                .Returns(true)
                .Verifiable();
            lengthValidatorMock
                .Setup(l => l.ValidateConsecutiveAndIncreasingSequentiality(sortOrder))
                .Returns(false)
                .Verifiable();
            var sortService = new SortService(lengthValidatorMock.Object);

            //Act
            //Assert
            FluentActions
                .Invoking(() => sortService.SortByPosition(words, sortOrder))
                .Should()
                .Throw<NonSequentialCollectionException>();
        }

        [Test]
        public void ShouldThrowWordAndPositionsMiscountExceptionGivenMorePositionsThanWords()
        {
            //Arrange
            var words = new[] { "Miami", "West Palm Beach" };
            var sortOrder = new[] { 3, 4, 2, 1 };
            lengthValidatorMock
               .Setup(l => l.ValidateEqualLength(words, sortOrder))
               .Returns(false);
            var sortService = new SortService(lengthValidatorMock.Object);

            //Act
            //Assert
            FluentActions
                .Invoking(() => sortService.SortByPosition(words, sortOrder))
                .Should()
                .Throw<WordsAndPositionsMiscountException>();
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(new string[0], null)]
        [TestCase(null, new int[0])]
        public void ShouldThrowNullReferenceExceptionGivenNullParameters(string[] words, int[] positions)
        {
            //Arrange
            lengthValidatorMock
               .Setup(l => l.ValidateEqualLength(It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<int>>()))
               .Returns(true);
            var sortService = new SortService(lengthValidatorMock.Object);

            //Act
            //Assert
            FluentActions
                .Invoking(() => sortService.SortByPosition(words, positions))
                .Should()
                .Throw<NullReferenceException>();
        }
    }
}