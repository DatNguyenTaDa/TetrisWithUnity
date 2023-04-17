using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoolDown : MonoBehaviour
{
    private float cd;
    // Start is called before the first frame update
    void Start()
    {
        cd = 3;
    }

    // Update is called once per frame
    void Update()
    {
        cd -= Time.deltaTime;
        if(Mathf.Round(cd)==0)
        {
            this.gameObject.SetActive(false);
            View.Instance.Play();
            return;
        }
        GameObject.FindGameObjectWithTag("CDText").GetComponent<TMP_Text>().text = Mathf.Round(cd).ToString();
    }
    
}
