using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "BP_Rewarded_Android";
    string _adUnitId;

    [SerializeField] Button _rewardedAdButton;
    public FlyingObjectManager flyingObjectManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _adUnitId = _androidAdUnitId;
        if(flyingObjectManager == null)
        {
            flyingObjectManager = FindFirstObjectByType<FlyingObjectManager>();
        }
    }

    public void LoadAd()
    {
        if (!Advertisement.isInitialized)
        {
            Debug.Log("Tried to load rewarded ad before Unity Ads was initialized");
            return;
        }

        Debug.Log("Loading Rewarded ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Rewarded ad loaded: "+ placementId);

        if(placementId.Equals(_adUnitId))
        {
            if (_rewardedAdButton != null)
            {
                _rewardedAdButton.interactable = true;
            }
        }
    }

    public void ShowAd()
    {
        AdManager.Instance.bannerAd.HideBannerAd();
        _rewardedAdButton.interactable = false;
        Advertisement.Show(_adUnitId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading rewarded ad {placementId} : {error.ToString()} - {message}");
        StartCoroutine(WaitAndLoadAd(10f));
    }

    private IEnumerator WaitAndLoadAd(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        LoadAd();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Time.timeScale = 1f;
        if (AdManager.Instance.bannerAd != null)
        {
            AdManager.Instance.bannerAd.ShowBannerAd();
        }
        Debug.Log($"Error showing rewarded ad: {placementId} : {error.ToString()} - {message}");
        StartCoroutine(WaitAndLoadAd(10f));
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Time.timeScale = 0f;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("User clicked on rewarded ad: " + placementId);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (!placementId.Equals(_adUnitId))
        {
            return;
        }
        Time.timeScale = 1f;
        if(showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Rewarded ad completed!");
            flyingObjectManager.DestroyAllFlyingObjects();
            _rewardedAdButton.interactable = false;
            StartCoroutine(SlowDownTimeTemporarily(10f));
        }
        AdManager.Instance.bannerAd.ShowBannerAd();
        StartCoroutine(WaitAndLoadAd(15f));
    }

    public void SetButton(Button button)
    {
        if(button == null)
        {
            return;
        }

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ShowAd);
        _rewardedAdButton = button;
        _rewardedAdButton.interactable = false;
    }

    private IEnumerator SlowDownTimeTemporarily(float duration)
    {
        Time.timeScale = 0.3f;
        Debug.Log("Time slowed down for " + duration + " seconds.");
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
        Debug.Log("Time restored to normal.");
    }
}
