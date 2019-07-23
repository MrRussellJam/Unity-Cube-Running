using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EatFood : MonoBehaviour {

    public Text Score;

    public static int score;

    public void Update()
    {
        if (transform.position.y < -0.7) 
        {
            Debug.Log(transform.position.y);
            Score.text = "GameOver";
            Time.timeScale = 0;
        }
        else
        {
            Score.text = score.ToString();
            Time.timeScale = 1;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name + "  " + collision.collider.tag);
        if (collision.collider.tag == "food")
        {
            Debug.Log(collision.collider.name + "  " + collision.collider.tag);
            Debug.Log(Score.name);
            score += 1;
            Score.text = score.ToString();
            collision.collider.gameObject.SetActive(false);
        }
    }

}
