using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SpriteController : MonoBehaviour
{
    private GameObject[] sprites;
    private GameObject current;
    private int index = 0;

    public Text name;

    // Start is called before the first frame update
    void Start()
    {
        sprites = Resources.LoadAll<GameObject>("CharacterSelect/Characters/GameObjects");

        CreateSprite();
    }

    void CreateSprite()
    {
        // TODO: Check this out
        current = Instantiate(sprites[2]) as GameObject;
        current.transform.position = new Vector2(0, 0);
    }

    public void SaveName()
    {
        Debug.Log(name.text);

        string nameString = name.text;

        PlayerPrefs.SetString("Name", nameString);

        Debug.Log("Saved name is " + PlayerPrefs.GetString("Name"));
    }

    public void MoveLeft()
    {
        if (index != 0)
        {
            index--;
            Destroy(current);

            CreateSprite();
        }
    }

    public void MoveRight()
    {
        if (index != sprites.Length - 1)
        {
            index++;
            Destroy(current);

            CreateSprite();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(name.text);
    }
}
