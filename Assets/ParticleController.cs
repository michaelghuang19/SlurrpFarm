using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem levelParticles;
    void Start()
    {
        if (PlayerPrefs.GetInt("LevelChanged") == 1) {
            levelParticles.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
