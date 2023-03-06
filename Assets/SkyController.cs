using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SkyController : MonoBehaviour
{

    public Material day;
    public Material night;

    public Color32 dayColor,nightColor;

    public Text[] textToSwitch;
    // Start is called before the first frame update
    void Start()
    {
        // int hour = System.DateTime.Now.Hour;

        // if (hour >= 19 || hour < 8)
        // {
        //     RenderSettings.skybox = night;
        //     RenderSettings.fogColor = nightColor;
        //     RenderSettings.ambientSkyColor = new Color32(0,0,0,255);


        //     foreach (Text txt in textToSwitch)
        //     {
        //         txt.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
        //     }

        // }
        // else
        // {
        //     RenderSettings.skybox = day;
        //     RenderSettings.fogColor = dayColor;
        //     RenderSettings.ambientSkyColor = new Color32(255,255,255, 255);

        //     foreach (Text txt in textToSwitch)
        //     {
        //         txt.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        //     }
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
