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
    public GameObject[] vehicleSpots = new GameObject[17];
    public GameObject[] placeSpots = new GameObject[17];
    [HideInInspector]
    public int[] spots = new int[17];

    void Awake()
    {
        /*
        for (int i = 0; i < spots.Length; i++)
        {
            spots[i] = i;
        }
        spots = shuffle(spots);
        */
        //garbageTruckCoord = vehicleSpots[spots[0]];
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

    int[] shuffle(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            int tmp = numbers[i];
            int r = Random.Range(i, numbers.Length);
            numbers[i] = numbers[r];
            numbers[r] = tmp;
        }
        return numbers;
    }
}
