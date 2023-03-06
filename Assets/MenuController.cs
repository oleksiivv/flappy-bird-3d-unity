using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class MenuController : MonoBehaviour
{
    public GameObject[] item;
    public Image[] bg;

    public static int current=0;
    public Color32 winter;
    public Color32 forest;
    public Color32 summer;
    public Color32 autumn;
    public Color32 comingsoon;

    public GameObject[] winterBuy,summerBuy,autumnBuy;

    public Text hi,money;

#if UNITY_IOS
    string id="3553556";
#else
    string id="3553557";
#endif
    private void Start(){
        Advertisement.Initialize(id,false);

        //PlayerPrefs.SetInt("money",1000);
        hi.text=PlayerPrefs.GetInt("record").ToString();
        money.text=PlayerPrefs.GetInt("money").ToString();
        if(PlayerPrefs.GetInt("level1")==1){
            foreach(var wi in winterBuy)wi.SetActive(false);
        }
        if(PlayerPrefs.GetInt("level2")==1){
            foreach(var si in summerBuy)si.SetActive(false);
        }
        if(PlayerPrefs.GetInt("level3")==1){
            foreach(var ai in autumnBuy)ai.SetActive(false);
        }

        change(current);
    }

    public void left(){

        if(current>0)current--;
        else current=item.Length-1;

        change(current);

    }

    public void right(){
        if(current<item.Length-1)current++;
        else current=0;

        change(current);
    }

    private void change(int newItem){
        for(int i=0;i<item.Length;i++){
            item[i].SetActive(false);
        }
        item[newItem].SetActive(true);

        foreach(var i in bg){
            if(newItem==1){
                i.GetComponent<Image>().color=winter;
            }
            else if(newItem==0){
                i.GetComponent<Image>().color=forest;
            }
            else if(newItem==2){
                i.GetComponent<Image>().color=summer;
            }
            else if(newItem==3){
                i.GetComponent<Image>().color=autumn;
            }
            else{
                i.GetComponent<Image>().color=comingsoon;
            }
        }
    }

    public void start(){
        if(current==0){
            StartCoroutine(loadAsync(current+1));
        }
        else{
            if(PlayerPrefs.GetInt("level"+current.ToString())==1){
                StartCoroutine(loadAsync(current+1));
            }
        }
    }

    
    public void buyWinter(){
        if(PlayerPrefs.GetInt("money")<50)return;

        PlayerPrefs.SetInt("level1",1);
        foreach(var wi in winterBuy)wi.SetActive(false);

        PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-50);
        money.text=PlayerPrefs.GetInt("money").ToString();
        if(PlayerPrefs.GetInt("mute")==0)GameObject.Find("DirectionalLight").GetComponent<AudioSource>().Play();
        
    }


    public void buyBeach(){
        if(PlayerPrefs.GetInt("money")<80)return;

        PlayerPrefs.SetInt("level2",1);
        foreach(var si in summerBuy)si.SetActive(false);

        PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-80);
        money.text=PlayerPrefs.GetInt("money").ToString();
        if(PlayerPrefs.GetInt("mute")==0)GameObject.Find("DirectionalLight").GetComponent<AudioSource>().Play();
        
    }

    public void buyAutumn(){
        if(PlayerPrefs.GetInt("money")<120)return;

        PlayerPrefs.SetInt("level3",1);
        foreach(var ai in autumnBuy)ai.SetActive(false);

        PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-120);
        money.text=PlayerPrefs.GetInt("money").ToString();
        if(PlayerPrefs.GetInt("mute")==0)GameObject.Find("DirectionalLight").GetComponent<AudioSource>().Play();
        
    }


    public GameObject loadingPanel;
    public Slider loadingSlider;

    IEnumerator loadAsync(int id)
    {
        AsyncOperation operation = Application.LoadLevelAsync(id);
        loadingPanel.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            Debug.Log(progress);
            yield return null;

        }
    }

    public void rate(){
        Application.OpenURL("https://vertexstudio.herokuapp.com/games/game?game=7");
    }



    public void watchAdd(){
      ShowOptions options = new ShowOptions();
      options.resultCallback = AdCallbackHandler;
      if(Advertisement.IsReady("rewardedVideo")){
        Advertisement.Show("rewardedVideo",options);
      }
    }








    void AdCallbackHandler(ShowResult res)
    {
        if (res == ShowResult.Finished)
        {
          PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")+10);
          //gameObject.GetComponent<AudioSource>().Play();
          money.text=PlayerPrefs.GetInt("money").ToString();

        }
        else if (res == ShowResult.Skipped)
        {
            Debug.Log("skipped");
        }
        else if (res == ShowResult.Skipped)
        {
            Debug.Log("error");
        }
    }
}
