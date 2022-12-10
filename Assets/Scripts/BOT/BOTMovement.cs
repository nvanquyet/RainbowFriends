using Assets.Scripts.Character;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.BOT
{
    public class BOTMovement : CharacterMovement
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
            canMove = true;
        }


        public override void Movement()
        {
            navMesh.SetDestination(target.transform.position);
        }

        //Test
        private void Update()
        {
            target = targetAI.FindPlayer();
        }
        private void FixedUpdate()
        {
            if (target)
            {
                if (canMove)
                {
                    Movement();
                }
                else
                {
                    navMesh.SetDestination(transform.position);
                }
            }
        }

    }
}

