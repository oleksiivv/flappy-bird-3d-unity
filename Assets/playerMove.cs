using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    //int fps;
    // Start is called before the first frame update
    void Start()
    {
        //fps = 40;
    }

    // Update is called once per frame
    void Update()
    {
        //fps = (int)(1f / Time.unscaledDeltaTime);
        transform.Translate(Vector3.right/2*Time.timeScale);
        //gameObject.GetComponent<Rigidbody>().velocity = transform.right*-2;
        
    }
}
