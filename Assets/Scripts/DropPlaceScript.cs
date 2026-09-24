using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlaceScript : MonoBehaviour, IDropHandler
{
    private float placeZRot, carZRot, diffZRot;
    private Vector3 placeSize, carSize;
    private float xSizeDiff, ySizeDiff;
    public GameObjectsScript gameObjectsScript;

    // Start is called once before the first execution of Update after the MonoBehav
    // our is created
    void Start()
    {
        gameObjectsScript = Object.FindFirstObjectByType<GameObjectsScript>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if((eventData.pointerDrag != null) && Input.GetMouseButtonUp(0) && (!Input.GetMouseButton(2)))
        {
            if(eventData.pointerDrag.tag.Equals(tag))
            {
                placeZRot = eventData.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;
                carZRot = GetComponent<RectTransform>().transform.eulerAngles.z;
                diffZRot = Mathf.Abs(placeZRot - carZRot);
                Debug.Log("Diff Z Rot: " + diffZRot);

                placeSize = eventData.pointerDrag.GetComponent<RectTransform>().localScale;
                carSize = GetComponent<RectTransform>().localScale;
                xSizeDiff = Mathf.Abs(placeSize.x - carSize.x);
                ySizeDiff = Mathf.Abs(placeSize.y - carSize.y);
                Debug.Log("Diff X Size: " + xSizeDiff);
                Debug.Log("Diff Y Size: " + ySizeDiff);

                if((diffZRot <= 7 || (diffZRot >= 353 && diffZRot <= 360)) && (xSizeDiff <= 0.08f && ySizeDiff <= 0.08f))
                {
                    Debug.Log("Car placed correctly!");
                    gameObjectsScript.inRightPlace = true;
                    gameObjectsScript.placed++;
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                    eventData.pointerDrag.GetComponent<RectTransform>().localScale = GetComponent<RectTransform>().localScale;

                    eventData.pointerDrag.GetComponent<RectTransform>().localRotation = GetComponent<RectTransform>().localRotation;

                    switch(eventData.pointerDrag.tag)
                    {
                        case "Garbage":
                            gameObjectsScript.carSoundSource.PlayOneShot(gameObjectsScript.sounds[1]);
                            break;

                        case "Ambulance":
                            gameObjectsScript.carSoundSource.PlayOneShot(gameObjectsScript.sounds[2]);
                            break;

                        case "School":
                            gameObjectsScript.carSoundSource.PlayOneShot(gameObjectsScript.sounds[3]);
                            break;
                        case "Car":
                            gameObjectsScript.carSoundSource.PlayOneShot(gameObjectsScript.sounds[4]);
                            break;
                        case "CementTruck":
                            gameObjectsScript.carSoundSource.PlayOneShot(gameObjectsScript.sounds[5]);
                            break;
                        case "Car2":
                            gameObjectsScript.carSoundSource.PlayOneShot(gameObjectsScript.sounds[6]);
                            break;
                        case "Car3":
                            gameObjectsScript.carSoundSource.PlayOneShot(gameObjectsScript.sounds[7]);
                            break;
                        case "Excavator":
                            gameObjectsScript.carSoundSource.PlayOneShot(gameObjectsScript.sounds[8]);
                            break;
                        case "Police":
                            gameObjectsScript.carSoundSource.PlayOneShot(gameObjectsScript.sounds[9]);
                            break;
                        case "Tractor":
                            gameObjectsScript.carSoundSource.PlayOneShot(gameObjectsScript.sounds[10]);
                            break;
                        case "Tractor2":
                            gameObjectsScript.carSoundSource.PlayOneShot(gameObjectsScript.sounds[11]);
                            break;
                        case "Firetruck":
                            gameObjectsScript.carSoundSource.PlayOneShot(gameObjectsScript.sounds[12]);
                            break;
                        default:
                            Debug.Log("No matching tag found for the dropped object: " + eventData.pointerDrag.tag);
                            break;
                    }
                }
            } else
            {
                gameObjectsScript.inRightPlace = false;
                gameObjectsScript.carSoundSource.PlayOneShot(gameObjectsScript.sounds[13]);

                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                eventData.pointerDrag.GetComponent<RectTransform>().localScale = GetComponent<RectTransform>().localScale;

                eventData.pointerDrag.GetComponent<RectTransform>().localRotation = GetComponent<RectTransform>().localRotation;

                switch (eventData.pointerDrag.tag)
                {
                    case "Garbage":
                        gameObjectsScript.garbageTruck.GetComponent<RectTransform>().localPosition = gameObjectsScript.garbageTruckCoord;
                        break;

                    case "Ambulance":
                        gameObjectsScript.medicine.GetComponent<RectTransform>().localPosition = gameObjectsScript.medicineCoord;
                        break;

                    case "School":
                        gameObjectsScript.schoolBus.GetComponent<RectTransform>().localPosition = gameObjectsScript.schoolBusCoord;
                        break;
                    case "Car":
                        gameObjectsScript.car.GetComponent<RectTransform>().localPosition = gameObjectsScript.carCoord;
                        break;
                    case "CementTruck":
                        gameObjectsScript.cementTruck.GetComponent<RectTransform>().localPosition = gameObjectsScript.cementTruckCoord;
                        break;
                    case "Car2":
                        gameObjectsScript.car2.GetComponent<RectTransform>().localPosition = gameObjectsScript.car2Coord;
                        break;
                    case "Car3":
                        gameObjectsScript.car3.GetComponent<RectTransform>().localPosition = gameObjectsScript.car3Coord;
                        break;
                    case "Excavator":
                        gameObjectsScript.excavator.GetComponent<RectTransform>().localPosition = gameObjectsScript.excavatorCoord;
                        break;
                    case "Police":
                        gameObjectsScript.police.GetComponent<RectTransform>().localPosition = gameObjectsScript.policeCoord;
                        break;
                    case "Tractor":
                        gameObjectsScript.tractor.GetComponent<RectTransform>().localPosition = gameObjectsScript.tractorCoord;
                        break;
                    case "Tractor2":
                        gameObjectsScript.tractor2.GetComponent<RectTransform>().localPosition = gameObjectsScript.tractor2Coord;
                        break;
                    case "Firetruck":
                        gameObjectsScript.firetruck.GetComponent<RectTransform>().localPosition = gameObjectsScript.firetruckCoord;
                        break;
                    default:
                        Debug.Log("No matching tag found for the dropped object: " + eventData.pointerDrag.tag);
                        break;
                }
            }

        }
    }
}
