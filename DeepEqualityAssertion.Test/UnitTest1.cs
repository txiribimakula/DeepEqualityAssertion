namespace DeepEqualityAssertion.Test
{
    using NUnit.Framework;
    using System.Dynamic;

    public class Tests
    {
        Comparer comparer;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            comparer = new Comparer();
        }

        static object[] EqualCases =
        {
            new [] { new ClassWithInt() { Number = 1 }, new ClassWithInt() { Number = 1 } },
            new [] {
                new ClassWithClassWithInt() { ClassWithInt = new ClassWithInt() { Number = 1 } },
                new ClassWithClassWithInt() { ClassWithInt = new ClassWithInt() { Number = 1 } }
            },
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
            new [] { new ClassWithInt() { Number = 1 }, new ClassWithInt() { Number = 2 } },
            new [] {
                new ClassWithClassWithInt() { ClassWithInt = new ClassWithInt() { Number = 1 } },
                new ClassWithClassWithInt() { ClassWithInt = new ClassWithInt() { Number = 2 } }
            }
        };
        [TestCaseSource(nameof(NotEqualCases))]
        public void Test_SimpleObject_Is_NotEqual(object item1, object item2) {
            // Act
            var isEqual = comparer.IsEqual(item1, item2);

            // Assert
            Assert.That(isEqual, Is.False);
        }
    }

    public class ClassWithClassWithInt
    {
        public ClassWithInt ClassWithInt { get; set; }
    }

    public class ClassWithInt
    {
        public int Number { get; set; }
    }
}