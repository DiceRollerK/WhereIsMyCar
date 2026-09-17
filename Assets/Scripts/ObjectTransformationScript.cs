using UnityEngine;

public class ObjectTransformationScript : MonoBehaviour
{
    public GameObjectsScript gameObjectsScript;

    private void Awake()
    {
        gameObjectsScript = FindFirstObjectByType<GameObjectsScript>();
    }

    // Update is called once per frame
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
}
