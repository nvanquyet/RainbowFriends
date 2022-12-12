using UnityEngine;
namespace Assets.Scripts.Character
{
    public interface IProperties
    {
        bool IsAlive();
        void Dead();
    }
    public class CharacterProperties : MonoBehaviour, IProperties
    {
        public bool isSheildUp = false;
        public bool IsAlive()
        {
            if (this.gameObject.activeSelf)
            {
                return true;
            }
            return false;
        }

        public void Dead()
        {
            this.gameObject.SetActive(false);
        }
    }
}

