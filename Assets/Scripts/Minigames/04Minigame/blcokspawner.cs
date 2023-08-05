using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blcokspawner : MonoBehaviour
{
    public GameObject[] atomPrefab;
    private float timer= 0.0f;
    private float waitTime = 2.0f;
    void start()
    {
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > waitTime)
        {
            Vector3 spawnlocation = new Vector3(Random.Range(-8, 8), 10,0);
            GameObject atm = Instantiate(atomPrefab[Random.Range(0, atomPrefab.Length)], this.transform) as GameObject;
            Instantiate(atm, spawnlocation, Quaternion.identity);
            timer = timer - waitTime;
        }
    }
   
}
