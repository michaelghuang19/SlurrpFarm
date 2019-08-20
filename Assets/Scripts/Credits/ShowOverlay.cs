using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOverlay : MonoBehaviour
{
    public Canvas overlayCanvas;
    public Canvas creditCanvas;
    // Start is called before the first frame update
    void Start()
    {
        creditCanvas.gameObject.SetActive(true);
        overlayCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showAssetsOver() {
        creditCanvas.gameObject.SetActive(false);
        overlayCanvas.gameObject.SetActive(true);
    }
    public void hideAssetsOver() {
        overlayCanvas.gameObject.SetActive(false);
        creditCanvas.gameObject.SetActive(true);
    }
}
