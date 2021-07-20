using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Toggle pauseBtn;
    public GameObject popUpPanel;
    public Slider bgmSlider;
    public AudioSource bgm;
    void Start()
    {
        bgmSlider.value = 0.2f;
    }

    void Update()
    {
        bgm.volume = bgmSlider.value;
    }
    public void PopUpPanelOnOff()
    {
        if (pauseBtn.isOn == false)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        popUpPanel.SetActive(pauseBtn.isOn);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameLobby()
    {
        SceneManager.LoadScene(0);
    }
}
