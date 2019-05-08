using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class Vector2Extension
    {
        public static Vector2 Rotate(Vector2 vectorToBeRotated, float betaInDegrees)
        {
            float betaInRadians = Mathf.Deg2Rad * betaInDegrees;
            float newXComponent = (Mathf.Cos(betaInRadians) * vectorToBeRotated.x) - (Mathf.Sin(betaInRadians) * vectorToBeRotated.y);
            float newYComponent = (Mathf.Sin(betaInRadians) * vectorToBeRotated.x) + (Mathf.Cos(betaInRadians) * vectorToBeRotated.y);

            return new Vector2(newXComponent, newYComponent);
        }
    }
}

