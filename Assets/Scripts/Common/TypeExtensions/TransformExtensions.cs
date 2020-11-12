using UnityEngine;

namespace Common.TypeExtensions
{
    public static class TransformExtensions
    {
        public static void DeleteAllChildren(this Transform transform)
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                Object.Destroy(child.gameObject);
            }
        }
    }
}