using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
public class Banner : MonoBehaviour
{
    Banner bannerAds = null;


#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/6300978111"; // TEST ID
#elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
    private string _adUnitId = "unused";
#endif

    BannerView _bannerView;

    private void Awake()
    {
        ManageSingleton();
    }

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
        });

        this.LoadAd();
    }


    void ManageSingleton()
    {
        if(bannerAds == null)
        {
            bannerAds = this;
            DontDestroyOnLoad(this);
        }
        else if(this != bannerAds)
        {
            Destroy(gameObject);
        }

    }

    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            DestroyAd();
        }

        // Create a 320x50 banner at top of the screen
        _bannerView = new BannerView(_adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
    }
    public void LoadAd()
    {
        // create an instance of a banner view first.
        if (_bannerView == null)
        {
            CreateBannerView();
        }
        // create our request used to load the ad.
        var adRequest = new AdRequest.Builder()
            .AddKeyword("unity-admob-sample")
            .Build();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }

    public void DestroyAd()
    {
        if (_bannerView != null)
        {
            Debug.Log("Destroying banner ad.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }


}
