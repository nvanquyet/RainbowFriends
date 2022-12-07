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
            attackRange.SetProperties(45 , 25/2);
        }

        private void Start()
        {
            distacneUseBooster = 10f;
            timeUseBooster = 2f;
        }
        private void Update()
        {
            attackRange.SetOrigin(transform.position + Vector3.up + transform.forward / 3);
            attackRange.SetForward(transform.forward);
            if (!target)
            {
                target = targetAI.FindPlayer();
            }
            else
            {
                if (!useBooster)
                {
                    Debug.Log("Use Booster");
                }
                Booster_Shockwave(distacneUseBooster);
                Attack();
            }
        }


    }
}

