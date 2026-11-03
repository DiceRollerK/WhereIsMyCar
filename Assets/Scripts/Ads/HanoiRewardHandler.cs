using UnityEngine;

public class HanoiRewardHandler : MonoBehaviour
{
    [SerializeField] HanoiGame game;
    [SerializeField] int movesRemoved = 10;

    void OnEnable() { RewardedAds.OnRewardEarned += GiveReward; }
    void OnDisable() { RewardedAds.OnRewardEarned -= GiveReward; }

    void GiveReward()
    {
        if (game != null) game.ReduceMoves(movesRemoved);
    }
}