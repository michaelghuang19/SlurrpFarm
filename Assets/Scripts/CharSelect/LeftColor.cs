using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeItemLeft()
    {
        Debug.Log("Left works");
        GameObject.Find("SpriteController").GetComponent<SpriteController>().MoveLeft();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
