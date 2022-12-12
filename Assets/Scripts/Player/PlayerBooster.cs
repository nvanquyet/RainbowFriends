using Assets.Scripts.Booster;
using Assets.Scripts.Character;
using Assets.Scripts.InputCharacter;
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
            //Degree and Distance check
            foreach(BoosterBase booster in listBooster)
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
            }
            if (input.useBoosterRot)
            {
                ActiveBooster(1);
            }
            if (input.useBoosterSheildUp)
            {
                ActiveBooster(2);
            }
            if (input.useBoosterShockwave)
            {
                ActiveBooster(3);
            }

        }

        public void ActiveBooster(string booster)
        {
            switch (booster)
            {
                case "FastTrack":
                    {
                        listBooster[0].ActiveBooster();
                        break;
                    }
                case "Rot":
                    {
                        listBooster[1].ActiveBooster();
                        break;
                    }
                case "ShieldUp":
                    {
                        listBooster[2].ActiveBooster();
                        break;
                    }
                case "Shockwave":
                    {
                        listBooster[3].ActiveBooster();
                        break;
                    }
            }
        }


        public void ActiveBooster(int booster)
        {
            /*
             0 -> FastTrack
             1 -> Rot
             2 -> ShieldUp
             3 -> Shockwave
             */
           listBooster[(int)booster].ActiveBooster();
        }

        public override void ActiveBooster()
        {
            //Nothing
        }
    }
}

