using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groups : MonoBehaviour
{

    private int lastTime = 0;

    internal static int point = 0;

    void Start()
    {
        if(!Grid.isAllRange(transform))
        {
            Debug.Log("GameOver");
            Destroy(gameObject);
            GameObject.Find("Main Camera/Canvas/GAME OVER").SetActive(true);
            Time.timeScale = 0;
        }
        //Destroy(gameObject);
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if(Input.GetKeyDown(KeyCode.LeftArrow))                 //左移
        {
            transform.position += new Vector3(-1, 0, 0);
            if(Grid.isAllRange(transform))
            {

            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))           //右移
        {
            transform.position += new Vector3(1, 0, 0);
            if (Grid.isAllRange(transform))
            {

            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))           //旋转
        {
            transform.Rotate(new Vector3(0, 0, 90));

            if (Grid.isAllRange(transform))
            {

            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -90));
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastTime > 1)        //降落
        {
            if(Time.time - lastTime > 1)
                lastTime = (int)Time.time;

            transform.position += new Vector3(0, -1, 0);

            if (Grid.isAllRange(transform))
            {

            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                int points = Grid.FillAllGrid(transform);
                if(points > 0)
                    point += (int)Mathf.Pow(2, points);
                enabled = false;
                GameObject.Find("Swapner").SendMessage("swapnerNext");
            }
        }
    }
}
