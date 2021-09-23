using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private AudioSource audioSource;
    
    [Header("Canvas")]
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject gameOverMenu;

    [Header("Cards Container")]
    [SerializeField] private Transform cardsContainer;

    [Header("Cards")]
    [SerializeField] private MoneyCard moneyCard;
    [SerializeField] private HealthCard healthCard;
    [SerializeField] private ChanceCard chanceCard;

    [Header("Card Values")]
    [SerializeField] private float[] moneyCardsValues;
    [SerializeField] private bool[] healthCardsValues;
    [SerializeField] private int numOfChanceCards;

    [Header("Reward Text Field")]
    [SerializeField] private Text rewardText;

    [Header("Audio Clip")]
    [SerializeField] private AudioClip gameOverClip;

    private void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {
        if (!startMenu || !ui || !gameOverMenu || !moneyCard || !healthCard || !chanceCard || !rewardText || !gameOverClip)
        {
            Debug.LogError("No required GameObject assigned");
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #region Game Flow
    public void StartGame()
    {
        startMenu.SetActive(false);
        ui.SetActive(true);
        
        GenerateCards();
        RandomShuffle();
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        rewardText.text = Player.instance.Money.ToString();

        audioSource.clip = gameOverClip;
        audioSource.Play();
    }

    public void TryAgain()
    {
        gameOverMenu.SetActive(false);

        Player.instance.ResetPlayer();
        DestroyCards();
        StartGame();
    }
    #endregion

    #region Cards
    private void GenerateCards()
    {
        GenerateMoneyCards();
        GenerateHealthCards();
        GenerateChanceCards();
    }

    private void GenerateMoneyCards()
    {
        for (int i = 0; i < moneyCardsValues.Length; i++)
        {
            MoneyCard currentMoneyCard = Instantiate(moneyCard, cardsContainer);
            currentMoneyCard.SetMoney(moneyCardsValues[i]);
        }
    }

    private void GenerateHealthCards()
    {
        for (int i = 0; i < healthCardsValues.Length; i++)
        {
            HealthCard currentHealthCard = Instantiate(healthCard, cardsContainer);
            currentHealthCard.IsBomb = healthCardsValues[i];
        }
    }

    private void GenerateChanceCards()
    {
        for (int i = 0; i < numOfChanceCards; i++)
        {
            Instantiate(chanceCard, cardsContainer);
        }
    }
    
    public void RandomShuffle()
    {
        for (int i = 0; i < cardsContainer.childCount; i++)
        {
            cardsContainer.GetChild(i).SetSiblingIndex(Random.Range(0, cardsContainer.childCount));
        }
    }

    private void DestroyCards()
    {
        foreach (Transform card in cardsContainer)
        {
            Destroy(card.gameObject);
        }
    }
    #endregion
}
