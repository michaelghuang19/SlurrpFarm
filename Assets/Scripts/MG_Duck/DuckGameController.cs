using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckGameController : MonoBehaviour
{
    [SerializeField]
    private Sprite item;
    [SerializeField]
    private GameObject character;

    private GameObject[] items;

    private int gameReps;

    public int score = 0;
    public int itemsLeft = 15;
    private bool gameOver = false;

    void Awake()
    {
        //Load items into possibleItems
        items = Resources.LoadAll<GameObject> ("Dodge");

    }

    void Start() 
    {
        //Start createObjects(), which loops, and runs for x amount of times (based on difficulty later)
        CreateObjects();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if there has been a collision between the item and the character. 
        //Check which type of item it is
            //If it is a cookie, add 1 to the score
            //If it is coal, subtract 2 from the score
        //Update the score counters
    }


    private IEnumerator CreateObjects() {
        
        while (!gameOver) {
            if (itemsLeft == 0) {
                gameOver = true;
            }
            yield return new WaitForSeconds(3f);
            itemsLeft--;

        }
        //Create a new object every 3 seconds, randomly selected from possibleItems;
        //Set Object location to the right side of the screen
        //Set Object movement so taht the object moves left

    }


}
