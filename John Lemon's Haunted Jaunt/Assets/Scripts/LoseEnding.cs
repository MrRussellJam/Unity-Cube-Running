using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseEnding : MonoBehaviour
{
    
    public GameObject Player;
    public CanvasGroup Canvas;

    float m_time;
    bool m_PlayerIshere;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
            m_PlayerIshere = true;
    }

    private void Update()
    {
        if (m_PlayerIshere)
            Lose();
    }

    void Lose()
    {
        m_time = m_time + Time.deltaTime;
        Debug.Log(m_time + "<mTime   DeltaTime>" + Time.deltaTime);
        Canvas.alpha = m_time / 1f;
        if (m_time > 2f)
        {
            Application.Quit();
            Time.timeScale = 0;
        }
    }
}
