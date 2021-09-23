using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCard : Card
{

    private bool isBomb;

    [Header("Sprites")]
    [SerializeField] Sprite bomb;
    [SerializeField] Sprite heart;

    public override void RevealItem()
    {
        base.RevealItem();

        if (isBomb)
        {
            Player.instance.Health -= 1;
            item.GetComponent<SpriteRenderer>().sprite = bomb;
        } else
        {
            Player.instance.Health += 1;
            item.GetComponent<SpriteRenderer>().sprite = heart;
        }
    }

    public bool IsBomb
    {
        get { return isBomb; }
        set { isBomb = value; }
    }

}
