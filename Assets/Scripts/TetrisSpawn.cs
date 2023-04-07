using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TetrisSpawn : MonoBehaviour
{
    public static TetrisSpawn instance;
    public GameObject[] tetrisPiece;
    public static int myRandom;

    private int score;
    private int highScore;

    // Start is called before the first frame update
    private void Awake()
    {
        instance= this;
        myRandom = Random.Range(0, tetrisPiece.Length);
        highScore = PlayerPrefs.GetInt("TetrisHighScore", 0);
    }
    void Start()
    {
        Instantiate(tetrisPiece[Random.Range(0, tetrisPiece.Length)], transform.position, Quaternion.identity);
    }
    private void Update()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Score").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("Score")[i].GetComponent<TMP_Text>().text = "Score: " + score.ToString();
            GameObject.FindGameObjectsWithTag("HighScore")[i].GetComponent<TMP_Text>().text = "High Score: " + highScore.ToString();
        }
        
    }

    // Update is called once per frame
    public void NewTetris(int i)
    {
        Instantiate(tetrisPiece[i], new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
    }
    public int GetRandom()
    {
        return myRandom;
    }
    public void SetRandom()
    {
        myRandom= Random.Range(0, tetrisPiece.Length);
    }
    public int GetScore()
    {
        return score;
    }
    public void SetScore()
    {
        if (score > 200)
        {
            score += 20;
        }
        else
            score += 10;
        if(score>highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("TetrisHighScore", score);
        }
    }
}
