using Assets.Scripts.Interface;
using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public class CharacterProperties : MonoBehaviour, IProperties
    {
        [SerializeField] float maxHp;
        [SerializeField] float numberLife { get; set; }
        float hp { get; set; }
        bool shieldUp;

        private void Start()
        {
            numberLife = 3;
            shieldUp = false;
            hp = maxHp;
        }
        public virtual void Booster_SecondLife()
        {
            numberLife--;
            if(numberLife > 0)
            {
                Debug.Log("Second Life");
                hp = maxHp;
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

        public virtual void TakeDamage(float damage)
        {
            if (!shieldUp)
            {
                hp -= damage;
                if(hp > 0)
                {
                    Debug.Log(hp);
                }
                else
                {
                    Booster_SecondLife();
                }
            }
        }

  
    }
}

