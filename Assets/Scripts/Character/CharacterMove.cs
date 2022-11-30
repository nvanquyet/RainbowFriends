using Assets.Scripts.Interface;
using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public class CharacterMove : MonoBehaviour,IMove
    {
        [SerializeField] private float speed;
        [SerializeField] private bool useBooster;

        private void Start()
        {
            useBooster = false;
        }
        public virtual void MoveCharacter(Vector2 direction)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(direction.x, 0, direction.y), Time.deltaTime * speed);
        }

        public virtual void Booster_FastTrack(float time)
        {
            useBooster = true;
            speed *= 2;
            Debug.Log(speed);
            StartCoroutine(Booster_FastTrack_Done(time));
        }

        IEnumerator Booster_FastTrack_Done(float time)
        {
            yield return new WaitForSeconds(time);
            speed /= 2;
            useBooster = false;
            Debug.Log(speed);
        }


        //Test
        private void Update()
        {
            MoveCharacter(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
            if (Input.GetKeyDown(KeyCode.LeftShift) && !useBooster)
            {
                Booster_FastTrack(5f);
            }
        }
    }
}

