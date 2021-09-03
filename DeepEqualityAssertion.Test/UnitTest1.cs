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
            var x = new SingleIntObject(1);
            var y = new SingleIntObject(1);

            // Act
            var isEqual = comparer.IsEqual(x, y);

            // Assert
            Assert.That(isEqual, Is.True);
        }

        [Test]
        public void Test_SimpleObject_Is_NotEqual() {
            // Arrange
            var x = new SingleIntObject(1);
            var y = new SingleIntObject(2);

            // Act
            var isEqual = comparer.IsEqual(x, y);

            // Assert
            Assert.That(isEqual, Is.False);
        }
    }

    public class SingleIntObject
    {
        public int Number { get; set; }

        public SingleIntObject(int number) {
            this.Number = number;
        }
    }
}