namespace DeepEqualityAssertion
{
    using System.Collections;
    using System.Linq;

    public class Comparer
    {
        public bool IsEqual<T>(T x, T y) {
            if (x.GetType().IsPrimitive || x.GetType() == typeof(string)) {
                return x.Equals(y);
            }

            if (x is IEnumerable) {
                var xArray = ((IEnumerable)x).Cast<object>();
                var yArray = ((IEnumerable)y).Cast<object>();
                for (int i = 0; i < xArray.Count(); i++) {
                    bool isEqual = IsEqual(xArray.ElementAt(i), yArray.ElementAt(i));
                    if(!isEqual) {
                        return false;
                    }
                }
                return true;
            }

            var xProperties = x.GetType().GetProperties();
            var yProperties = y.GetType().GetProperties();

            for (int i = 0; i < xProperties.Length; i++) {
                var xValue = xProperties[i].GetValue(x);
                var yValue = yProperties[i].GetValue(y);

                bool isEqual = IsEqual(xValue, yValue);
                if (!isEqual) {
                    return false;
                }
            }

            return true;
        }
    }
}
