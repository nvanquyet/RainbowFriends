using Assets.Scripts.Logic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Character
{
    public class BOTMovement : CharacterMove
    {
        [SerializeField] private NavMeshAgent navMesh;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private GameObject target;
        private LogicFindObjNear objNear;

        private void Awake()
        {
            navMesh = GetComponent<NavMeshAgent>();
            this.gameObject.AddComponent<LogicFindObjNear>();
            objNear = GetComponent<LogicFindObjNear>();
        }
        private void Start()
        {
            speed = 5f;
            useBooster = false;
            canMove = true;
        }
        public override void MoveCharacter(Vector2 direction)
        {

        }
        public void MoveCharacter()
        {
            navMesh.SetDestination(target.transform.position);
        }

        void FindPlayer()
        {
            List<GameObject> list = new List<GameObject>();
            Collider[] colliders =  Physics.OverlapSphere(transform.position, radius, layerMask);
            foreach(Collider collider in colliders)
            {
                list.Add(collider.gameObject);
            }
            list.Remove(this.gameObject);
            target = objNear.ObjNearest(list);
        }

        //Test
        private void Update()
        {
            FindPlayer();
            MoveCharacter();
        }

    }
}

