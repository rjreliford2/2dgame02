using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tubemovement : MonoBehaviour
{
    public float horizontalSpeed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * horizontalSpeed;
        h *= Time.deltaTime;
        transform.Translate(h,0,0);
    }
}
