﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpsController : MonoBehaviour
{

    public Text fpsCount;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 40;
    }

    // Update is called once per frame
    void Update()
    {
        fpsCount.GetComponent<Text>().text = ((int)(1f / Time.unscaledDeltaTime)).ToString() ;
    }
}
