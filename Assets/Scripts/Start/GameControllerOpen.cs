using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerOpen : MonoBehaviour
{
    [SerializeField]
    Canvas UICanvas;
    [SerializeField]
    Canvas DiscountCanvas;

    // Start is called before the first frame update
    void Start()
    {
        bool levelledUp = Convert.ToBoolean(PlayerPrefs.GetInt("LevelChanged"));
        if (levelledUp) {
            UICanvas.gameObject.SetActive(false);
            DiscountCanvas.gameObject.SetActive(true);
        } else {
            UICanvas.gameObject.SetActive(true);
            DiscountCanvas.gameObject.SetActive(false);
        }
    }

}
