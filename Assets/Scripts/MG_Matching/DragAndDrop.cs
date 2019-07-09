using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour
{
    private bool draggingItem = false;
    public bool matching = false;
    private GameObject draggedObject;
    private Vector2 touchOffset;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Minigame_Matching")
        {
            matching = true;
            GetComponent<DropZone>();
        }
    }

    void Update()
    {
        if (matching) {
            if (HasInput)
            {
                DragOrPickUp();
            }
            else
            {
                if (draggingItem)
                    DropItem();
            }
        }
    }

    Vector2 CurrentTouchPosition
    {
        get
        {
            Vector2 inputPos;
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return inputPos;
        }
    }

    private void DragOrPickUp()
    {
        if (matching)
        {
            var inputPosition = CurrentTouchPosition;

            if (draggingItem)
            {
                draggedObject.transform.position = inputPosition + touchOffset;
            }
            else
            {
                RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
                if (touches.Length > 0)
                {
                    var hit = touches[0];
                    if (hit.transform != null)
                    {
                        draggingItem = true;
                        draggedObject = hit.transform.gameObject;
                        touchOffset = (Vector2)hit.transform.position - inputPosition;
                        draggedObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    }
                }
            }
        }
    }

    private bool HasInput
    {
        get
        {
            // returns true if either the mouse button is down or at least one touch is felt on the screen
            if (matching)
            {
                return Input.GetMouseButton(0);
            }
            return false;
        }
    }

    void DropItem()
    {
        if (matching)
        {
            draggingItem = false;
            draggedObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            // Debug.Log("DropItem " + draggedObject.name);
            // Debug.Log("Debug on " + gameObject.name, gameObject);

            // check if this is the matching game
            if (matching)
            {
                GetComponent<DropZone>().CheckDrop(draggedObject);
            }

            // no tag atm, could eventually be useful
            // Debug.Log("DropItem " + draggedObject.tag);
        }
    }

}