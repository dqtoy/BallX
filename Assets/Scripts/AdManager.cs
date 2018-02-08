using UnityEngine;
using System.Collections;
using admob;

public class AdManager : MonoBehaviour
{
    public bool typeAd = true;
    public string BannerId = "ca-app-pub-4849249785415369/2155843537";
    public string InterstitialId = "ca-app-pub-4849249785415369/2184366332";
    public static AdManager adManager = null;
    // Use this for initialization
    void Start()
    {
    #if UNITY_EDITOR
    #elif UNITY_ANDROID

        if (adManager == null)
        {
            adManager = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        Admob.Instance().initAdmob(BannerId,InterstitialId);
        if (typeAd)
            Admob.Instance().setTesting(true);
        Admob.Instance().loadInterstitial();
        ShowBanner();
        
    #endif
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ShowBanner()
    {
    #if UNITY_EDITOR
        print("Banner");
    #elif UNITY_ANDROID
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 5);
    #endif
    }

    public static void ShowVideo()
    {
    #if UNITY_EDITOR
        print("Video");
    #elif UNITY_ANDROID
        if (Admob.Instance().isInterstitialReady()){
            Admob.Instance().showInterstitial();
        }
    #endif
    }
}
