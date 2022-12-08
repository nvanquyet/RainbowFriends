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

        private void Awake()
        {
            this.gameObject.AddComponent<LogicFindObjNear>();
            objNear = GetComponent<LogicFindObjNear>();
        }

        public GameObject FindPlayer()
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

