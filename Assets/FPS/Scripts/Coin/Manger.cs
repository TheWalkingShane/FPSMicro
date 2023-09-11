using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public Text coinCounterText;
    private int coinCount;

    private void Awake()
    {
        // Implement a singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin(int value)
    {
        coinCount += value;
        UpdateCoinCounter();
    }

    private void UpdateCoinCounter()
    {
        coinCounterText.text = "Coins: " + coinCount;
    }
}