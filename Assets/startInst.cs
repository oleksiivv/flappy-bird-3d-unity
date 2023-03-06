using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startInst : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var sc = Random.Range(4, 9);
        transform.localScale = new Vector3(sc,sc,sc);
        transform.Rotate(0, Random.Range(0, 180), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
