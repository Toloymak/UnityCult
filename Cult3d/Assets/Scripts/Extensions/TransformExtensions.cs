using UnityEngine;

namespace Extensions
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
        
        public static (int x, int z) GetXZCellPosition(this Transform transform)
        {
            var position = transform.position;
            return ((int) position.x, (int) position.z);
        }
    }
}