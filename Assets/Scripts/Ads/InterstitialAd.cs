using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitID = "BP_Interstitial_Android";
    string _adUnitId;
    public event Action OnInterstitialAdReady;
    public bool isReady = false;
    //[SerializeField] Button _interstitalAdButton;
    string scene = null;
    void Awake()
    {
        _adUnitId = _androidAdUnitID;
    }

    private void Update()
    {
        /*
        if(AdManager.Instance != null && AdManager.Instance.interstitialAd != null && _interstitalAdButton != null)
        {
            _interstitalAdButton.interactable = AdManager.Instance.interstitialAd.isReady;
        }
        */
    }

    /*
    public void OnInterstitialAdButtonClicked()
    {
        Debug.Log("Interstitial Ad Button Clicked");
        ShowInterstitial();
    }
    */

    public void ShowInterstitial()
    {
        if(AdManager.Instance.interstitialAd != null && AdManager.Instance.interstitialAd.isReady)
        {
            Debug.Log("Showing interstitial ad manually");
            ShowAd();
        } else
        {
            Debug.LogWarning("Interstitial ad is not ready yet.");
            LoadAd();
        }
    }

    public void ShowAd()
    {
        if(isReady)
        {
            if(AdManager.Instance.bannerAd != null)
            {
                AdManager.Instance.bannerAd.HideBannerAd();
            }

            Advertisement.Show(_adUnitId, this);
            isReady = false;
        } else
        {
            Debug.LogWarning("Interstitial ad is not ready yet!");
        }
    }

    public void ShowAd(String sceneName)
    {
        if (isReady)
        {
            if (AdManager.Instance.bannerAd != null)
            {
                AdManager.Instance.bannerAd.HideBannerAd();
            }

            Advertisement.Show(_adUnitId, this);
            isReady = false;
            scene = sceneName;
        }
        else
        {
            Debug.LogWarning("Interstitial ad is not ready yet!");
        }
    }

    public void LoadAd()
    {
        if(!Advertisement.isInitialized)
        {
            Debug.LogWarning("Tried to load interstitial ad before Unity Ads was initialized!");
            return;
        }

        Debug.Log("Loading interstitial ad...");
        Advertisement.Load(_adUnitId, this);
    }
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Interstitial ad loaded successfully!");
        /*
        if (_interstitalAdButton != null)
        {
            _interstitalAdButton.interactable = true;
        }
        */
        isReady = true;
        OnInterstitialAdReady?.Invoke();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Failed to load interstitial ad: {error.ToString()} - {message}");
        LoadAd();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Interstitial ad clicked!");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {

        Debug.Log($"Interstitial finished: {showCompletionState}");
        GoToPendingScene();
    }
    /*
    private IEnumerator SlowDownTimeTemporarily(float duration)
    {
        Time.timeScale = 0.3f;
        Debug.Log("Time slowed down for " + duration + " seconds.");
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
        Debug.Log("Time restored to normal.");
    }
    */

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Failed to show interstitial ad: {error.ToString()} - {message}");
        GoToPendingScene();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Interstitial ad started showing!");
        Time.timeScale = 0;
    }
    /*
    public void SetButton(Button button)
    {
        if (button == null)
        {
            return;
        }

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnInterstitialAdButtonClicked);
        _interstitalAdButton = button;
        _interstitalAdButton.interactable = false;
    }
    */

    void GoToPendingScene()
    {
        Time.timeScale = 1f;
        string target = scene;
        scene = null;
        if (target != null)
        {
            SceneManager.LoadScene(target);
        }
        LoadAd();
    }
}
