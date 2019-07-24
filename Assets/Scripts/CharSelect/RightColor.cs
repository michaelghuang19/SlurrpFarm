using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeItemRight()
    {
        Debug.Log("Right works");
        GameObject.Find("SpriteController").GetComponent<SpriteController>().MoveRight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
