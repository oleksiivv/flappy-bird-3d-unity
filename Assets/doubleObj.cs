using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleObj : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject road,bg,decor,upper;
    int diff = 3000,diff2=500;

   

    void Start()
    {
        //StartCoroutine(doubleO());
        StartCoroutine(decorInst());
        //Invoke("des",10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator doubleO (){
        while (true)
        {
            Instantiate(road, new Vector3(road.transform.position.x-diff, road.transform.position.y, road.transform.position.z), Quaternion.identity);
            Instantiate(bg, new Vector3(bg.transform.position.x - diff, bg.transform.position.y, bg.transform.position.z), Quaternion.identity);
            Instantiate(upper, new Vector3(upper.transform.position.x - diff, upper.transform.position.y, upper.transform.position.z), Quaternion.identity);
            diff += 3000;
            yield return new WaitForSeconds(1);

        }

    }
    IEnumerator decorInst()
    {
        while (true)
        {
            Instantiate(decor, new Vector3(decor.transform.position.x - diff2, decor.transform.position.y, decor.transform.position.z), Quaternion.identity);
            //diff2 += 180;
            yield return new WaitForSeconds(10);

        }

    }

    void des()
    {
        Destroy(gameObject);

    }


}
