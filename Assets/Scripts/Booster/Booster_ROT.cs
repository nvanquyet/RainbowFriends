using Assets.Scripts.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Booster
{
    public class Booster_ROT : BoosterBase
    {
        [SerializeField] private List<GameObject> listCharacter = new List<GameObject>();

        private void Update()
        {
            UpdateList();
        }
        void UpdateList()
        {
            listCharacter.Clear();
            foreach (Transform child in GameObject.Find("BOTS").transform)
            {
                if (child.gameObject.activeSelf)
                {
                     listCharacter.Add(child.gameObject);
                }
            }
            if (GameObject.Find("Player"))
            {
                 listCharacter.Add(GameObject.Find("Player"));
            }
            listCharacter.Remove(this.gameObject);
        }

        void Booster_ROT_Effect(float time)
        {
            if (!useBooster && turnUseBooster > 0)
            {
                useBooster = true;
                ReduceBooster();
                foreach (GameObject obj in listCharacter)
                {
                    obj.GetComponent<CharacterMovement>().NoMove(timeUseBooster);
                }
                StartCoroutine(Booster_ROT_Done(timeUseBooster));
            }
        }

        IEnumerator Booster_ROT_Done(float time)
        {
            yield return new WaitForSeconds(time);
            useBooster = false;
        }

        public override void ActiveBooster()
        {
            Booster_ROT_Effect(timeUseBooster);
        }
    }
}
