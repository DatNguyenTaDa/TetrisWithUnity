using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TetrisSpawn : MonoBehaviour
{
    public static TetrisSpawn instance;
    public GameObject[] tetrisPiece;
    private int myRandom;

    

    // Start is called before the first frame update
    private void Awake()
    {
        instance= this;
        myRandom = Random.Range(0, tetrisPiece.Length);
    }
    void Start()
    {
        Instantiate(tetrisPiece[Random.Range(0, tetrisPiece.Length)], transform.position, Quaternion.identity);
    }
    private void Update()
    {
        
        
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
    
    
}
