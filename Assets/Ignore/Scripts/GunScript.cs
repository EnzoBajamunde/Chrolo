using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    [Header("Settings")]
    public int totalBullets = 10;
    public float fireCooldown = 0.5f;


    private bool canShoot = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canShoot && totalBullets > 0)
        {
            Shoot();
        }
        if (totalBullets >= 1)
        {
            canShoot = true;
        }
    }

    private void Shoot()
    {
        canShoot = false;

        // Create a new bullet at the bulletSpawnPoint position and rotation
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            // Add force to the bullet in the forward direction of the bulletSpawnPoint
            bulletRigidbody.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.Impulse);
        }

        totalBullets--;

        if (totalBullets <= 0)
        {
            canShoot = false;
        }
        else
        {
            Invoke(nameof(ResetShoot), fireCooldown);
        }
    }
    private void ResetShoot()
    {
        canShoot = true;
    }

    public void RefillAmmo(int amount)
    {
        totalBullets += amount;
        totalBullets = Mathf.Clamp(totalBullets, 0, int.MaxValue);

    }
}