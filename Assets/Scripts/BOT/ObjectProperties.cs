using UnityEngine;
namespace Assets.Scripts.Character
{
    public class ObjectProperties : MonoBehaviour
    {

        [SerializeField] protected Vector3 modelScale;

        private void Start()
        {
            //SetModelScale(modelScale);
        }

        public void SetModelScale(Vector3 modelScales)
        {
            Transform graphics = transform.Find("Model");
            if(graphics != null)
            {
                graphics.localScale = modelScales;
            }
        }

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

