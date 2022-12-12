using Assets.Scripts.Booster;
using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.BOT
 {
    public class BOTBooster : CharacterBooster
    {
        [SerializeField] private BoosterBase booster;
        [SerializeField] private BOTTarget targetAI;

        private void Awake()
        {
            targetAI = GetComponent<BOTTarget>();
            booster = GetComponent<BoosterBase>();
        }

        private void Start()
        {
            SetProperties();
        }

        public override void SetProperties()
        {
            booster.SetNumberTurn_Booster(1);
            booster.SetTimeUseBooster(5f);
        }

        private void Update()
        {
            GameObject target = targetAI.target;
            if(target)
            {
                if((target.transform.position - transform.position).magnitude < 5 * 10)
                {
                    ActiveBooster();
                }
            }
        }


        public override void ActiveBooster()
        {
            booster.ActiveBooster();
        }
    }
}

