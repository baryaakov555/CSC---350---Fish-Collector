using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadCollector()
    {
        SceneManager.LoadScene("FishCollector");
    }

    public void LoadSideScroller()
    {
        SceneManager.LoadScene("SideScroller");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
