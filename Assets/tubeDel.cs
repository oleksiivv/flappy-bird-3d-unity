using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tubeDel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x - 16) Destroy(gameObject);
    }
}
