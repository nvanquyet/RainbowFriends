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
        private HandleDegree handleDegree;
        float attackRange { get; set; }
        float distanceAttack { get; set; }
        int numberRay { get; set; }

        float startingAngle = 0;

        private void Awake()
        {
            this.gameObject.AddComponent<LogicFindObjNear>();
            this.gameObject.AddComponent<HandleDegree>();
            objNear = GetComponent<LogicFindObjNear>();
            handleDegree = GetComponent<HandleDegree>();
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
            startingAngle = handleDegree.GetAngleFromVector(aim,attackRange);
        }

        //Normal Attack
        public GameObject ObjectInRange()
        {
            float angle = startingAngle ;
            float distanceRay = attackRange / numberRay;
            List<GameObject> list = new List<GameObject>();
            for(float i = 0; i <= numberRay ; i ++)
            {
                //Debug.DrawRay(origin, handleDegree.GetVectorFromAngle(startingAngle), Color.red);
                RaycastHit hit;
                if(Physics.Raycast(origin, handleDegree.GetVectorFromAngle(startingAngle),out hit, distanceAttack))
                {
                    if (hit.collider.tag.Equals("Enemy") || hit.collider.tag.Equals("Player"))
                    {
                        if (!list.Contains(hit.collider.gameObject))
                        {
                             list.Add(hit.collider.gameObject);
                        }
                    }
                }
                startingAngle -= distanceRay;
            }
            list.Remove(this.gameObject);
            return objNear.ObjNearest(list);
        }

        //Use for Booster
        public List<GameObject> ObjectInRange(float distance)
        {
            List<GameObject> listBooster = new List<GameObject>();
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.forward, distance,layerMask);
            foreach(RaycastHit hit in hits)
            {
                if (hit.collider.tag.Equals("Enemy") || hit.collider.tag.Equals("Player"))
                {
                    if (!listBooster.Contains(hit.collider.gameObject)) 
                    {
                        listBooster.Add(hit.collider.gameObject);
                    }
                }
            }
            return listBooster;
        }


        public void SetProperties(float angle, float distance) 
        {
            this.attackRange = angle;
            this.distanceAttack = distance;
        }
        public virtual void SetProperties(float mutilple)
        {
            this.distanceAttack += this.distanceAttack * mutilple / 100;
        }
    }
}

