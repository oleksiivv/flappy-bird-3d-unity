using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanerDecor : MonoBehaviour
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
        if (player.transform.position.x < transform.position.x - 150) gameObject.SetActive(false) ;
    }
}
