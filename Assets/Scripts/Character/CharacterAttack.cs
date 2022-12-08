using Assets.Scripts.BOT;
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
        [SerializeField] protected int numberTurnUseBooster;
        [SerializeField] protected float distacneUseBooster;
        [SerializeField] protected float attackDelay;
        [SerializeField] protected float timeAttack;
        protected bool canAttack;
        protected float m_attackDelay;

        private void Awake()
        {
            attackRange = GetComponentInChildren<AttackRange>();
        }

        private void Start()
        {
            this.SetProperties();
        }

        protected virtual void SetProperties()
        {
            timeAttack = 0;
            attackRange.SetProperties(45,10);
            useBooster = false;
            timeUseBooster = 2f;
            distacneUseBooster = 3f;
            this.SetNumberTurn_Booster_Shockwave(5);
            attackDelay = 0;
            m_attackDelay = 0;
        }

        private void Update()
        {
            ReadyAttack();
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

        public void Booster_Shockwave(float distacne)
        {
            if (!useBooster && numberTurnUseBooster > 0)
            {
                ReduceBooster_Shockwave();
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
            if (canAttack)
            {
                GameObject targetObj = attackRange.ObjectInRange();
                if (targetObj && (targetObj.tag.Equals("Player") || targetObj.tag.Equals("Enemy")))
                {
                    Debug.Log("Attack");
                    timeAttack = Time.time;
                    if (IsAttackFirst(timeAttack, targetObj.GetComponent<CharacterAttack>().GetTimeAttack()) && targetObj.GetComponent<ObjectProperties>().IsAlive())
                    {
                        Debug.Log(this.gameObject.name + " attack:  " + targetObj.name);
                        targetObj.GetComponent<ObjectProperties>().Dead();
                    }
                }
            }   
        }

        bool IsAttackFirst(float timeObjA,float timeObjB)
        {
            if(timeObjA > timeObjB)
            {
                return true;
            }
            return false;
        }


        public int GetNumberTurn_Booster_Shockwave()
        {
            return this.numberTurnUseBooster;
        }

        public void ReduceBooster_Shockwave()
        {
            this.numberTurnUseBooster--;
        }

        public void SetNumberTurn_Booster_Shockwave(int numberTurn)
        {
            this.numberTurnUseBooster = numberTurn;
        }

        public float GetTimeAttack()
        {
            return timeAttack;
        }
    }
}

