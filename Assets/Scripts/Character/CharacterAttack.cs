using Assets.Scripts.InputCharacter;
using Assets.Scripts.Interface;
using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public class CharacterAttack : MonoBehaviour, IAttack
    {
        float damage { get; set; }
        [SerializeField] AttackRange attackRange;
        [SerializeField] InputCtrl inputCtrl;
        [SerializeField] bool useBooster;
        [SerializeField] float timeUseBooster;
        [SerializeField] float distacneUseBooster;

        private void Awake()
        {
            attackRange = GetComponentInChildren<AttackRange>();S
            inputCtrl = GetComponentInChildren<InputCtrl>();
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
            if (inputCtrl.attack)
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
        }

        public virtual void Attack()
        {
            if (!useBooster)
            {
                if (attackRange.ObjectInRange() != null)
                {
                    Debug.Log("enemy; "+ attackRange.ObjectInRange().tag);
                }
                else
                {
                    Debug.Log("No enemy");
                }
            }
        }
    }
}

