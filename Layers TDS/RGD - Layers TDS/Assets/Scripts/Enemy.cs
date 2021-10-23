using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public GameObject Player;
    public GameObject bulletPrefab;
    public float bulletsPerSecond=1;
    private float bulletTimer;
    public float bulletForce = 20f;
    public Transform firePoint;
    public bool isNormalPlane = true;

    private void Awake()
    {
        bulletTimer = 1 / bulletsPerSecond;
    }
    private void Update()
    {
        if (ControllerMovement.Instance.normalPlane ==true)
        {
            float angle = Mathf.Atan2(Player.transform.position.y - this.transform.position.y, Player.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
    }
    private void FixedUpdate()
    {
        bulletTimer = Mathf.Clamp(bulletTimer-Time.deltaTime,0, 1 / bulletsPerSecond);
        if (bulletTimer<=0&&ControllerMovement.Instance.normalPlane==isNormalPlane)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);        
        AkSoundEngine.PostEvent("disparo", gameObject);
        bulletTimer = 1 / bulletsPerSecond;
    }
}
