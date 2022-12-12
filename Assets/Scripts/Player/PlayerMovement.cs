using Assets.Scripts.Character;
using Assets.Scripts.InputCharacter;
using Assets.Scripts.StateControl;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : CharacterMovement
    {
        [SerializeField] protected InputCtrl input;
        Vector3 fw;
        Vector3 right;
        private void Awake()
        {
            input = GetComponentInChildren<InputCtrl>();
        }

        private void Start()
        {
            state = GetComponent<CharacterState>();
            state.stateMove = StateMovement.Idle;
            canMove = true;
            speed = 5f;
        }


        private void FixedUpdate()
        {
            Movement();
        }
        public override void Movement()
        {
            MoveCharacter(input.direction);
        }

        public void MoveCharacter(Vector2 direction)
        {
            if (canMove)
            {
                if (direction != Vector2.zero)
                {
                    Vector3 movePos = Vector3.zero;
                    if(direction.x > 0)
                    {
                        movePos += right;
                    }
                    if (direction.x < 0)
                    {
                        movePos -= right;
                    }
                    if (direction.y > 0)
                    {
                        movePos += fw;
                    }
                    if (direction.y < 0)
                    {
                        movePos -= fw;
                    }
                    //Position
                    transform.position = Vector3.Lerp(transform.position, transform.position + movePos, Time.deltaTime * speed);

                    //Rotation
                    if (movePos != Vector3.zero)
                    {
                        transform.forward = movePos;
                    }
                    state.stateMove = StateMovement.Walk;
                }
                else
                {
                    fw = transform.forward;
                    right = transform.right;
                    state.stateMove = StateMovement.Idle;
                }

            }
            else
            {
                state.stateMove = StateMovement.Idle;
            }
           
        }
    }
}

