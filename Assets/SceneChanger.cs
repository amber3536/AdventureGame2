using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{


 

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.name == "bunny")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void loadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}