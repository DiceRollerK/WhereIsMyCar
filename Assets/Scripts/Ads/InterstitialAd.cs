using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitID = "Interstitial_Android";
    string _adUnitId;
    public event Action OnInterstitialAdLoaded;
    public bool isReady = false;
    [SerializeField] Button _interstitalAdButton;

    void Awake()
    {
        _adUnitId = _androidAdUnitID;
    }

    private void Update()
    {
        if(AdManager.Instance != null && AdManager.Instance.interstitialAd != null)
        {
            _interstitalAdButton.interactable = AdManager.Instance.interstitialAd.isReady;
        }
    }

    public void OnInterstitialAdButtonClicked()
    {
        Debug.Log("Interstitial Ad Button Clicked");
        ShowInterstitial();
    }

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
            // Papildināsim priekš banner ad

            Advertisement.Show(_adUnitId, this);
            isReady = false;
        } else
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
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }
}
