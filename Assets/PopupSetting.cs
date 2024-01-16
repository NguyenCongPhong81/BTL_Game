using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popupsetting : MonoBehaviour
{
    //public GameObject PopupSetting;
    public GameObject Menu;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
        //PopupSetting.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                resumegame();
            }
            else
            {
                pausegame();
            }
        }
    }

    public void pausegame()
    {
        Menu.SetActive(true);
        AudioListener.pause=true;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void resumegame()
    {
        Menu.SetActive(false);
        AudioListener.pause=false;
        Time.timeScale = 1f;
        isPaused = false;
    }
}
