using UnityEngine;

namespace Assets.Scripts.Character
{
    public abstract class CharacterBooster : MonoBehaviour
    {
        [SerializeField] protected CharacterState state;

        public abstract void SetProperties();
        public abstract void ActiveBooster();
    }
}
