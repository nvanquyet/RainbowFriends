using Assets.Scripts.Interface;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public class CharacterAttack : MonoBehaviour, IAttack
    {
        float damage { get; set; }
        [SerializeField] AttackRange attackRange;

        private void Awake()
        {
            attackRange = GetComponentInChildren<AttackRange>();
        }

        private void Update()
        {
            attackRange.SetOrigin(transform.position + transform.forward/2);
            attackRange.SetForward(transform.forward);
        }

        public void Booster_StrongPunch(float radius)
        {
            
        }

        public void Attack()
        {
            if(attackRange.ObjectInRange().Count > 0)
            {
                foreach(GameObject gameObject in attackRange.ObjectInRange())
                {
                    Debug.Log(gameObject.name);
                }
            }
        }
    }
}

