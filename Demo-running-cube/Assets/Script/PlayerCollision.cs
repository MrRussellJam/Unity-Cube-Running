using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    public playerMovement PlayerMovement;

    public Text StatusText;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle1")
        {
            PlayerMovement.enabled = false;
            StatusText.fontSize = 50;
            Time.timeScale = 0;
            StatusText.text = "You are Lose\nPress the key Enter to return Menu";
        }
        if (collision.collider.tag == "Destination")
        {
            PlayerMovement.enabled = false;
            StatusText.fontSize = 50;
            Time.timeScale = 0;
            StatusText.text = "You are win!\nPress the key Enter to return Menu";
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if(collision.collider.name == "Ground")
        {
            PlayerMovement.enabled = false;
            StatusText.fontSize = 50;
            Time.timeScale = 0;
            StatusText.text = "You are Lose\nPress the key Enter to return Menu";
        }
    }

    public void Update()
    {
        if (Input.GetKey("return"))
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(0);
        }
    }

}
