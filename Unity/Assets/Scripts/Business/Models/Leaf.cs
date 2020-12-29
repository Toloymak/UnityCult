using System.Collections.Generic;

namespace Business.Models
{
    public class Leaf<T>
    {
        public T Object { get; set; }
        public IList<Leaf<T>> Children { get; set; }
        public Leaf<T> Parent { get; set; }

        public override string ToString()
        {
            return $"Leaf of {Object.ToString()}";
        }
    }
}