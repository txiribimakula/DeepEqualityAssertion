namespace DeepEqualityAssertion
{
    public class Comparer
    {
        public bool IsEqual<T>(T x, T y) {
            var xProperties = x.GetType().GetProperties();
            var yProperties = y.GetType().GetProperties();

            for (int i = 0; i < xProperties.Length; i++) {
                var xValue = xProperties[i].GetValue(x);
                var yValue = yProperties[i].GetValue(y);

                if(xProperties[i].PropertyType.IsPrimitive) {
                    if (!xValue.Equals(yValue)) {
                        return false;
                    }
                } else {
                    bool isEqual = IsEqual(xValue, yValue);
                    if (!isEqual) {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
