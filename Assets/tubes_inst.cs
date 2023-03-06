using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tubes_inst : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject upper;
    public GameObject lower;
    public GameObject score;

    public GameObject stone;
    public GameObject coin;
    int diff = 430;
    int diff1 = 10;

    int coinCnt=1;
    void Start()
    {
        StartCoroutine(instTube());
        int i = 0;
        while (i<12)
        {
            var fullHeight = 24;
            var brdHeight = 5;

            var lowerHeight = Random.Range(2, 8);
            var upperHeight = fullHeight - lowerHeight - brdHeight;

            lower.transform.localScale = new Vector3(lower.transform.localScale.x, lowerHeight, lower.transform.localScale.z);
            Instantiate(lower, new Vector3(lower.transform.position.x - diff1, 0, lower.transform.position.z), lower.transform.rotation);

            score.transform.localScale = new Vector3(3,40,15);
            Instantiate(score, new Vector3(lower.transform.position.x - diff1-4, 20, lower.transform.position.z), lower.transform.rotation);

            upper.transform.localScale = new Vector3(upper.transform.localScale.x, upperHeight, upper.transform.localScale.z);
            Instantiate(upper, new Vector3(lower.transform.position.x + 4 - diff1, 2 * upperHeight + 2 * lowerHeight + brdHeight * 2, lower.transform.position.z), upper.transform.rotation);

            Instantiate(stone, new Vector3(-diff1, 0, Random.Range(188, 237)), stone.transform.rotation);
            if(Random.Range(0,5)==2)Instantiate(coin,new Vector3(-diff1+4,Random.Range(2f,18f),coin.transform.position.z),coin.transform.rotation);

            diff1 += 35;
            i++;
            //coinCnt++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator instTube()
    {

        while (true)
        {
            var fullHeight = 24;
            var brdHeight = 5.5f;

            var lowerHeight = Random.Range(2, 8);
            var upperHeight = fullHeight - lowerHeight - brdHeight;

            lower.transform.localScale = new Vector3(lower.transform.localScale.x, lowerHeight, lower.transform.localScale.z);
            Instantiate(lower, new Vector3(lower.transform.position.x - diff, 0, lower.transform.position.z), lower.transform.rotation);

            score.transform.localScale = new Vector3(3, 40, 15);
            Instantiate(score, new Vector3(lower.transform.position.x - diff - 4, 20, lower.transform.position.z), lower.transform.rotation);

            upper.transform.localScale = new Vector3(upper.transform.localScale.x, upperHeight, upper.transform.localScale.z);
            Instantiate(upper, new Vector3(lower.transform.position.x+4 - diff,2*upperHeight+2*lowerHeight+brdHeight*2, lower.transform.position.z), upper.transform.rotation);

            Instantiate(stone, new Vector3(-diff, 0, Random.Range(188, 237)), stone.transform.rotation);
            if(Random.Range(0,5)==2)Instantiate(coin,new Vector3(-diff1+2,Random.Range(2f,18f),coin.transform.position.z),coin.transform.rotation);

            //diff += 10;
            //coinCnt++;

            yield return new WaitForSeconds(1.3f);
        }





    }

}
