using FluentAssertions;
using Infrastructure.Extensions;
using NUnit.Framework;

namespace Infrastructure.UnitTests.Extensions
{
    public class ArrayExtensionsTests
    {
        [Test]
        public void ShouldReturnValidItemGivenValidIndex()
        {
            //Arrange
            var expectedItem = 4;
            var array = new[] { 1, 2, 3, expectedItem, 5 };
            var index = 3;

            //Act
            array.TryGetElement(index, out int element).Should().BeTrue();

            //Assert
            element.Should().Be(expectedItem);
        }

        [Test]
        [TestCase(new[] { 800, 1500, 567 }, -400)]
        [TestCase(new[] { 653, 234, 2345, 4 }, 999)]
        [TestCase(new int[0], 0)]
        public void ShouldReturnFalseGivenIndexOutOfRange(int[] array, int index)
        {
            //Act
            array.TryGetElement(index, out int element).Should().BeFalse();

            //Assert
            element.Should().Be(default);
        }
    }
}