using Assets.Scripts.Interface;
using Assets.Scripts.Booster;
using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public abstract class CharacterMovement : MonoBehaviour,IMove
    {
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

