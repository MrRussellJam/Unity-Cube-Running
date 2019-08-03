using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapner : MonoBehaviour
{

    public GameObject[] model;

    // Start is called before the first frame update
    void Start()
    {
        swapnerNext();
    }
    
    void swapnerNext()
    {
        int i = Random.Range(0, model.Length - 1);

        GameObject temp = Instantiate(model[i], transform.position, Quaternion.identity) as GameObject;
    }

}
