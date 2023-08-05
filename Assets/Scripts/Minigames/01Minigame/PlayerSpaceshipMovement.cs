using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceshipMovement : MonoBehaviour
{
    public Transform spaceship;
    public float speed;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(horizontal * speed * Time.deltaTime, 0f, 0f);

        if((move.x < 0f && spaceship.position.x > -8f) || (move.x > 0f && spaceship.position.x < 8f))
            spaceship.position += move;
    }
}
