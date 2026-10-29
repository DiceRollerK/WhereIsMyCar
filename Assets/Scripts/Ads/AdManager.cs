using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    public AdsInitializer adsInitializer;
    public InterstitialAd interstitialAd;
    [SerializeField] bool turnOffInterstitialAds = false;
    //private bool firstAdShown = false;

    public RewardedAds rewardedAds;
    [SerializeField] bool turnOffRewardedAds = false;

    public BannerAd bannerAd;
    [SerializeField] bool turnOffBannerAds = false;
    public static AdManager Instance { get; private set; }

    private bool firstSceneLoaded = false;

    //public Button interstitialButton;
    public Button rewardedAdButton;
    //public Button bannerAdButton;
    // Turpināsim
    private void Awake()
    {
        if(adsInitializer == null)
        {
            adsInitializer = FindFirstObjectByType<AdsInitializer>();
        }

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        adsInitializer.OnAdsInitialized += HandleAdsInitialized;
    }

    private void HandleAdsInitialized()
    {
        if (!turnOffInterstitialAds && interstitialAd != null && !interstitialAd.isReady)
        {
            interstitialAd.LoadAd();
        }

        if (!turnOffRewardedAds && rewardedAds != null)
        {
            rewardedAds.LoadAd();
        }

        if (!turnOffBannerAds && bannerAd != null)
        {
            bannerAd.LoadBanner();
        }
    }

    /*
    private void HandleInterstitialReady()
    {
        if(!firstAdShown)
        {
            Debug.Log("Showing interstitial ad for the first time!");
            interstitialAd.ShowAd();
            firstAdShown = true;
        } else
        {
            Debug.Log("Interstitial ad is ready to be shown again!");
        }
    }
    */

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(interstitialAd == null)
        {
            interstitialAd = FindFirstObjectByType<InterstitialAd>();
        }

        /*
        if (GameObject.FindGameObjectWithTag("InterstitialAdButton"))
        {
            interstitialButton = GameObject.FindGameObjectWithTag("InterstitialAdButton").GetComponent<Button>();
        }
        if(interstitialAd != null && interstitialButton != null)
        {
            interstitialAd.SetButton(interstitialButton);
        }
        */

        if(rewardedAds == null)
        {
            rewardedAds = FindFirstObjectByType<RewardedAds>();
        }

        if (GameObject.FindGameObjectWithTag("RewardedAdButton"))
        {
            rewardedAdButton = GameObject.FindGameObjectWithTag("RewardedAdButton").GetComponent<Button>();
        }

        if(rewardedAds != null && rewardedAdButton != null)
        {
            rewardedAds.SetButton(rewardedAdButton);
        }
        /*

        if (GameObject.FindGameObjectWithTag("BannerAdButton"))
        {
            bannerAdButton = GameObject.FindGameObjectWithTag("BannerAdButton").GetComponent<Button>();
        }

        
        if (bannerAd != null && bannerAdButton != null)
        {
            bannerAd.SetButton(bannerAdButton);
        }
        */

        if (!firstSceneLoaded)
        {
            firstSceneLoaded = true;
            Debug.Log("First scene loaded!");
            return;
        }

        Debug.Log("Scene reloaded!");
        HandleAdsInitialized();
    }
}
