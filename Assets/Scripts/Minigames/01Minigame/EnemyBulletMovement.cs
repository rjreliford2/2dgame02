using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    public Transform bullet;
    public float speed;

    void Update()
    {
        bullet.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
        if(bullet.position.y < -5f)
            Destroy(this.gameObject);
    }
}
