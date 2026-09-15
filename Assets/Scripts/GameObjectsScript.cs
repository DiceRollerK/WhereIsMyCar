using UnityEngine;

public class GameObjectsScript : MonoBehaviour
{
    public GameObject garbageTruck;
    public GameObject medicine;
    public GameObject schoolBus;
    public GameObject car;
    public GameObject cementTruck;
    public GameObject car2;
    public GameObject car3;
    public GameObject excavator;
    public GameObject police;
    public GameObject tractor;
    public GameObject tractor2;
    public GameObject firetruck;
    // Japievieno parejie

    [HideInInspector]
    public Vector2 garbageTruckCoord;
    [HideInInspector]
    public Vector2 medicineCoord;
    [HideInInspector]
    public Vector2 schoolBusCoord;
    [HideInInspector]
    public Vector2 carCoord;
    [HideInInspector]
    public Vector2 cementTruckCoord;
    [HideInInspector]
    public Vector2 car2Coord;
    [HideInInspector]
    public Vector2 car3Coord;
    [HideInInspector]
    public Vector2 excavatorCoord;
    [HideInInspector]
    public Vector2 policeCoord;
    [HideInInspector]
    public Vector2 tractorCoord;
    [HideInInspector]
    public Vector2 tractor2Coord;
    [HideInInspector]
    public Vector2 firetruckCoord;

    public Canvas canvas;
    public AudioSource carSoundSource;
    public AudioClip[] sounds;

    [HideInInspector]
    public bool inRightPlace = false;
    public static GameObject lastDragged = null;
    public static bool isDragging = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        garbageTruckCoord = garbageTruck.GetComponent<RectTransform>().localPosition;
        medicineCoord = medicine.GetComponent<RectTransform>().localPosition;
        schoolBusCoord = schoolBus.GetComponent<RectTransform>().localPosition;
        carCoord = car.GetComponent<RectTransform>().localPosition;
        cementTruckCoord = cementTruck.GetComponent<RectTransform>().localPosition;
        car2Coord = car2.GetComponent<RectTransform>().localPosition;
        car3Coord = car3.GetComponent<RectTransform>().localPosition;
        excavatorCoord = excavator.GetComponent<RectTransform>().localPosition;
        policeCoord = police.GetComponent<RectTransform>().localPosition;
        tractorCoord = tractor.GetComponent<RectTransform>().localPosition;
        tractor2Coord = tractor2.GetComponent<RectTransform>().localPosition;
        firetruckCoord = firetruck.GetComponent<RectTransform>().localPosition;

    }
}
