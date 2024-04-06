using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRefillStation : MonoBehaviour
{
    public int ammoRefillAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GunScript gunScript = other.GetComponentInChildren<GunScript>();
            if (gunScript != null)
            {
                gunScript.RefillAmmo(ammoRefillAmount);
            }
        }
    }
}
