using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText; // Reference to the UI Text component
    public int money = 0; // Current money value

    void Start()
    {
        UpdateMoneyUI();
    }

    // Method to add money
    public void AddMoney(int amount)
    {
        money += amount;
        AnimateMoneyChange(amount);  // Trigger animation on money change
    }

    public void ReduceMoney(int amount)
    {
        money -= amount;
        AnimateMoneyChange(-amount); // Trigger animation on money change
    }

    // Method to update the UI Text with the current money value
    public void UpdateMoneyUI()
    {
        moneyText.text = FormatMoney(money);
    }

    // Helper method to format large numbers
    string FormatMoney(int amount)
    {
        if (amount >= 1000000)
            return (amount / 1000000.0).ToString("0.#M");
        else if (amount >= 1000)
            return (amount / 1000.0).ToString("0.#K");
        else
            return amount.ToString();
    }

    // Animation effect for money changes
    void AnimateMoneyChange(int changeAmount)
    {
        if (changeAmount != 0)
        {
            float duration = 0.5f; // Duration of the animation
            moneyText.transform.DOScale(1.2f, duration / 2).OnComplete(() =>
            {
                moneyText.transform.DOScale(1f, duration / 2);
            });

            // Optional: Color animation to highlight addition or reduction
            if (changeAmount > 0)
                moneyText.DOColor(Color.green, duration / 2).OnComplete(() =>
                    moneyText.DOColor(Color.black, duration / 2));
            else
                moneyText.DOColor(Color.red, duration / 2).OnComplete(() =>
                    moneyText.DOColor(Color.black, duration / 2));
        }
    }
}
