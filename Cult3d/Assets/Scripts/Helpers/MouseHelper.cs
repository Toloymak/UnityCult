using UnityEngine;

namespace Helpers
{
    public interface IMouseHelper
    {
        bool TryGetMousePosition(out Vector3 position);
    }

    public class MouseHelper : IMouseHelper
    {
        public bool TryGetMousePosition(out Vector3 position)
        {
            if (Camera.main == null)
            {
                position = default;
                return false;
            }
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, int.MaxValue))
            {
                position = hitInfo.point;
                return true;
            }

            position = default;
            return false;
        }
    }
}