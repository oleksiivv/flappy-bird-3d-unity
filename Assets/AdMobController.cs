using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobController : MonoBehaviour
{
    private InterstitialAd intersitional;
    private BannerView banner;
    
#if UNITY_IOS
    public string appId="ca-app-pub-4962234576866611~6363351885";
    //public string intersitionalId="ca-app-pub-4962234576866611/1826596101";

    public string bannerId="ca-app-pub-4962234576866611/3737188546";
#else
    public string appId="ca-app-pub-4962234576866611~6224026170";
    //public string intersitionalId="ca-app-pub-4962234576866611/1826596101";

    public string bannerId="ca-app-pub-4962234576866611/1901637786";
#endif

    void Start(){
        MobileAds.Initialize(appId);
        RequestBannerAd();
        //RequestConfigurationAd();
        
    }

    // AdRequest AdRequestBuild(){
    //     return new AdRequest.Builder().Build();
    // }


    // void RequestConfigurationAd(){
    //     intersitional=new InterstitialAd(intersitionalId);
    //     AdRequest request=AdRequestBuild();
    //     intersitional.LoadAd(request);

    //     intersitional.OnAdLoaded+=this.HandleOnAdLoaded;
    //     intersitional.OnAdOpening+=this.HandleOnAdOpening;
    //     intersitional.OnAdClosed+=this.HandleOnAdClosed;

    // }


    // public void showIntersitionalAd(){
    //     if(intersitional.IsLoaded()){
    //         intersitional.Show();
    //     }
    // }

    // private void OnDestroy(){
    //     DestroyIntersitional();

    //     intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
    //     intersitional.OnAdOpening-=this.HandleOnAdOpening;
    //     intersitional.OnAdClosed-=this.HandleOnAdClosed;

    // }

    // private void HandleOnAdClosed(object sender, EventArgs e)
    // {
    //     intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
    //     intersitional.OnAdOpening-=this.HandleOnAdOpening;
    //     intersitional.OnAdClosed-=this.HandleOnAdClosed;

    //     RequestConfigurationAd();

        
    // }

    // private void HandleOnAdOpening(object sender, EventArgs e)
    // {
        
    // }

    // private void HandleOnAdLoaded(object sender, EventArgs e)
    // {
        
    // }

    // public void DestroyIntersitional(){
    //     intersitional.Destroy();
    // }




    //baner

    public void RequestBannerAd(){
        banner=new BannerView(bannerId,AdSize.Banner,AdPosition.Bottom);
        AdRequest request = AdRequestBannerBuild();
        banner.LoadAd(request);
    }

    public void DestroyBanner(){
        if(banner!=null){
            banner.Destroy();
        }
    }



    AdRequest AdRequestBannerBuild(){
        return new AdRequest.Builder().Build();
    }




    
}

