using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsswitcher : MonoBehaviour
{ 
    // The name of the original scene (credits screen)
    public string originalSceneName = "CreditsScene";

    // The name of the target scene to load
    public string targetSceneName = "MainMenuScene";

    // Function to load the target scene
    public void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }

    // Function to go back to the original scene
    public void GoBackToOriginalScene()
    {
        SceneManager.LoadScene(originalSceneName);
    }
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
