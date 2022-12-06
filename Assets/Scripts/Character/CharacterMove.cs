using Assets.Scripts.Interface;
using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public class CharacterMove : MonoBehaviour,IMove
    {
        [SerializeField] protected float speed;
        [SerializeField] protected bool useBooster;
        protected bool canMove;

        private void Start()
        {
            useBooster = false;
            canMove = true;
        }
        public virtual void MoveCharacter(Vector2 direction)
        {
            if (canMove)
            {
                if (direction != Vector2.zero)
                {
                    //Rotation
                    transform.forward = new Vector3(direction.x, 0, direction.y);
                    //Position
                    transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(direction.x, 0, direction.y), Time.deltaTime * speed);
                }
            }
        }

        public virtual void Booster_FastTrack(float time)
        {
            useBooster = true;
            speed *= 2;
            Debug.Log(speed);
            StartCoroutine(Booster_Done(time));
        }


        public void Booster_Rot(float time)
        {
            useBooster = true;
            canMove = false;
            StartCoroutine(Booster_Done(time));
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

