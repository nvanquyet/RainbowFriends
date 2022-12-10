using Assets.Scripts.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Booster
{
    public class Booster_FastTrack : BoosterBase
    {

        public override void ActiveBooster()
        {
            BoosterFastTrack();
        }

        void BoosterFastTrack()
        {
            if (!useBooster && turnUseBooster > 0)
            {
                useBooster = true;
                ReduceBooster();
                GetComponent<CharacterMovement>().speed *= 2;
            }
            StartCoroutine(Booster_Complete(timeUseBooster));
        }
        IEnumerator Booster_Complete(float time)
        {
            yield return new WaitForSeconds(time);
            useBooster = false;
            GetComponent<CharacterMovement>().speed /= 2;
            Debug.Log("Booster Complete");
        }

    }
}
