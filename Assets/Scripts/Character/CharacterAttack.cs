using Assets.Scripts.InputCharacter;
using Assets.Scripts.Interface;
using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public class CharacterAttack : MonoBehaviour, IAttack
    {
        protected float damage { get; set; }
        [SerializeField] protected AttackRange attackRange;
        [SerializeField] protected bool useBooster;
        [SerializeField] protected float timeUseBooster;
        [SerializeField] protected float distacneUseBooster;

        private void Awake()
        {
            attackRange = GetComponentInChildren<AttackRange>();
            attackRange.SetProperties(45, 25);
            useBooster = false;
            timeUseBooster = 2f;
            distacneUseBooster = 3f;
        }
        

        private void Update()
        {
            attackRange.SetOrigin(transform.position + Vector3.up + transform.forward/3);
            attackRange.SetForward(transform.forward);
            if (Input.GetKeyDown(KeyCode.P))
            {
                Booster_Shockwave(distacneUseBooster);
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                Attack();
                Debug.Log("Attack");
            }
        }

        public void Booster_Shockwave(float distacne)
        {
            if (!useBooster)
            {
                useBooster = true;
                foreach(GameObject child in attackRange.ObjectInRange(distacne))
                {
                    Destroy(child, 0.5f);
                }
            }
            StartCoroutine(Booster_Complete(timeUseBooster));
        }
        IEnumerator Booster_Complete(float time)
        {
            yield return new WaitForSeconds(time);
            useBooster = false;
            Debug.Log("Booster Complete");
        }

        public void Attack()
        {
            GameObject targetObj = attackRange.ObjectInRange();
            if (targetObj)
            {
                Debug.Log("Normal Attack");
                Debug.Log("Attack: " + targetObj.tag);
            }
            else
            {
                   
            }
        }
    }
}

