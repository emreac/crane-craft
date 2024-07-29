using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index exceeds the number of scenes available
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Optionally, loop back to the first scene or handle the end of the game
            Debug.Log("You've reached the last level.");
            // SceneManager.LoadScene(0); // Uncomment to loop back to the first scene
        }
    }
    public void LoadFirstlevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
