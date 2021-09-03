namespace DeepEqualityAssertion.Test
{
    using NUnit.Framework;

    public class Tests
    {
        Comparer comparer;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            comparer = new Comparer();
        }

        [Test]
        public void Test_SimpleObject_Is_Equal() {
            // Arrange
            var x = new { Number = 1 };
            var y = new { Number = 1 };

            // Act
            var isEqual = comparer.IsEqual(x, y);

            // Assert
            Assert.That(isEqual, Is.True);
        }

        [Test]
        public void Test_SimpleObject_Is_NotEqual() {
            // Arrange
            var x = new { Number = 1 };
            var y = new { Number = 2 };

            // Act
            var isEqual = comparer.IsEqual(x, y);

            // Assert
            Assert.That(isEqual, Is.False);
        }
    }
}