using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;

using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    bool up = true;
    public GameObject animalPixel;
    public GameObject animalLowPoly;

    public BoxCollider[] pixel;
    public BoxCollider[] lowPoly;

    public Text startText, pauseText, score,scoreT, record;
    bool start = false;
    bool pause = false;

    int scor=0;

#if UNITY_IOS
    string gameId="3553556";
#else
    string gameId="3553557";
#endif

    private GameObject animal;



    public GameObject choose;
    public Text coins;
    void Start()
    {
        choose.SetActive(false);
        if (PlayerPrefs.GetInt("Type") == 1)
        {
            animal = animalLowPoly;
            animalPixel.SetActive(false);
            animalLowPoly.SetActive(true);
            for(int i = 0; i < pixel.Length; i++)
            {
                pixel[i].enabled = false;
            }
            for (int i = 0; i < lowPoly.Length; i++)
            {
                lowPoly[i].enabled = true;
            }

        }
        else
        {
            animal = animalPixel;
            animalPixel.SetActive(true);
            animalLowPoly.SetActive(false);

            for (int i = 0; i < pixel.Length; i++)
            {
                pixel[i].enabled = true;
            }
            for (int i = 0; i < lowPoly.Length; i++)
            {
                lowPoly[i].enabled = false;
            }
        }


        Advertisement.Initialize(gameId, false);
        if (PlayerPrefs.GetInt("pause") == 0)
        {
            Time.timeScale = 0;
            startText.gameObject.SetActive(true);
            score.gameObject.SetActive(false);
            scoreT.gameObject.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("pause", 0);
            Time.timeScale = 1;
            startText.gameObject.SetActive(false);
            pauseText.gameObject.SetActive(false);
            score.gameObject.SetActive(true);
            scoreT.gameObject.SetActive(true);
            

        }

        coins.text=PlayerPrefs.GetInt("money").ToString();

        MobileAds.Initialize(appId);
        RequestConfigurationAd();
    }

    // Update is called once per frame
    void Update()
    {
        record.GetComponent<Text>().text = Convert.ToString(PlayerPrefs.GetInt("record"));

        //if(start&&!pause)transform.position -= new Vector3(0, 0.2f, 0);
        if(start) GetComponent<Rigidbody>().AddForce(transform.up * -5, ForceMode.Impulse);
        //gameObject.GetComponent<Rigidbody>().velocity = transform.right*-2;
        if (Input.GetKeyDown(KeyCode.Space)&&up)
        {
            GetComponent<AudioSource>().Play();
            if (!start)
            {
           
                score.gameObject.SetActive(true);
                scoreT.gameObject.SetActive(true);
                Time.timeScale = 1;
                startText.gameObject.SetActive(false);
                pauseText.gameObject.SetActive(false);
                start = true;
            }
            else
            {
                up = false;
                gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 220, ForceMode.Impulse);
                //GetComponent<Rigidbody>().velocity = Vector3.up * 4f;
            }
            //gameObject.GetComponent<Rigidbody>().velocity=transform.up * 14f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            up = true;
            //gameObject.GetComponent<Rigidbody>().AddForce(transform.up * -49, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {

            if (!EventSystem.current.IsPointerOverGameObject())
            {

                GetComponent<AudioSource>().Play();
            }
            if (!start)
            {
                score.gameObject.SetActive(true);
                scoreT.gameObject.SetActive(true);
                Time.timeScale = 1;
                startText.gameObject.SetActive(false);
                pauseText.gameObject.SetActive(false);
                start = true;
            }

        

            gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 190, ForceMode.Impulse);
        }

        score.GetComponent<Text>().text = Convert.ToString(scor);

        //if(up)gameObject.GetComponent<Rigidbody>().AddForce(-transform.up * 8, ForceMode.Impulse);
    }

    static int cnt = 1;
    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "tube")
        {
            if (scor > PlayerPrefs.GetInt("record"))
            {
                PlayerPrefs.SetInt("record", scor);
            }
             if (cnt % 3 == 0)
             {
                 if(!showIntersitionalAd()){
                     if(Advertisement.IsReady("video")){
                         Advertisement.Show("video");
                     }
                 }
                 
             }
            cnt++;
            pauseText.gameObject.SetActive(true);
            Time.timeScale = 0;
            pause = true;
            start = true;
            animal.GetComponent<AudioSource>().Play();
            choose.SetActive(true);

        }
        
    }

    int i = 0;
  
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(i);
        i++;
        if (other.tag == "score")
        {
            
            Debug.Log(i);
            i++;
            scor += 25;
        }
        if(other.tag=="coin"){
            PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")+1);
            other.gameObject.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Play();
            other.GetComponent<BoxCollider>().enabled=false;
            other.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled=false;
            if(PlayerPrefs.GetInt("mute")==0)other.GetComponent<AudioSource>().Play();
            coins.text=PlayerPrefs.GetInt("money").ToString();
        }


    }


    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("pause", 0);

    }





     private InterstitialAd intersitional;

#if UNITY_IOS
    private string appId="ca-app-pub-4962234576866611~6363351885";
    private string intersitionalId="ca-app-pub-4962234576866611/6323807526";
#else
    private string appId="ca-app-pub-4962234576866611~6224026170";
    private string intersitionalId="ca-app-pub-4962234576866611/3209231391";
#endif

     AdRequest AdRequestBuild(){
         return new AdRequest.Builder().Build();
     }


      void RequestConfigurationAd(){
          intersitional=new InterstitialAd(intersitionalId);
          AdRequest request=AdRequestBuild();
          intersitional.LoadAd(request);

          intersitional.OnAdLoaded+=this.HandleOnAdLoaded;
          intersitional.OnAdOpening+=this.HandleOnAdOpening;
          intersitional.OnAdClosed+=this.HandleOnAdClosed;

      }


      public bool showIntersitionalAd(){
          if(intersitional.IsLoaded()){
              intersitional.Show();

              return true;
          }

          return false;
      }

      private void OnDestroy(){
          DestroyIntersitional();

          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

      }

      private void HandleOnAdClosed(object sender, EventArgs e)
      {
          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

            RequestConfigurationAd();

        
      }

      private void HandleOnAdOpening(object sender, EventArgs e)
    {
        
    }

    private void HandleOnAdLoaded(object sender, EventArgs e)
    {
        
    }

 

     public void DestroyIntersitional(){
         intersitional.Destroy();
     }



}
