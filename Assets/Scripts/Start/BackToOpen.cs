using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToOpen : MonoBehaviour
{
    [SerializeField]
    Canvas UICanvas;
    [SerializeField]
    Canvas DiscountCanvas;
    // Start is called before the first frame update

    public void GoBack() 
    {
        UICanvas.gameObject.SetActive(true);
        DiscountCanvas.gameObject.SetActive(false);
    }
}
