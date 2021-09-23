using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceCard : Card
{

    public override void RevealItem()
    {
        base.RevealItem();
        Player.instance.Chances += 2;
    }

}
