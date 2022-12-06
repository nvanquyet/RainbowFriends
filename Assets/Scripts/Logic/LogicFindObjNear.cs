using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class LogicFindObjNear : MonoBehaviour
    {
        public GameObject ObjNearest(List<GameObject> listObj)
        {
            if (listObj.Count > 0)
            {
                if (listObj.Count == 1)
                {
                    return listObj[0];
                }
                else
                {
                    float distance = distanceMin(listObj);
                    List<GameObject> listObjectNear = new List<GameObject>();
                    foreach (GameObject child in listObj)
                    {
                        float distacneObj = (child.transform.position - child.transform.position).magnitude;
                        if (distacneObj == distance)
                        {
                            listObjectNear.Add(child);
                        }
                    }
                    if (listObjectNear.Count > 0)
                    {
                        Debug.Log(listObjectNear[Random.Range(0, listObjectNear.Count - 1)].name);
                        return listObjectNear[Random.Range(0, listObjectNear.Count - 1)];
                    }
                }
            }
            return null;
        }


        float distanceMin(List<GameObject> listObj)
        {
            float distance = 0;
            foreach (GameObject child in listObj)
            {
                float distacneObj = (child.transform.position - child.transform.position).magnitude;
                distance = Mathf.Min(distance, distacneObj);
            }
            Debug.Log(distance);
            return distance;
        }
    }
}