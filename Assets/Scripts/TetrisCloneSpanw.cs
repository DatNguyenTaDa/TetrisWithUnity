using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisCloneSpanw : MonoBehaviour
{
    public static TetrisCloneSpanw instance;
    public GameObject[] tetrisCLone;
    private GameObject temp;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Debug.Log(TetrisSpawn.instance.GetRandom());
        NewTetrisClone(TetrisSpawn.instance.GetRandom());
    }

    // Update is called once per frame


    public void NewTetrisClone(int i)
    {
       GameObject tetrisclone = Instantiate(tetrisCLone[i], new Vector2(transform.position.x + tetrisCLone[i].transform.position.x, transform.position.y + tetrisCLone[i].transform.position.y), Quaternion.identity);
       tetrisclone.transform.SetParent(transform);
       temp = tetrisclone;
    }
    public void DestroyClone()
    {
        Destroy(temp);
    }
}
