using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour {

    public InputField PlayerSpeed;

    public InputField BackSpeed;

    public void saveData()
    {
        if (PlayerSpeed.text != "")
            playerMovement.moveForce = (float)System.Convert.ToDouble(PlayerSpeed.text);
        if (BackSpeed.text != "")
            playerMovement.SvipForce = (float)System.Convert.ToDouble(BackSpeed.text);
    }
}
