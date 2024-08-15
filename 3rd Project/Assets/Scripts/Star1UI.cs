using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star1UI : MonoBehaviour
{
    public Image[] Sprite;
    public Sprite ChangeSprite;

    private void Update()
    {
        if(End.count >= 1)
        {
            Sprite[0].sprite = ChangeSprite;
            if(End.count >= 2)
            {
                Sprite[1].sprite = ChangeSprite;
                if (End.count >= 3)
                {
                    Sprite[2].sprite = ChangeSprite;
                    if (End.count >= 4)
                    {
                        Sprite[3].sprite = ChangeSprite;
                    }
                }
            }
        }
    }
}
