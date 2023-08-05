using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceshipShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public float fireRate;
    private float nextFire;
    public AudioSource shoot;

    void Start()
    {
        nextFire = Random.Range(0, 3);
    }

    void Update()
    {
        if(Time.time > nextFire)
        {
            shoot.Play();
            nextFire = Time.time + fireRate + Random.Range(0, 3);
            GameObject bulletInstance = Instantiate<GameObject>(bullet, bulletTransform.position + Vector3.down, bulletTransform.rotation);
        }
    }
}
