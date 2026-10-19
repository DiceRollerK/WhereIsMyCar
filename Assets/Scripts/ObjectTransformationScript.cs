using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectTransformationScript : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float scaleSpeed = 0.5f;
    private bool rotateCW, rotateCCW, scaleUpY, scaleDownY, scaleUpX, scaleDownX, flip;
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

        if (flip)
        {
            rc.localScale = new Vector3(rc.localScale.x * -1, rc.localScale.y, 1f);
            flip = false;
        }

        isTransforming = rotateCW || rotateCCW || scaleUpY || scaleDownY || scaleUpX || scaleDownX || flip;
    }

    public void StartRotateCW() { rotateCW = true; }
    public void StopRotateCW() { rotateCW = false; }
    public void StartRotateCCW() { rotateCCW = true; }
    public void StopRotateCCW() { rotateCCW = false; }
    public void StartScaleUpY() { scaleUpY = true; }
    public void StopScaleUpY() { scaleUpY = false; }
    public void StartScaleDownY() { scaleDownY = true; }
    public void StopScaleDownY() { scaleDownY = false; }
    public void StartScaleUpX() { scaleUpX = true; }
    public void StopScaleUpX() { scaleUpX = false; }
    public void StartScaleDownX() { scaleDownX = true; }
    public void StopScaleDownX() { scaleDownX = false; }
    public void StartFlip() { flip = true; }
}
