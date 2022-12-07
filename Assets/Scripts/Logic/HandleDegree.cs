using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class HandleDegree : MonoBehaviour
    {
        public float GetAngleFromVector(Vector3 vector,float degree)
        {
            vector = vector.normalized;
            float angle = Mathf.Atan2(vector.x, vector.z) * Mathf.Rad2Deg + degree / 2;
            if (angle < 0)
            {
                angle += 360;
            }
            return angle;
        }

        public Vector3 GetVectorFromAngle(float angle)
        {
            float angleRad = angle * Mathf.PI / 180;
            return new Vector3(Mathf.Sin(angleRad), 0, Mathf.Cos(angleRad));
        }

    }
}