using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void GoToScene(string sceneName) {
        SceneManager.LoadScene(1);
    }

    public void QuitApp() {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
