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

        static object[] EqualCases =
        {
            new [] { new { Number = 1 }, new { Number = 1 } },
            new [] { new { Text = "some text" }, new { Text = "some text" } }
        };
        [TestCaseSource(nameof(EqualCases))]
        public void Test_SimpleObject_Is_Equal(object item1, object item2) {
            // Act
            var isEqual = comparer.IsEqual(item1, item2);

            // Assert
            Assert.That(isEqual, Is.True);
        }

        static object[] NotEqualCases =
        {
            new [] { new { Number = 1 }, new { Number = 2 } },
            new [] { new { Text = "some text" }, new { Text = "other text" } }
        };
        [TestCaseSource(nameof(NotEqualCases))]
        public void Test_SimpleObject_Is_NotEqual(object item1, object item2) {
            // Act
            var isEqual = comparer.IsEqual(item1, item2);
            
            // Assert
            Assert.That(isEqual, Is.False);
        }
    }
}