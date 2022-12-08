using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class LogicFindObjNear : MonoBehaviour
    {
        public GameObject ObjNearest(List<GameObject> listObj)
        {
            GameObject objNear = null;
            if (listObj.Count > 0)
            {
                float distance = Mathf.Infinity;
                foreach (GameObject child in listObj)
                { 
                    if ((child.transform.position - this.transform.position).magnitude < distance)
                    {
                        distance = (child.transform.position - this.transform.position).magnitude;
                        objNear = child;
                    }
                }
            }
            return objNear;
        }
    }
}