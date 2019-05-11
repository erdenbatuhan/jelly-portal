using UnityEngine;

namespace Extensions {

    public static class Vector2Extension {

        /* ----- Class Constants ----- */

        /* ----- Cached Variables (Components) ----- */

        /* ----- Editor Variables ----- */

        /* ----- Class Variables ----- */

        public static Vector2 Rotate(Vector2 vectorToBeRotated, float rotationDegree) {
            float rotationDegreeInRad = Mathf.Deg2Rad * rotationDegree;

            float newX = (Mathf.Cos(rotationDegreeInRad) * vectorToBeRotated.x) - (Mathf.Sin(rotationDegreeInRad) * vectorToBeRotated.y);
            float newY = (Mathf.Sin(rotationDegreeInRad) * vectorToBeRotated.x) + (Mathf.Cos(rotationDegreeInRad) * vectorToBeRotated.y);

            return new Vector2(newX, newY);
        }

        /* ----- Getters & Setters ----- */
    }
}

