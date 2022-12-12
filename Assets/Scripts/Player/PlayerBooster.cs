using Assets.Scripts.Booster;
using Assets.Scripts.Character;
using Assets.Scripts.InputCharacter;
using Assets.Scripts.StateControl;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerBooster : CharacterBooster
    {
        [SerializeField] protected InputCtrl input;
        [SerializeField] protected List<BoosterBase> listBooster;

        private void Awake()
        {
            state = GetComponentInParent<CharacterState>();
            input = transform.parent.GetComponentInChildren<InputCtrl>();
            foreach(Transform child in transform)
            {
                if (child)
                {
                    listBooster.Add(child.GetComponent<BoosterBase>());
                }
            }
        }
        private void Start()
        {
            SetProperties();
        }
        public override void SetProperties()
        {
            if(state != null)
            {
                state.stateBooster = StateBooster.NoBooster;
            }
            //Degree and Distance check
            foreach (BoosterBase booster in listBooster)
            {
                booster.SetNumberTurn_Booster(5);
                booster.SetTimeUseBooster(5);
            }
        }
        private void Update()
        {
            //Test
            if (input.useBoosterFastTrack)
            {
                ActiveBooster(0);
                state.stateBooster = StateBooster.FastTrack;
                return;
            }
            if (input.useBoosterRot)
            {
                ActiveBooster(1);
                state.stateBooster = StateBooster.Rot;
                return;
            }
            if (input.useBoosterSheildUp)
            {
                ActiveBooster(2);
                state.stateBooster = StateBooster.SheildUp;
                return;
            }
            if (input.useBoosterShockwave)
            {
                ActiveBooster(3);
                state.stateBooster = StateBooster.Shockwave;
                return;
            }
            state.stateBooster = StateBooster.NoBooster;
        }

        public void ActiveBooster(string booster)
        {
            switch (booster)
            {
                case "FastTrack":
                    {
                        ActiveBooster(0);
                        break;
                    }
                case "Rot":
                    {
                        ActiveBooster(1);
                        break;
                    }
                case "ShieldUp":
                    {
                        ActiveBooster(2);
                        break;
                    }
                case "Shockwave":
                    {
                        ActiveBooster(3);
                        break;
                    }
            }
        }


        void ActiveBooster(int booster)
        {
            /*
             0 -> FastTrack
             1 -> Rot
             2 -> ShieldUp
             3 -> Shockwave
             */
            if(booster <= listBooster.Count)
            {
                listBooster[(int)booster].ActiveBooster();
            }
        }

        public override void ActiveBooster()
        {
            //Nothing
        }
    }
}

