using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public interface IMove
    {
        void Movement();
    }

    public abstract class CharacterMovement : MonoBehaviour,IMove
    {
        [SerializeField] protected CharacterState state;
        public float speed;
        public bool canMove;
        public abstract void Movement();
        public void KillSpree(float percent)
        {
            this.speed += speed * percent / 100;
        }

        public void NoMove(float time)
        {
            canMove = false;
            StartCoroutine(CanMove(time));
        }

        IEnumerator CanMove(float time)
        {
            yield return new WaitForSeconds(time);
            canMove = true;
        }
    }
}

