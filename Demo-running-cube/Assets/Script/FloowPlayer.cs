using UnityEngine;

public class FloowPlayer : MonoBehaviour {

    public Transform Player;
    public Vector3 Offset;
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Player.position);
        transform.position = Player.position + Offset;
	}
}
