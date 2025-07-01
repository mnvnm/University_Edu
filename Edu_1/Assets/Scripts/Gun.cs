using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;

    int magazineSize = 12;
    int currentAmmo;

    bool isReloading = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAmmo = magazineSize;
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    void Shooting()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && !isReloading)
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(bulletSpawnPoint.forward * 3000f);

        currentAmmo--;
        if (currentAmmo <= 0)
        {
            Reload();
        }
    }

    void Reload()
    {
        if (currentAmmo == magazineSize || isReloading) return;
        isReloading = true;
        StartCoroutine(ReloadCoroutine(2.0f)); // 2 seconds reload time
    }

    IEnumerator ReloadCoroutine(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magazineSize;
        
        isReloading = false;
    }
}
