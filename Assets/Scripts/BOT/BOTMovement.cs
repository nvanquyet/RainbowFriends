using Assets.Scripts.Character;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.BOT
{
    public class BOTMovement : CharacterMovement
    {
        [SerializeField] private NavMeshAgent navMesh;
        private BOTTarget targetAI;

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
            if (canMove)
            {
                navMesh.SetDestination(targetAI.target.transform.position);
            }
            else
            {
                navMesh.SetDestination(transform.position);
            }
        }

        private void FixedUpdate()
        {
            if (targetAI.target)
            {
              Movement();
            }
        }

    }
}

