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
    public GameObject garbageTruckPlace;
    public GameObject medicinePlace;
    public GameObject schoolBusPlace;
    public GameObject carPlace;
    public GameObject cementTruckPlace;
    public GameObject car2Place;
    public GameObject car3Place;
    public GameObject excavatorPlace;
    public GameObject policePlace;
    public GameObject tractorPlace;
    public GameObject tractor2Place;
    public GameObject firetruckPlace;

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
    [HideInInspector]
    public Vector2 garbageTruckPlaceCoord;
    [HideInInspector]
    public Vector2 medicinePlaceCoord;
    [HideInInspector]
    public Vector2 schoolBusPlaceCoord;
    [HideInInspector]
    public Vector2 carPlaceCoord;
    [HideInInspector]
    public Vector2 cementTruckPlaceCoord;
    [HideInInspector]
    public Vector2 car2PlaceCoord;
    [HideInInspector]
    public Vector2 car3PlaceCoord;
    [HideInInspector]
    public Vector2 excavatorPlaceCoord;
    [HideInInspector]
    public Vector2 policePlaceCoord;
    [HideInInspector]
    public Vector2 tractorPlaceCoord;
    [HideInInspector]
    public Vector2 tractor2PlaceCoord;
    [HideInInspector]
    public Vector2 firetruckPlaceCoord;

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
        
        for (int i = 0; i < spots.Length; i++)
        {
            spots[i] = i;
        }
        spots = shuffle(spots);
        
        garbageTruckCoord = vehicleSpots[spots[1]].transform.position;
        medicineCoord = vehicleSpots[spots[2]].transform.position;
        schoolBusCoord = vehicleSpots[spots[3]].transform.position;
        carCoord = vehicleSpots[spots[4]].transform.position;
        cementTruckCoord = vehicleSpots[spots[5]].transform.position;
        car2Coord = vehicleSpots[spots[6]].transform.position;
        car3Coord = vehicleSpots[spots[7]].transform.position;
        excavatorCoord = vehicleSpots[spots[8]].transform.position;
        policeCoord = vehicleSpots[spots[9]].transform.position;
        tractorCoord = vehicleSpots[spots[10]].transform.position;
        tractor2Coord = vehicleSpots[spots[11]].transform.position;
        firetruckCoord = vehicleSpots[spots[12]].transform.position;

        for (int i = 0; i < spots.Length; i++)
        {
            spots[i] = i;
        }
        spots = shuffle(spots);

        garbageTruckPlaceCoord = placeSpots[spots[1]].transform.position;
        medicinePlaceCoord = placeSpots[spots[2]].transform.position;
        schoolBusPlaceCoord = placeSpots[spots[3]].transform.position;
        carPlaceCoord = placeSpots[spots[4]].transform.position;
        cementTruckPlaceCoord = placeSpots[spots[5]].transform.position;
        car2PlaceCoord = placeSpots[spots[6]].transform.position;
        car3PlaceCoord = placeSpots[spots[7]].transform.position;
        excavatorPlaceCoord = placeSpots[spots[8]].transform.position;
        policePlaceCoord = placeSpots[spots[9]].transform.position;
        tractorPlaceCoord = placeSpots[spots[10]].transform.position;
        tractor2PlaceCoord = placeSpots[spots[11]].transform.position;
        firetruckPlaceCoord = placeSpots[spots[12]].transform.position;

        garbageTruck.transform.position = garbageTruckCoord;
        medicine.transform.position = medicineCoord;
        schoolBus.transform.position = schoolBusCoord;
        car.transform.position = carCoord;
        cementTruck.transform.position = cementTruckCoord;
        car2.transform.position = car2Coord;
        car3.transform.position = car3Coord;
        excavator.transform.position = excavatorCoord;
        police.transform.position = policeCoord;
        tractor.transform.position = tractorCoord;
        tractor2.transform.position = tractor2Coord;
        firetruck.transform.position = firetruckCoord;

        garbageTruckPlace.transform.position = garbageTruckPlaceCoord;
        medicinePlace.transform.position = medicinePlaceCoord;
        schoolBusPlace.transform.position = schoolBusPlaceCoord;
        carPlace.transform.position = carPlaceCoord;
        cementTruckPlace.transform.position = cementTruckPlaceCoord;
        car2Place.transform.position = car2PlaceCoord;
        car3Place.transform.position = car3PlaceCoord;
        excavatorPlace.transform.position = excavatorPlaceCoord;
        policePlace.transform.position = policePlaceCoord;
        tractorPlace.transform.position = tractorPlaceCoord;
        tractor2Place.transform.position = tractor2PlaceCoord;
        firetruckPlace.transform.position = firetruckPlaceCoord;
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
