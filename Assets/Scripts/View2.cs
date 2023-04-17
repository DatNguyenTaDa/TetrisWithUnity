using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class View2 : MonoBehaviour
{
    //public static View Instance;
    //[SerializeField] private Canvas startScene;
    //[SerializeField] private Canvas lostScene;
    //[SerializeField] private RectTransform cd;
    //[SerializeField] private RectTransform gameOver;

    //[SerializeField] private Button turnOffEffect;
    //[SerializeField] private Button turnOnEffect;
    //[SerializeField] private Button turnOffTheme;
    //[SerializeField] private Button turnOnTheme;

    //private bool isPause = true;


    //// Start is called before the first frame update
    //private void Awake()
    //{
    //    Instance= this;
    //    gameOver.gameObject.SetActive(false);

    //}
    //void Start()
    //{
    //    if (Controller.startType == 1)
    //    {
    //        startScene.gameObject.SetActive(false);
    //        cd.gameObject.SetActive(true);
    //    }
    //}

    //public bool GetPause() { return isPause; }
    //public int GetEffect()
    //{
    //    return PlayerPrefs.GetInt("isEffect");
    //}
    //public int GetTheme()
    //{
    //    return PlayerPrefs.GetInt("isTheme");
    //}
    //private void Update()
    //{
    //    if (PlayerPrefs.GetInt("isTheme") == 0)
    //    {
    //        GameObject.FindGameObjectWithTag("Theme").GetComponent<AudioSource>().mute = true;

    //        turnOffTheme.gameObject.SetActive(false);
    //        turnOnTheme.gameObject.SetActive(true);
    //    }
    //    if (PlayerPrefs.GetInt("isTheme") == 1)
    //    {
    //        GameObject.FindGameObjectWithTag("Theme").GetComponent<AudioSource>().mute = false;

    //        turnOffTheme.gameObject.SetActive(true);
    //        turnOnTheme.gameObject.SetActive(false);
    //    }
    //    if (PlayerPrefs.GetInt("isEffect") == 0)
    //    {
    //        turnOffEffect.gameObject.SetActive(false);
    //        turnOnEffect.gameObject.SetActive(true);
    //    }
    //    if (PlayerPrefs.GetInt("isEffect") == 1)
    //    {
    //        turnOffEffect.gameObject.SetActive(true);
    //        turnOnEffect.gameObject.SetActive(false);
    //    }
    //    CheckPieceNull();
    //}
    //public void Pause()
    //{
    //    isPause = true;
    //}
    //public void Remuse()
    //{
    //    isPause = false;
    //}
    //public void EffectOff()
    //{
    //    PlayerPrefs.SetInt("isEffect", 0);
    //}
    //public void EffectOn()
    //{
    //    PlayerPrefs.SetInt("isEffect", 1);
    //}
    //public void ThemeOff()
    //{
    //    PlayerPrefs.SetInt("isTheme", 0);

    //}
    //public void ThemeOn()
    //{
    //    PlayerPrefs.SetInt("isTheme", 1);
    //}
    //public void Play()
    //{
    //    isPause = false;
    //}
    //public void RePlay()
    //{
    //    SceneManager.LoadScene(0);
    //    Controller.startType = 1;
    //}
    //public void ReturnHome()
    //{
    //    SceneManager.LoadScene(0);
    //    Controller.startType = 0;
    //}
    //public void GameOver()
    //{
    //    gameOver.gameObject.SetActive(true);
    //}

    //public void CheckPieceNull()
    //{
    //    foreach (GameObject piece in GameObject.FindGameObjectsWithTag("TetrisPiece"))
    //    {
    //        if (piece.transform.childCount == 0)
    //        {
    //            Destroy(piece.gameObject);
    //        }
    //    }
    //}
}
