using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.BOT
 {
    public class BOTAttack : CharacterAttack
    {
        private BOTTarget targetTool;
        [SerializeField] private BOTTarget targetAI;
        [SerializeField] private float mutilNumber;
        [SerializeField] private GameObject target;
         
        private void Awake()
        {
            attackRange = GetComponent<AttackRange>();
            targetAI = GetComponent<BOTTarget>();
            attackRange.SetProperties(45/2 , 10/2);
        }

        private void Start()
        {
            
        }

        protected override void SetProperties()
        {
            timeAttack = 0;
            useBooster = false;
            this.SetNumberTurn_Booster_Shockwave(1);
            distacneUseBooster = 10f;
            timeUseBooster = 2f;
        }

        private void Update()
        {
            ReadyAttack();
            attackRange.SetOrigin(transform.position + Vector3.up + transform.forward / 3);
            attackRange.SetForward(transform.forward);
            target = targetAI.FindPlayer();
            if(target)
            {
                if (!useBooster)
                {
                    Debug.Log("Use Booster");
                }
                //Booster_Shockwave(distacneUseBooster);
                 Attack();
                
            }
        }


    }
}

