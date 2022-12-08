using Assets.Scripts.Interface;
using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Character
{
    public class ObjectProperties : MonoBehaviour
    {
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

