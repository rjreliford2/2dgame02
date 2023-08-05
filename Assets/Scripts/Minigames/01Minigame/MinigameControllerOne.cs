using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MinigameControllerOne : MonoBehaviour
{
    public float timeLeft;
    public bool timerOn = false;
    public TextMeshProUGUI timerText;
    public float counter = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Time is up.");
                timeLeft = 0;
                timerOn = false;
            }
        }

        if(!timerOn)
        {
            timerText.text = "Good try!";
            while (counter < 5)
            {
                counter += Time.deltaTime;
            }
            SceneManager.LoadScene(1);
        }
    }

    private void updateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = "" + seconds;
    }
}
