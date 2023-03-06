using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Vector3 offset;
    void Start()
    {
        offset = new Vector3(player.transform.position.x - transform.position.x,0, player.transform.position.z - transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z)-offset;
    }
}
