using UnityEngine;

public class GameObjectsScript : MonoBehaviour
{
    public GameObject garbageTruck;
    public GameObject medicine;
    public GameObject schoolBus;

    [HideInInspector]
    public Vector2 garbageTruckCoord;
    [HideInInspector]
    public Vector2 medicineCoord;
    [HideInInspector]
    public Vector2 schoolBusCoord;

    public Canvas canvas;
    public AudioSource carSoundSource;
    public AudioClip[] sounds;

    [HideInInspector]
    public bool inRightPlace = false;
    public static GameObjectsScript lastDragged = null;
    public static bool isDragging = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        garbageTruckCoord = garbageTruck.GetComponent<RectTransform>().localPosition;
        medicineCoord = medicine.GetComponent<RectTransform>().localPosition;
        schoolBusCoord = schoolBus.GetComponent<RectTransform>().localPosition;
    }
}
