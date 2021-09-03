namespace DeepEqualityAssertion
{
    public class Comparer
    {
        public bool IsEqual(object x, object y) {
            var xProperties = x.GetType().GetProperties();
            var yProperties = y.GetType().GetProperties();

            for (int i = 0; i < xProperties.Length; i++) {
                var xValue = xProperties[i].GetValue(x);
                var yValue = yProperties[i].GetValue(y);

                if (!xValue.Equals(yValue)) {
                    return false;
                }
            }

            return true;
        }
    }
}
