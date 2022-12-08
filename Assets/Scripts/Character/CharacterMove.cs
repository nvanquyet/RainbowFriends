using Assets.Scripts.Interface;
using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public class CharacterMove : MonoBehaviour,IMove
    {
        [SerializeField] protected float speed;
        [SerializeField] protected float speedRotate;
        [SerializeField] protected bool useBooster_FastTrack;
        [SerializeField] protected bool useBooster_Rot;
        protected int turnUseBooster_FastTrack;
        protected int turnUseBooster_Rot;
        protected bool canMove;
        Vector3 fw;
        Vector3 right;

        private void Start()
        {
            SetProperties();
        }

        protected virtual void SetProperties()
        {
            speed = 5f;
            useBooster_FastTrack = false;
            useBooster_Rot = false;
            canMove = true;
            fw = Vector3.zero;
            right = Vector3.zero;
            SetNumberTurn_Booster_FastTrack(5);
            SetNumberTurn_Booster_Rot(5);
        }

        public int GetNumberTurn_Booster_FastTrack()
        {
            return turnUseBooster_FastTrack;
        }

        public int GetNumberTurn_Booster_Rot()
        {
            return turnUseBooster_Rot;
        }


        public void ReduceBooster_FastTrack()
        {
            if(turnUseBooster_FastTrack > 0)
            {
                turnUseBooster_FastTrack--;
            }
        }

        public void ReduceBooster_Rot()
        {
            if (turnUseBooster_Rot > 0)
            {
                turnUseBooster_Rot--;
            }
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

        public virtual void Booster_FastTrack(float time)
        {
            if (!useBooster_FastTrack && turnUseBooster_FastTrack > 0)
            {
                ReduceBooster_FastTrack();
                useBooster_FastTrack = true;
                speed *= 2;
                StartCoroutine(Booster_Done(time, "FastTrack"));
            }
        }


        public void Booster_Rot(float time)
        {
            if (!useBooster_Rot && turnUseBooster_Rot > 0)
            {
                ReduceBooster_Rot();
                useBooster_Rot = true;
                StartCoroutine(Booster_Done(time, "Rot"));
            }
            
        }

        IEnumerator Booster_Done(float time,string Key)
        {
            yield return new WaitForSeconds(time);
            switch (Key)
            {
                case "FastTrack":
                    {
                        useBooster_FastTrack = false;
                        speed /= 2;
                        break;
                    }
                case "Rot":
                    {
                        useBooster_Rot = false;
                        break;
                    }
                case "Move":
                    {
                        canMove = true;
                        break;
                    }
            }
        }


        public void NoMove(float time)
        {
            canMove = false;
            StartCoroutine(Booster_Done(time, "Move"));
        }

        private void Update()
        {
            if (!useBooster_FastTrack && Input.GetKeyDown(KeyCode.LeftShift))
            {
                Booster_FastTrack(5f);
            }

            if (!useBooster_FastTrack && Input.GetKeyDown(KeyCode.K))
            {
                Booster_Rot(2f);
            }
        }

        //Test
        private void FixedUpdate()
        {
            MoveCharacter(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
            
        }

        public void SetNumberTurn_Booster_FastTrack(int numberTurn)
        {
            this.turnUseBooster_FastTrack = numberTurn;
        }

        public void SetNumberTurn_Booster_Rot(int numberTurn)
        {
            this.turnUseBooster_Rot = numberTurn;
        }
    }
}

