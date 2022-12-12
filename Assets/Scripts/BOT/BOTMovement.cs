using Assets.Scripts.Character;
using Assets.Scripts.StateControl;
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
            state = GetComponent<CharacterState>();
            state.stateMove = StateMovement.Idle;
            canMove = true;
        }

        public override void Movement()
        {
            if (canMove)
            {
                navMesh.SetDestination(targetAI.target.transform.position);
                state.stateMove = StateMovement.Walk;
            }
            else
            {
                navMesh.SetDestination(transform.position);
                state.stateMove = StateMovement.Idle;
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

