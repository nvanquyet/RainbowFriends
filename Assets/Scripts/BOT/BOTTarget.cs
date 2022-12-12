using Assets.Scripts.Logic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.BOT
{
    public class BOTTarget : MonoBehaviour
    {
        private LogicFindObjNear objNear;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] List<GameObject> list = new List<GameObject>();
        public GameObject target;

        private void Awake()
        {
            this.gameObject.AddComponent<LogicFindObjNear>();
            objNear = GetComponent<LogicFindObjNear>();
        }

        private void Update()
        {
            target = FindPlayer();
        }

        protected GameObject FindPlayer()
        {
            list.Clear();
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layerMask);
            foreach (Collider collider in colliders)
            {
                list.Add(collider.gameObject);
            }
            list.Remove(this.gameObject);
            return objNear.ObjNearest(list);
        }

    }
}

