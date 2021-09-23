using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCard : Card
{

    public override void RevealItem()
    {
        base.RevealItem();
        Player.instance.Money = Mathf.Max(Player.instance.Money + float.Parse(item.GetComponent<TextMeshPro>().text), 0f);
    }

    public void SetMoney(float money)
    {
        item.GetComponent<TextMeshPro>().text = money.ToString();
    }

}
