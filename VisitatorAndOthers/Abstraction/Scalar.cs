using System.Collections;

namespace Composite.Abstraction
{
    public class Scalar<T> : IEnumerable<T> where T : Scalar<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            yield return (T) this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
