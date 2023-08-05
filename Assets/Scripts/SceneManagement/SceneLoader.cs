using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //singleton reference to the sceneloader in Main Scene DO NOT MAKE ANY OTHER SCENE LOADERS
    public static SceneLoader loaderActual;

    //build index of the current scene. all scene loading methods should make sure to update this appropriately
    private int currentSceneIndex;

    //Load base scene on start
    void Awake()
    {
        SceneLoader.loaderActual = this;
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        currentSceneIndex = 2;
    }

    //returns from whatever the current scene is to the base scene
    //be careful to save any data you need to playerprefs or a persistent object whenever
    //an important action occurs, as the back button will call this and you may lose data
    public void returnToBase()
    {
        SceneManager.UnloadSceneAsync(currentSceneIndex);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        currentSceneIndex = 2;
    }

    //loads the menu for placing a building in an EMPTY slot
    public void loadBuildMenu()
    {
        SceneManager.UnloadSceneAsync(currentSceneIndex);
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
        currentSceneIndex = 3;
    }

    //Loads the upgrade menu for a building
    public void loadUpgradeMenu()
    {
        SceneManager.UnloadSceneAsync(currentSceneIndex);
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
        currentSceneIndex = 4;
    }

    //loads the research screen
    public void toResearch()
    {
        SceneManager.UnloadSceneAsync(currentSceneIndex);
        SceneManager.LoadScene(5, LoadSceneMode.Additive);
        currentSceneIndex = 5;
    }

    //generic scene change method to load a scene by build index
    public void changeScene(int buildIndex)
    {
        SceneManager.UnloadSceneAsync(currentSceneIndex);
        SceneManager.LoadScene(buildIndex, LoadSceneMode.Additive);
        currentSceneIndex = buildIndex;
    }
}
