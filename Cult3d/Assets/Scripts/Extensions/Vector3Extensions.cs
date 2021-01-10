using System;
using UnityEngine;

namespace Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 GetRoundVector(this Vector3 baseVector)
        {
            return new Vector3((float) Math.Round(baseVector.x),
                               (float) Math.Round(baseVector.y),
                               (float) Math.Round(baseVector.z));
        }
        
        public static Vector3 SetY(this Vector3 baseVector, float y)
        {
            baseVector.y = y;
            return baseVector;
        }
    }
}