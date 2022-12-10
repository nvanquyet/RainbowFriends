using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : CharacterMovement
    {
        [SerializeField] protected Vector2 input;
        Vector3 fw;
        Vector3 right;

        private void Start()
        {
            canMove = true;
        }

        public override void Movement()
        {
            MoveCharacter(input);
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
                }
                else
                {
                    fw = transform.forward;
                    right = transform.right;
                }

            }
        }
    }
}

