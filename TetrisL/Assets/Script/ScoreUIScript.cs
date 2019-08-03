using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIScript : MonoBehaviour
{
    private Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = this.GetComponent<Text>();
        score.text = Convert.ToString(Groups.point);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = Convert.ToString(Groups.point);
    }
}
