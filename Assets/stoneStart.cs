using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var sc = Random.Range(0.3f, 3);
        transform.localScale = new Vector3(sc, sc, sc);
        //transform.Rotate(0, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
