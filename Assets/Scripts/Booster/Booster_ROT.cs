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
            listCharacter.Add(GameObject.Find("Player"));
            foreach (Transform child in GameObject.Find("BOTS").transform)
            {
                if (child.gameObject.activeSelf)
                {
                    if (!listCharacter.Contains(child.gameObject))
                    {
                        listCharacter.Add(child.gameObject);
                    }
                }
            }
            listCharacter.Remove(this.gameObject);
        }

        void Booster_ROT_Effect(float time)
        {
            if (!useBooster)
            {
                useBooster = true;
                foreach (GameObject obj in listCharacter)
                {
                    obj.GetComponent<CharacterMovement>().canMove = false;
                    Debug.Log("ROT Start");
                }
                StartCoroutine(Booster_ROT_DONE(time));
            }
        }

        IEnumerator Booster_ROT_DONE(float time)
        {
            yield return new WaitForSeconds(time);
            foreach (GameObject obj in listCharacter)
            {
                useBooster = false;
                obj.GetComponent<CharacterMovement>().canMove = true;
                Debug.Log("ROT complete");
            }
        }

        public override void ActiveBooster()
        {
            Booster_ROT_Effect(timeUseBooster);
        }
    }
}
