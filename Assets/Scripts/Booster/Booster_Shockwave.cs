using Assets.Scripts.Character;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Booster
{
    public class Booster_Shockwave : BoosterBase
    {
        [SerializeField] private float distacne;

        public override void ActiveBooster()
        {
            BoosterShockwave(distacne);
        }

        void BoosterShockwave(float distacne)
        {
            if (!useBooster && turnUseBooster > 0)
            {
                useBooster = true;
                ReduceBooster();
                foreach (GameObject child in GetComponent<AttackRange>().ObjectInRange(distacne))
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

    }
}
