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
            if ((target.transform.position - transform.position).magnitude <= 5 * 25)
            {
                Booster_FastTrack(2f);
            }
            if ((target.transform.position - transform.position).magnitude <= 5)
            {
                canMove = false;
            }
            else
            {
                canMove = true;
            }

        }

        //Test
        private void Update()
        { 
            if(!target)
            {
                target = targetAI.FindPlayer();
            }
            else
            {
                if (canMove)
                {
                    MoveCharacter();
                }
            }
        }

    }
}

