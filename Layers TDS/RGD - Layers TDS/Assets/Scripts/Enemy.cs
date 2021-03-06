using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed=5f;
    public GameObject Player;
    public GameObject Dummy;
    public GameObject Target;
    public GameObject bulletPrefab;
    public float bulletsPerSecond=1;
    private float bulletTimer;
    public float bulletForce = 20f;
    public Transform firePoint;
    public bool isNormalPlane = true;
    public float searchRadius;
    public float shootRadius;
    public float stopRadius;
    private float distance;
    private CharacterController enemyCC;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, shootRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }
    private void Awake()
    {
        Target = Player;
        bulletTimer = 1 / bulletsPerSecond;
        enemyCC = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (ControllerMovement.Instance.normalPlane == false && isNormalPlane==true)
        {
            Target = Dummy;
        }
        else
        {
            Target = Player;
        }
        if(GameController.Instance.gameStart ==true)
        {
            if (ControllerMovement.Instance.normalPlane == isNormalPlane||Target==Dummy)
            {
                distance = Mathf.Abs(Vector3.Distance(Target.transform.position, this.transform.position));
                if (distance <= searchRadius)
                {
                    float angle = Mathf.Atan2(Target.transform.position.y - this.transform.position.y, Target.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg - 90f;
                    transform.rotation = Quaternion.Euler(0, 0, angle);
                }

            }
        }       
        
    }
    private void FixedUpdate()
    {
        if (GameController.Instance.gameStart==true)
        {
            bulletTimer = Mathf.Clamp(bulletTimer - Time.deltaTime, 0, 1 / bulletsPerSecond);
            if (bulletTimer <= 0 && (ControllerMovement.Instance.normalPlane||Target==Dummy) == isNormalPlane && distance <= shootRadius)
            {
                Shoot();
            }
            Vector3 dir = Vector3.Normalize(Target.transform.position - transform.position);
            if (distance >= stopRadius && distance <= searchRadius && (ControllerMovement.Instance.normalPlane == isNormalPlane||Target==Dummy))
            {
                enemyCC.Move(dir * moveSpeed * Time.deltaTime);
            }
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
