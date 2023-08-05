using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceshipShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public float fireRate;
    private float nextFire;
    public AudioSource shoot;

    void Update()
    {
        if(Input.GetKey("space") && Time.time > nextFire)
        {
            shoot.Play();
            nextFire = Time.time + fireRate;
            GameObject bulletInstance = Instantiate<GameObject>(bullet, bulletTransform.position + (-Vector3.down) + (Vector3.down/-2), bulletTransform.rotation);
        }
    }
}
