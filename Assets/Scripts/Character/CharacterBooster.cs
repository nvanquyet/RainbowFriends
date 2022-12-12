using UnityEngine;

namespace Assets.Scripts.Character
{
    public abstract class CharacterBooster : MonoBehaviour
    {
        public abstract void SetProperties();
        public abstract void ActiveBooster();
    }
}
