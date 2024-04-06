using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public List<GameObject> requiredObjects;

    public GameObject barrier;

   
    private bool CheckRequiredObjectsDestroyed()
    {
        foreach (GameObject obj in requiredObjects)
        {
            if (obj != null)
            {
               
                return false;
            }
        }
      
        return true;
    }

    void Update()
    {
        
        if (CheckRequiredObjectsDestroyed())
        {
            barrier.SetActive(false);
        }
        else
        {
            
            barrier.SetActive(true);
        }
    }
}
