using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    private Sprite[] sprites;
    private Sprite current;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("CharacterSelect/Characters");

        CreateSprite();
    }

    void CreateSprite()
    {
        current = Sprite.Create(sprites[index]);
        current.transform.position = new Vector2(250, 0);
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
        
    }
}
