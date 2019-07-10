using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToOpen : MonoBehaviour
{
    private ParticleSystem levelParticles;

    [SerializeField]
    Canvas UICanvas;
    [SerializeField]
    Canvas DiscountCanvas;

    void Start()
    {

    }

    public void GoBack() 
    {
        UICanvas.gameObject.SetActive(true);
        DiscountCanvas.gameObject.SetActive(false);
    }

    public void levelParticles()
    {

    }
}
