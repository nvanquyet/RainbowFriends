using Assets.Scripts.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Booster
{
    public class Booster_SheildUp : BoosterBase
    {

        public override void ActiveBooster()
        {
            BoosterSheildUp();
        }

        void BoosterSheildUp()
        {
            if (!useBooster && turnUseBooster > 0)
            {
                useBooster = true;
                GetComponent<CharacterProperties>().isSheildUp = true;
                ReduceBooster();
            }
            StartCoroutine(Booster_Complete(timeUseBooster));
        }
        IEnumerator Booster_Complete(float time)
        {
            yield return new WaitForSeconds(time);
            useBooster = false;
            GetComponent<CharacterProperties>().isSheildUp = false;
            Debug.Log("Booster Complete");
        }

    }
}
