using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static Player instance;

    [Header("Original Value")]
    [SerializeField] private float orignalMoney;
    [SerializeField] private float originalHealth;
    [SerializeField] private float orignalChances;

    private float money;
    private float health;
    private float chances;

    [Header("UI Text Field")]
    [SerializeField] private Text moneyText;
    [SerializeField] private Text healthText;
    [SerializeField] private Text chancesText;

    private void Awake()
    {
        MakeInstance();
    }

    // Start is called before the first frame update
    private void Start()
    {
        ResetPlayer();
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ResetPlayer()
    {
        Money = orignalMoney;
        Health = originalHealth;
        Chances = orignalChances;
    }

    #region Properties
    public float Money
    {
        get { return money; }
        set { 
            money = value;

            if (moneyText)
            {
                moneyText.text = money.ToString();
            }
        }
    }

    public float Health
    {
        get { return health; }
        set { 
            health = value;

            if (healthText)
            {
                healthText.text = health.ToString();
            }
        }
    }

    public float Chances
    {
        get { return chances; }
        set { 
            chances = value;

            if (chancesText)
            {
                chancesText.text = chances.ToString();
            }
        }
    }
    #endregion

}
