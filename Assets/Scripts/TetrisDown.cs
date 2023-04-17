using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TetrisDown : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float priviousTime;
    [SerializeField] private float fallTime = 0.8f;
    public static float height = 9;
    public static float width = 4.5f;
    private static Transform[,] grid = new Transform[10, 22];

    public float moveSpeed = 2f; // Tốc độ di chuyển
    private float timeSinceLastMove = 0f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Illution();
        if (CheckLost())
        {
            //Time.timeScale = 0;
            View.Instance.GameOver();
            GameObject.FindGameObjectWithTag("Theme").GetComponent<AudioSource>().mute = true;
            return;
        }
        if(View.Instance.GetPause())
        {
            return;
        }
        float speed = (View.Instance.GetScore() >= 200) ? fallTime / 1.5f : fallTime;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            timeSinceLastMove += Time.deltaTime;
            if (timeSinceLastMove >= 0.1f)
            { // Di chuyển đối tượng sau 0.1 giây
                if (View.Instance.GetEffect()==1)
                    GameObject.FindGameObjectWithTag("Move").GetComponent<AudioSource>().Play();
                transform.position += new Vector3(-0.5f, 0);
                if (!ValidMove())
                    transform.position -= new Vector3(-0.5f, 0);
                timeSinceLastMove = 0f;
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            timeSinceLastMove += Time.deltaTime;
            if (timeSinceLastMove >= 0.1f)
            { // Di chuyển đối tượng sau 0.1 giây
                if (View.Instance.GetEffect()==1)
                    GameObject.FindGameObjectWithTag("Move").GetComponent<AudioSource>().Play();
                transform.position += new Vector3(0.5f, 0);
                if (!ValidMove())
                    transform.position -= new Vector3(0.5f, 0);
                timeSinceLastMove = 0f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (View.Instance.GetEffect() == 1)
                GameObject.FindGameObjectWithTag("Rotation").GetComponent<AudioSource>().Play();
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if (!ValidMove())
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);

        }
        if (Time.time - priviousTime > ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) ? speed/10:speed))
        {
            if (View.Instance.GetEffect() == 1 && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
                GameObject.FindGameObjectWithTag("Move").GetComponent<AudioSource>().Play();
            transform.position += new Vector3(0, -0.5f);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -0.5f);
                this.enabled = false;

                if(View.Instance.GetEffect() == 1)
                    GameObject.FindGameObjectWithTag("Drop").GetComponent<AudioSource>().Play();

                AddGrid();

                TetrisSpawn.instance.NewTetris(TetrisSpawn.instance.GetRandom());

                TetrisSpawn.instance.SetRandom();

                TetrisCloneSpanw.instance.DestroyClone();
                TetrisCloneSpanw.instance.NewTetrisClone(TetrisSpawn.instance.GetRandom());




                Time.timeScale = 1;
            }

            priviousTime = Time.time;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(transform.position.y > 0)
            {
                Time.timeScale = 100;
            }
            //Time.timeScale = 1;
        }
        CheckRow();
    }

    private void AddGrid()
    {
        foreach(Transform child in transform)
        {
            float roundeX = Mathf.Round(child.transform.position.x * 2.0f) * 0.5f;
            float roundeY = Mathf.Round(child.transform.position.y * 2.0f) * 0.5f;

            grid[(int)(roundeX * 2), (int)(roundeY * 2)] = child;
        }
    }
    private bool ValidMove()
    {
        foreach (Transform child in transform)
        {
            float roundeX = Mathf.Round(child.transform.position.x * 2.0f) * 0.5f;
            float roundeY = Mathf.Round(child.transform.position.y * 2.0f) * 0.5f;

            if (roundeX < 0 || roundeX > width || roundeY < 0)
            {
                return false;
            }
            if (grid[(int)(roundeX * 2), (int)(roundeY * 2)] != null)
                return false;
        }
        return true;
    }
    private void CheckRow()
    {
        for(int i = 0; i < 22; i++)
        {
            bool isCheck = true;
            for(int t = 0; t < 10; t++)
            {
                if (grid[t,i] == null)
                {
                    isCheck = false;
                }

            }
            if(isCheck)
            {
                //to do destroy
                DestroyRow(i);
                RowDown(i);
                //Debug.Log(i);
            }
        }
    }
    void DestroyRow(int i)
    {
        View.Instance.SetScore();
        if(View.Instance.GetEffect() == 1)
            GameObject.FindGameObjectWithTag("RowClear").GetComponent<AudioSource>().Play();
        for (int j = 0; j < 10; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null; 
        }
    }
    void RowDown(int i)
    {
        for (int t = i; t < 22; t++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (grid[j,t] != null)
                {
                    grid[j, t - 1] = grid[j, t];
                    grid[j, t] = null;
                    grid[j, t - 1].transform.position -= new Vector3(0,0.5f);
                }
            }
        }
    }
    public bool CheckLost()
    {
        for(int i = 0;i<width;i++)
        {
            if (grid[i,17] != null)
            {
                return true;
            }
        }
        return false;
    }
    void Illution()
    {
        foreach(Transform child in transform)
        {
            float roundeY = Mathf.Round(child.transform.position.y * 2.0f) * 0.5f;

            SpriteRenderer renderer = child.GetComponent<SpriteRenderer>();
            Color color = renderer.color;
            if (roundeY > 8.75)
            {
                color.a = 0f;
                renderer.color = color;
            }
            else
            {
                color.a = 255f;
                renderer.color = color;
            }
        }
    }
    
}
