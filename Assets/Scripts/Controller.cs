using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Controller : MonoBehaviour
{
    [SerializeField] private Canvas startScene;
    [SerializeField] private Canvas lostScene;
    [SerializeField] private RectTransform cd;
    [SerializeField] private RectTransform gameOver;
    public static Controller instance;
    private bool isPause = true;
    //private bool isEffect = true;
    //private bool isTheme = true;
    public static int startType;

    private void Awake()
    {
        instance = this;
        gameOver.gameObject.SetActive(false);
        //PlayerPrefs.SetInt("isEffect", 1);
        //PlayerPrefs.SetInt("isTheme", 1);
    }
    private void Start()
    {
        if(startType == 1)
        {
            startScene.gameObject.SetActive(false);
            cd.gameObject.SetActive(true);
        }
    }
    public bool GetPause() { return isPause; }
    public int GetEffect() {
        return PlayerPrefs.GetInt("isEffect");
    }
    public int GetTheme() {
        return PlayerPrefs.GetInt("isTheme");
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("isTheme") == 0)
        {
            GameObject.FindGameObjectWithTag("Theme").GetComponent<AudioSource>().mute = true;

            GameObject.FindGameObjectWithTag("ThemeOff")?.SetActive(false);
            GameObject.FindGameObjectWithTag("ThemeOn")?.SetActive(true);
        }
        if(PlayerPrefs.GetInt("isTheme") == 1)
        {
            GameObject.FindGameObjectWithTag("Theme").GetComponent<AudioSource>().mute = false;

            GameObject.FindGameObjectWithTag("ThemeOff")?.SetActive(true);
            GameObject.FindGameObjectWithTag("ThemeOn")?.SetActive(false);
        }
        if(PlayerPrefs.GetInt("isEffect") == 0)
        {
            GameObject.FindGameObjectWithTag("EffectOff")?.SetActive(false);
            GameObject.FindGameObjectWithTag("EffectOn")?.SetActive(true);
        }
        if(PlayerPrefs.GetInt("isEffect") == 1)
        {
            GameObject.FindGameObjectWithTag("EffectOff")?.SetActive(true);
            GameObject.FindGameObjectWithTag("EffectOn")?.SetActive(false);
        }
    }
    public void Pause()
    {
        isPause = true;
    }
    public void Remuse()
    {
        isPause= false;
    }
    public void EffectOff()
    {
        PlayerPrefs.SetInt("isEffect", 0);
    }
    public void EffectOn()
    {
        PlayerPrefs.SetInt("isEffect", 1);
    }
    public void ThemeOff()
    {
        PlayerPrefs.SetInt("isTheme", 0);

    }
    public void ThemeOn()
    {
        PlayerPrefs.SetInt("isTheme", 1);
    }
    public void Play()
    {
        isPause = false;
    }
    public void RePlay()
    {
        SceneManager.LoadScene(0);
        startType = 1;
    }
    public void ReturnHome()
    {
        SceneManager.LoadScene(0);
        startType = 0;
    }
    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
    }
}
