using System.Collections.Generic;
using Leopotam.Ecs;

namespace Common.TypeExtensions
{
    public static class EcsFilterExtensions
    {
        public static IList<T> GetComponents<T>(this EcsFilter<T> filter)
            where T : class
        {
            var newList = new List<T>();

            foreach (var i in filter)
            {
                var item = filter.Get1[i];
                
                if (item != null)
                    newList.Add(item);
                else
                    return newList;
            }

            return newList;
        }
    }
}