using Assets.Scripts.Interface;
using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public class CharacterMove : MonoBehaviour,IMove
    {
        [SerializeField] protected float speed;
        [SerializeField] protected float speedRotate;
        [SerializeField] protected bool useBooster;
        protected bool canMove;
        Vector3 fw;
        Vector3 right;

        private void Start()
        {
            useBooster = false;
            canMove = true;
            fw = Vector3.zero;
            right = Vector3.zero;
        }
        public virtual void MoveCharacter(Vector2 direction)
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

        public virtual void Booster_FastTrack(float time)
        {
            if (!useBooster)
            {
                useBooster = true;
                speed *= 2;
                StartCoroutine(Booster_Done(time));
            }
        }


        public void Booster_Rot(float time)
        {
            if (!useBooster)
            {
                useBooster = true;
                canMove = false;
                StartCoroutine(Booster_Done(time));
            }
            
        }

        IEnumerator Booster_Done(float time)
        {
            yield return new WaitForSeconds(time);
            if (canMove)
            {
                speed /= 2;
            }
            else
            {
                canMove = true;
            }
            useBooster = false;
        }




        //Test
        private void Update()
        {
            MoveCharacter(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
            if (!useBooster && Input.GetKeyDown(KeyCode.LeftShift))
            {
                Booster_FastTrack(5f);
            }

            if (!useBooster && Input.GetKeyDown(KeyCode.K))
            {
                Booster_Rot(2f);
            }
        }

    }
}

