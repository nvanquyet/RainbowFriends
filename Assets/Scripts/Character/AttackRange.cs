using Assets.Scripts.Interface;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public class AttackRange : MonoBehaviour
    {
        [SerializeField] private Vector3 origin;
        float attackRange { get; set; }
        float distanceAttack { get; set; }
        int numberRay { get; set; }

        float startingAngle = 0;

        private void Start()
        {
            origin = Vector3.zero;
            attackRange = 45;
            distanceAttack = 25;
            numberRay = 50;
        }

        public List<GameObject> ObjectInRange()
        {
            float angle = startingAngle ;
            float distanceRay = attackRange / numberRay;
            List<GameObject> list = new List<GameObject>();
            for(float i = 0; i <= numberRay ; i ++)
            {
                Debug.DrawRay(origin, GetVectorFromAngle(startingAngle), Color.red);
                RaycastHit hit;
                if(Physics.Raycast(origin, GetVectorFromAngle(i),out hit, distanceAttack))
                {
                    Debug.Log(hit.collider.tag);
                    list.Add(hit.collider.gameObject);
                }
                startingAngle -= distanceRay;
            }
            return list;
        }
        public void SetOrigin(Vector3 origin_Clone)
        {
            origin = origin_Clone;
        }

        public void SetForward(Vector3 aim)
        {
            startingAngle = GetAngleFromVector(aim);
        }
        private void Update()
        {
            ObjectInRange();
        }
        float GetAngleFromVector(Vector3 vector)
        {
            vector = vector.normalized;
            float angle = Mathf.Atan2(vector.x,vector.z) * Mathf.Rad2Deg + attackRange / 2;
            if(angle < 0)
            {
                angle += 360;
            }
            return angle;
        }
        Vector3 GetVectorFromAngle(float angle)
        {
            float angleRad = angle * Mathf.PI / 180;
            return new Vector3(Mathf.Sin(angleRad), 0,Mathf.Cos(angleRad));
        }

    }
}

