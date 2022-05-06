using UnityEngine;
using UnityEngine.UI;

public class leaderboard_lang : MonoBehaviour
{
    [SerializeField] Text close;
    [SerializeField] Text leaderboard;
    private void Start()
    {
        close.text = language_staticl.Close;
        leaderboard.text = language_staticl.leaderboard;
    }
}
