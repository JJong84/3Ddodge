using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public void RetryButton()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }

    public void RankButton()
    {

    }

    public void MenuButton()
    {

    }
}
