using UnityEngine;

namespace Assets.Scripts.Character
{
    public class CharacterModel : MonoBehaviour
    {
        public void KillingSpree(float percent)
        {
            transform.localScale += transform.localScale * percent / 100;
            Debug.Log(transform.localScale);
        }
    }
}
