﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side_Collision : MonoBehaviour
{
    GameObject GameOver;
    private void Awake()
    {
        GameOver = GameObject.Find("EventSystem");
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        
             

        if(GameManager.instance.Is_Fever == false)
        {
            if (col.gameObject.tag == "First" || col.gameObject.tag == "Second"|| col.gameObject.tag == "Controllable")
            {
                Debug.Log("SIde");
                GameOver.GetComponent<gameOver>().Gameover(); 
            }
        }
        Destroy(col.gameObject);

    }
}
