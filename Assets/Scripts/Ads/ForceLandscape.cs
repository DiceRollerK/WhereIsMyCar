using UnityEngine;

public class ForceLandscape : MonoBehaviour
{
    [Tooltip("What the rest of the app uses: Portrait if it's portrait-only, AutoRotation if it rotates freely.")]
    [SerializeField] ScreenOrientation orientationOnExit = ScreenOrientation.AutoRotation;

    void Awake()
    {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = ScreenOrientation.LandscapeLeft;   // landscape, either side
    }

    void OnDestroy()
    {
        // give the other scenes their normal behaviour back
        Screen.autorotateToPortrait = true;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = orientationOnExit;
    }
}