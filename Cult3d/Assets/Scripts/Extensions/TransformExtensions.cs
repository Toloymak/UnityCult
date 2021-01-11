using Models.Models;
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
        
        public static Coordinates GetXZCellPosition(this Transform transform)
        {
            var position = transform.position;
            return new Coordinates((int) position.x, (int) position.z);
        }
    }
}