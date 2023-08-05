using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameRandomLoad : MonoBehaviour
{
    //Professor Drew How would I go about integrated this with the current Scene Loader that Charlie has I Didn't want to mess up his work so I kept this as a seperate script

    
    //Max amount of time before a minigame should appear for now it is set to 60-300 randomly but it's only temp until a reasonable range is decided
    public int timer = Random.Range(60,300);
    //The time counter of how much has passed
    public int time = 0;
    //Random selects the scene that will spawn
    private int sceneSelect = Random.Range(0,1);

    private string selectedScene = "MinigameScene";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If time is greater than or equal to timer it will than check to see what sceneselect would be if it's one of those conditions it will load said scene. 
        //This can be customized to increased variability and if you want i can make the probability of a certain minigame to decrease each time it is called upon
        //so to further reduce the risk of gameplay becoming too repetitive
        if(time >= timer)
        {
            sceneSelect += 1;
            selectedScene = sceneSelect.ToString() + selectedScene;
            SceneManager.LoadScene(selectedScene);
            time = 0;
            timer = Random.Range(60, 300);
            sceneSelect = Random.Range(0,4);
        }
        time += 1;
    }
}
