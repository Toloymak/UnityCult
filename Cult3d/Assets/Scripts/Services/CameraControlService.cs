using UnityEngine;

namespace Services
{
    public class CameraControlService
    {
        private const float CameraSpeed = 10f;
        
        public void MoveCamera()
        {
            MoveCamera(GetDirectionVector());
        }

        private static void MoveCamera(Vector3 vector3)
        {
            if (vector3 != default && !(Camera.main is null))
                Camera.main.transform.position += vector3 * CameraSpeed * Time.deltaTime;
        }

        private static Vector3 GetDirectionVector()
        {
            var vector3 = new Vector3();

            if (Input.GetKey("up"))
                vector3 += Vector3.forward;

            if (Input.GetKey("down"))
                vector3 += Vector3.back;

            if (Input.GetKey("right"))
                vector3 += Vector3.right;

            if (Input.GetKey("left"))
                vector3 += Vector3.left;
            return vector3;
        }
    }
}