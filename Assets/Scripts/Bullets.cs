using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private float timeBetweenShots = 0.4f;
    private float bulletSpeed = 50f;
    private float nextShotTime=0f;
    private void Update()
    {
        if (Time.time > nextShotTime)
        {
                        Shoot();
            nextShotTime = Time.time + timeBetweenShots;
        }
    }
    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * bulletSpeed;
        Destroy(newBullet, 5f);
    }
}
