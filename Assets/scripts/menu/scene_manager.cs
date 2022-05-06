using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    public void menu() {
        SceneManager.LoadScene("menu");
    }
    public void shop()
    {
        SceneManager.LoadScene("shop");
    }
    public void main()
    {
        SceneManager.LoadScene("main");
    }

    public void dead()
    {
        SceneManager.LoadScene("dead");
    }
    public void leaderboard()
    {
        SceneManager.LoadScene("leaderboard");
    }
}
