using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectTransformationScript : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float scaleSpeed = 0.5f;
    private bool rotateCW, rotateCCW, scaleUpY, scaleDownY, scaleUpX, scaleDownX;
    public static bool isTransforming = false;


    void Update()
    {
        if (GameObjectsScript.lastDragged == null)
        {
            return;
        }

        RectTransform rc = GameObjectsScript.lastDragged.GetComponent<RectTransform>();

        if (rotateCW)
        {
            rc.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }

        if (rotateCCW)
        {
            rc.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        if (scaleUpY && rc.localScale.y < 0.9f)
        {
            rc.localScale += new Vector3(0, scaleSpeed * Time.deltaTime, 0);
        }

        if (scaleDownY && rc.localScale.y > 0.3f)
        {
            rc.localScale -= new Vector3(0, scaleSpeed * Time.deltaTime, 0);
        }

        if (scaleUpX && rc.localScale.x < 0.9f)
        {
            rc.localScale += new Vector3(scaleSpeed * Time.deltaTime, 0, 0);
        }

        if (scaleDownX && rc.localScale.x > 0.3f)
        {
            rc.localScale -= new Vector3(scaleSpeed * Time.deltaTime, 0, 0);
        }

        isTransforming = rotateCW || rotateCCW || scaleUpY || scaleDownY || scaleUpX || scaleDownX;
    }

    // Update is called once per frame
    /*
    void Update()
    {

        if(GameObjectsScript.lastDragged != null)
        {
            if(Input.GetKey(KeyCode.Z))
            {
                GameObjectsScript.lastDragged.GetComponent<RectTransform>().Rotate(0, 0, Time.deltaTime * 20);
            }

            if (Input.GetKey(KeyCode.X))
            {
                GameObjectsScript.lastDragged.GetComponent<RectTransform>().Rotate(0, 0, -Time.deltaTime * 20);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.y < 0.9f)
                {
                    GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale = new Vector3(GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x, GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.y + 0.002f, 1f);
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.y > 0.3f)
                {
                    GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale = new Vector3(GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x, GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.y - 0.002f, 1f);
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x > 0.3f && GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x > 0)
                {
                    GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale = new Vector3(GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x - 0.002f, GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.y, 1f);
                } else if (GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x < -0.3f && GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x < 0)
                {
                    GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale = new Vector3(GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x + 0.002f, GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.y, 1f);
                }
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x < 0.9f && GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x > 0f)
                {
                    GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale = new Vector3(GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x + 0.002f, GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.y, 1f);
                } else if (GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x > -0.9f && GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x < 0f)
                {
                    GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale = new Vector3(GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x - 0.002f, GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.y, 1f);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale = new Vector3(GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.x * -1, GameObjectsScript.lastDragged.GetComponent<RectTransform>().localScale.y, 1f);
            }
        }
    }
    */

    public void StartRotateCW(BaseEventData eventData) { rotateCW = true; }

    public void StopRotateCW(BaseEventData eventData) { rotateCW = false; }

    public void StartRotateCCW(BaseEventData eventData) { rotateCCW = true; }
    public void StopRotateCCW(BaseEventData eventData) { rotateCCW = false; }
    public void StartScaleUpY(BaseEventData eventData) { scaleUpY = true; }
    public void StopScaleUpY(BaseEventData eventData) { scaleUpY = false; }
    public void StartScaleDownY(BaseEventData eventData) { scaleDownY = true; }
    public void StopScaleDownY(BaseEventData eventData) { scaleDownY = false; }
    public void StartScaleUpX(BaseEventData eventData) { scaleUpX = true; }
    public void StopScaleUpX(BaseEventData eventData) { scaleUpX = false; }
    public void StartScaleDownX(BaseEventData eventData) { scaleDownX = true; }
    public void StopScaleDownX(BaseEventData eventData) { scaleDownX = false; }
}
