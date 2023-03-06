using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectBird : MonoBehaviour
{
    public Image pixel;
    public Image lowPoly;

    public Image pixelArrow;
    public Image lowpolyArrow;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("vaccin", 102);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Type") == 0)
        {
            pixelArrow.gameObject.SetActive(true);
            lowpolyArrow.gameObject.SetActive(false);


            pixel.GetComponent<Image>().color = new Color32(49,253,78, 255);
            lowPoly.GetComponent<Image>().color = new Color32(255,255,255, 255);
        }
        else
        {
            pixelArrow.gameObject.SetActive(false);
            lowpolyArrow.gameObject.SetActive(true);


            lowPoly.GetComponent<Image>().color = new Color32(49, 253, 78, 255);
            pixel.GetComponent<Image>().color = new Color32(255, 255, 255, 255);


        }
    }


    public void choosePixel()
    {
        PlayerPrefs.SetInt("Type",0);
    }

    public void chooseLowPoly()
    {
        PlayerPrefs.SetInt("Type", 1);
    }
}
