using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame() => SceneManager.LoadScene("SinglePlayerGame");
    public void QuitGame() => Application.Quit();
}
