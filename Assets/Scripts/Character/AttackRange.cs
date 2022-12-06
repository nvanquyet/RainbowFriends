using Assets.Scripts.Interface;
using Assets.Scripts.Logic;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public class AttackRange : MonoBehaviour
    {
        [SerializeField] private Vector3 origin;
        [SerializeField] private LayerMask layerMask;
        private LogicFindObjNear objNear;
        float attackRange { get; set; }
        float distanceAttack { get; set; }
        int numberRay { get; set; }

        float startingAngle = 0;

        private void Awake()
        {
            this.gameObject.AddComponent<LogicFindObjNear>();
            objNear = GetComponent<LogicFindObjNear>();
        }

        private void Start()
        {
            origin = Vector3.zero;
            numberRay = 50;
        }
        public void SetOrigin(Vector3 origin_Clone)
        {
            origin = origin_Clone;
        }

        public void SetForward(Vector3 aim)
        {
            startingAngle = GetAngleFromVector(aim);
        }

        //Normal Attack
        public GameObject ObjectInRange()
        {
            float angle = startingAngle ;
            float distanceRay = attackRange / numberRay;
            List<GameObject> list = new List<GameObject>();
            for(float i = 0; i <= numberRay ; i ++)
            {
                Debug.DrawRay(origin, GetVectorFromAngle(startingAngle), Color.red);
                RaycastHit hit;
                if(Physics.Raycast(origin, GetVectorFromAngle(startingAngle),out hit, distanceAttack))
                {
                    if (hit.collider.tag.Equals("Enemy"))
                    {
                        if (!list.Contains(hit.collider.gameObject))
                        {
                             list.Add(hit.collider.gameObject);
                        }
                    }
                }
                startingAngle -= distanceRay;
            }
            Debug.Log(list.Count);
            list.Remove(this.gameObject);
            return objNear.ObjNearest(list);
        }

        //Use for Booster
        public List<GameObject> ObjectInRange(float distance)
        {
            List<GameObject> listBooster = new List<GameObject>();
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
            {
                if (hit.collider.tag.Equals("Enemy"))
                {
                    listBooster.Add(hit.collider.gameObject);
                }
            }
            return listBooster;
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


        public void SetProperties(float angle, float distance) 
        {
            this.attackRange = angle;
            this.distanceAttack = distance;
        }
        public virtual void SetProperties(float angle)
        {
            this.distanceAttack = 25;
            this.attackRange = angle;
        }
    }
}

