using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
            m_IsPlayerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
            m_IsPlayerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsPlayerInRange)
        {
            Vector3 direction = player.position + Vector3.up - transform.position;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
                if (raycastHit.collider.transform == player)
                    gameEnding.CaughtPlayer();
        }
        
    }

}
