using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(speed * Input.GetAxis("Horizontal")*Time.deltaTime, speed *Time.deltaTime * Input.GetAxis("Vertical"), 0.0f);
    }
}
