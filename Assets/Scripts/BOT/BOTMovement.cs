using Assets.Scripts.Character;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.BOT
{
    public class BOTMovement : CharacterMove
    {
        [SerializeField] private NavMeshAgent navMesh;
        private BOTTarget targetAI;
        private GameObject target;

        private void Awake()
        {
            targetAI = GetComponent<BOTTarget>();
            navMesh = GetComponent<NavMeshAgent>();
        }
        private void Start()
        {
        }

        protected override void SetProperties()
        {
            speed = 5f;
            useBooster_FastTrack = false;
            useBooster_Rot = false;
            canMove = true;
            SetNumberTurn_Booster_FastTrack(1);
            SetNumberTurn_Booster_Rot(1);
        }

        public void Movement()
        {
            navMesh.SetDestination(target.transform.position);
            if ((target.transform.position - transform.position).magnitude <= 5 * 25)
            {
                Booster_FastTrack(2f);
            }
        }

        //Test
        private void Update()
        {
            target = targetAI.FindPlayer();
            if (target)
            {
                if ((target.transform.position - transform.position).magnitude <= 5)
                {
                    canMove = false;
                }
                else
                {
                    canMove = true;
                }
            }
        }
        private void FixedUpdate()
        {
            if (target)
            {
                if (canMove)
                {
                    Movement();
                }
            }
        }

    }
}

