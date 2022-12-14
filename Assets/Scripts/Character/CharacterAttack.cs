using Assets.Scripts.StateControl;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public interface IAttack
    {
        void Attack();
        void KillingSpree(float percent);
    }
    public abstract class CharacterAttack : MonoBehaviour, IAttack
    {
        [SerializeField] protected CharacterState state;
        [SerializeField] protected AttackRange attackRange;
        [SerializeField] protected float attackDelay;
        [SerializeField] protected float percentIncrease;
        [SerializeField] protected float timeAttack = 0;
        protected bool canAttack;
        protected float m_attackDelay;

        private void Awake()
        {
            this.gameObject.AddComponent<AttackRange>();
            attackRange = GetComponent<AttackRange>();
        }

        protected abstract void SetProperties();

        protected void ReadyAttack()
        {
            if(m_attackDelay < attackDelay)
            {
                m_attackDelay += Time.deltaTime;
                canAttack = false;
            }
            else
            {
                canAttack = true;
            }
        }

        public virtual void Attack()
        {
            if (canAttack)
            {
                GameObject targetObj = attackRange.ObjectInRange();
                if (targetObj && (targetObj.tag.Equals("Player") || targetObj.tag.Equals("Enemy")))
                {
                    timeAttack = Time.time;
                    if (IsAttackFirst(timeAttack, targetObj.GetComponent<CharacterAttack>().GetTimeAttack()) 
                        && targetObj.GetComponent<CharacterProperties>().IsAlive()
                        && !targetObj.GetComponent<CharacterProperties>().isSheildUp)
                    {
                        state.stateAttack = StateAttack.AttackNormal;
                        targetObj.GetComponent<CharacterProperties>().Dead();
                        this.KillingSpree(percentIncrease);
                        return;
                    }
                }
            }
            state.stateAttack = StateAttack.NoAttack;
        }

        bool IsAttackFirst(float timeObjA,float timeObjB)
        {
            if(timeObjA > timeObjB)
            {
                return true;
            }
            return false;
        }

        public float GetTimeAttack()
        {
            return timeAttack;
        }

        public void KillingSpree(float percent)
        {
            attackRange.SetProperties(percent);
            gameObject.GetComponent<CharacterMovement>().KillSpree(percent);
            this.gameObject.AddComponent<CharacterModel>();
            if (GetComponentInChildren<CharacterModel>())
            {
                GetComponentInChildren<CharacterModel>().KillingSpree(percent);
            }
        }
    }
}

