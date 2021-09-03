namespace DeepEqualityAssertion.Test
{
    using NUnit.Framework;
    using System.Collections.Generic;
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
            new [] { 1, 1},
            new [] { "some text", "some text"},
            new [] { new List<int>() { 1, 2 }, new List<int>() { 1, 2 } },
            new [] { new List<int>() { 1, 2 }.ToArray(), new List<int>() { 1, 2 }.ToArray() },
            new [] { new ClassWithInt() { Number = 1 }, new ClassWithInt() { Number = 1 } },
            new [] {
                new ClassWithClassWithInt() { ClassWithInt = new ClassWithInt() { Number = 1 } },
                new ClassWithClassWithInt() { ClassWithInt = new ClassWithInt() { Number = 1 } }
            },
            new [] {
                new ClassWithClassWithIntAndClassWithIntAndString() {
                    ClassWithInt = new ClassWithInt() { Number = 1 },
                    ClassWithIntAndString = new ClassWithIntAndString() { Number = 1, Text = "some text" }
                },
                new ClassWithClassWithIntAndClassWithIntAndString() {
                    ClassWithInt = new ClassWithInt() { Number = 1 },
                    ClassWithIntAndString = new ClassWithIntAndString() { Number = 1, Text = "some text" }
                }
            }
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
            new [] { 1, 2},
            new [] { "some text", "other text"},
            new [] { new List<int>() { 1, 2 }, new List<int>() { 1, 3 } },
            new [] { new List<int>() { 1, 2 }.ToArray(), new List<int>() { 1, 3 }.ToArray() },
            new [] { new ClassWithInt() { Number = 1 }, new ClassWithInt() { Number = 2 } },
            new [] {
                new ClassWithClassWithInt() { ClassWithInt = new ClassWithInt() { Number = 1 } },
                new ClassWithClassWithInt() { ClassWithInt = new ClassWithInt() { Number = 2 } }
            },
            new [] {
                new ClassWithClassWithIntAndClassWithIntAndString() {
                    ClassWithInt = new ClassWithInt() { Number = 1 },
                    ClassWithIntAndString = new ClassWithIntAndString() { Number = 1, Text = "some text" }
                },
                new ClassWithClassWithIntAndClassWithIntAndString() {
                    ClassWithInt = new ClassWithInt() { Number = 1 },
                    ClassWithIntAndString = new ClassWithIntAndString() { Number = 1, Text = "other text" }
                }
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

    public class ClassWithClassWithIntAndClassWithIntAndString
    {
        public ClassWithIntAndString ClassWithIntAndString { get; set; }

        public ClassWithInt ClassWithInt { get; set; }
    }

    public class ClassWithIntAndString
    {
        public int Number { get; set; }

        public string Text { get; set; }
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