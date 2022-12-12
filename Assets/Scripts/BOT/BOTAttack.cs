using Assets.Scripts.Booster;
using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.BOT
 {
    public class BOTAttack : CharacterAttack
    {
        [SerializeField] private BOTTarget targetAI;
        [SerializeField] private float mutilNumber;
         
        private void Awake()
        {
            attackRange = GetComponent<AttackRange>();
            targetAI = GetComponent<BOTTarget>();
            //Degree and Distance check
            attackRange.SetProperties(45/2 , 10/2);
        }

        private void Start()
        {
            SetProperties();
        }

        protected override void SetProperties()
        {
            attackRange.SetProperties(45/2, 10/2);
            attackDelay = 0;
            m_attackDelay = 0;
            percentIncrease = 5;
        }

        private void Update()
        {
            ReadyAttack();
            attackRange.SetOrigin(transform.position + Vector3.up + transform.forward / 3);
            attackRange.SetForward(transform.forward);
            if(targetAI.target)
            {
                 Attack();
            }
        }


    }
}

