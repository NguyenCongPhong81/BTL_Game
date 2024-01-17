using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseTrigger : MonoBehaviour
{
    public GameObject EndGame;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            EndGame.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause=true;
        }
    }
}
