using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); // Replace "Level1" with your first level's scene name
    }

    public void ExitGame()
    {
        Debug.Log("Game Exited!");
        Application.Quit(); // Quits the application (works in a build, not in the editor)
    }
}
