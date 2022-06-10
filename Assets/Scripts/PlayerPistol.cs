using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPistol : MonoBehaviour
{
    public GameObject camera;

    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    float bulletSpeed = 60;

    float lifeTime = 3;

    float cooldownTimer = 0;

    void Update()
    {
        if (cooldownTimer > .4f) {
            if (Input.GetMouseButtonDown(0)) {
                Fire();
                cooldownTimer = 0;
            }
        }
        else {
            cooldownTimer += Time.deltaTime;
        }  
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab);

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
            bulletSpawn.parent.GetComponent<Collider>());

        bullet.transform.position = bulletSpawn.position;

        Vector3 rotation = bullet.transform.rotation.eulerAngles;

        bullet.transform.rotation = Quaternion.Euler(camera.transform.rotation.eulerAngles.x + 90, camera.transform.rotation.eulerAngles.y, camera.transform.rotation.eulerAngles.z);

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }
}
