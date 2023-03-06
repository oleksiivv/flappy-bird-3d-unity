using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        PlayerPrefs.SetInt("pause", 1);
        Application.LoadLevel(Application.loadedLevel);
    }
}
