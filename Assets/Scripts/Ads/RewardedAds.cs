using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "BP_Rewarded_Android";
    [SerializeField] float reloadDelay = 15f;

    // Scene scripts subscribe to this to decide what the reward does.
    public static event Action OnRewardEarned;

    Button _rewardedAdButton;

    public void LoadAd()
    {
        if (!Advertisement.isInitialized) return;
        Advertisement.Load(_androidAdUnitId, this);
    }

    public void ShowAd()
    {
        SetBanner(false);
        if (_rewardedAdButton != null) _rewardedAdButton.interactable = false;
        Advertisement.Show(_androidAdUnitId, this);
    }

    public void SetButton(Button button)
    {
        if (button == null) return;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ShowAd);
        _rewardedAdButton = button;
        _rewardedAdButton.interactable = false;
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId == _androidAdUnitId && _rewardedAdButton != null)
            _rewardedAdButton.interactable = true;
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogWarning($"Rewarded ad failed to load: {error} - {message}");
        StartCoroutine(ReloadAfter(10f));
    }

    public void OnUnityAdsShowStart(string placementId) { Time.timeScale = 0f; }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState state)
    {
        if (placementId != _androidAdUnitId) return;

        Time.timeScale = 1f;
        SetBanner(true);

        if (state == UnityAdsShowCompletionState.COMPLETED)
            OnRewardEarned?.Invoke();           // after timeScale is restored

        StartCoroutine(ReloadAfter(reloadDelay));
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogWarning($"Rewarded ad failed to show: {error} - {message}");
        Time.timeScale = 1f;
        SetBanner(true);
        StartCoroutine(ReloadAfter(10f));
    }

    IEnumerator ReloadAfter(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        LoadAd();
    }

    static void SetBanner(bool show)
    {
        var banner = AdManager.Instance != null ? AdManager.Instance.bannerAd : null;
        if (banner == null) return;
        if (show) banner.ShowBannerAd(); else banner.HideBannerAd();
    }
}