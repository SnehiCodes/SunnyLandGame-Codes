using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fall : MonoBehaviour
{
    //[SerializeField]private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // PermanentUI.perm.Reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            HealthManager.health--;
            PlayerController.heart -=1;
        }
    }
}
