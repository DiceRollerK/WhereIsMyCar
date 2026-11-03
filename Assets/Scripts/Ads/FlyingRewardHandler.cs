using System.Collections;
using UnityEngine;

public class FlyingRewardHandler : MonoBehaviour
{
    [SerializeField] FlyingObjectManager flyingObjectManager;
    [SerializeField] float slowDuration = 10f;

    void OnEnable() { RewardedAds.OnRewardEarned += GiveReward; }

    void OnDisable()
    {
        RewardedAds.OnRewardEarned -= GiveReward;
        Time.timeScale = 1f;                    // never leave the slowdown behind on a scene change
    }

    void GiveReward()
    {
        if (flyingObjectManager == null)
            flyingObjectManager = FindFirstObjectByType<FlyingObjectManager>();
        if (flyingObjectManager != null)
            flyingObjectManager.DestroyAllFlyingObjects();

        StartCoroutine(SlowDown());
    }

    IEnumerator SlowDown()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSecondsRealtime(slowDuration);
        Time.timeScale = 1f;
    }
}