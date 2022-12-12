using Assets.Scripts.Character;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Booster
{
    public abstract class BoosterBase : MonoBehaviour
    {
        [SerializeField] protected int turnUseBooster;
        [SerializeField] protected float timeUseBooster;
        [SerializeField] protected bool useBooster = false;
        public void SetNumberTurn_Booster(int numberTurn)
        {
            this.turnUseBooster = numberTurn;
        }
        public void SetTimeUseBooster(float time)
        {
            this.timeUseBooster = time;
        }
        public int GetNumberTurn_Booster()
        {
            return turnUseBooster;
        }
        public void ReduceBooster()
        {
            if (turnUseBooster > 0)
            {
                turnUseBooster--;
            }
        }

        public abstract void ActiveBooster();
    }
}
