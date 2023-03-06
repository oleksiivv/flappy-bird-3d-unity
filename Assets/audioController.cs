using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    public GameObject[] audioControllers;
    public GameObject mute, unmute;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("mute") == 0)
        {
            int i = 0;
            for (; i < audioControllers.Length; i++)
            {
                audioControllers[i].GetComponent<AudioSource>().mute = false;
            }

            unmute.SetActive(false);
            mute.SetActive(true);
        }
        else
        {
            int i = 0;
            for (; i < audioControllers.Length; i++)
            {
                audioControllers[i].GetComponent<AudioSource>().mute = true;
            }


            unmute.SetActive(true);
            mute.SetActive(false);
        }
    }

    public void soundOff()
    {
        PlayerPrefs.SetInt("mute",1);
        
    }

    public void soundOn()
    {
        PlayerPrefs.SetInt("mute", 0);
        
    }


}
