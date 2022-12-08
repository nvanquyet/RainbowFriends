using Assets.Scripts.Interface;
using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public class CharacterProperties : ObjectProperties, IProperties
    {
        [SerializeField] protected int numberLife;
        bool shieldUp;

        private void Start()
        {
            numberLife = 3;
            shieldUp = false;
        }
        public virtual void Booster_SecondLife()
        {
            numberLife--;
            if(GetNumberLife() > 0)
            {
                Debug.Log("Second Life");
            }
            else
            {
                Debug.Log("Die");
            }
        }

        public virtual void Booster_ShieldUp(float time)
        {
            shieldUp = true;
            Debug.Log("shieldUp: " + shieldUp);
            StartCoroutine(Booster_ShieldUp_Done(time));
        }

        IEnumerator Booster_ShieldUp_Done(float time)
        {
            yield return new WaitForSeconds(time);
            shieldUp = false;
            Debug.Log("shieldUp: " + shieldUp);
        }

        public int GetNumberLife()
        {
            return this.numberLife;
        }

        public void SetNumberLife(int number)
        {
            this.numberLife = number;
        }

    }
}

