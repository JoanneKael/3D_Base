using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("HP")]
    public int maxHP = 100;
    public int currentHP = 0;

    [Header("MP")]
    public int maxMP = 50;
    public int currentMP = 0;

    [Header("Combat")]
    public int attack = 10;
    public int defense = 5;

    [Header("Currency")]
    public int gold = 0;

    public void HealHP(int amount)
    {
        currentHP = Mathf.Min(currentHP+amount,maxHP);
        Debug.Log($"[HP] {amount} -> HP : {currentHP} / {maxHP}");
    }

    public void HealMP(int amount)
    {
        currentMP = Mathf.Min(currentMP + amount, maxMP);
        Debug.Log($"[MP] {amount} -> MP : {currentMP} / {maxMP}");
    }

    public void IncreaseAttack(int amount)
    {
        attack += amount;
        Debug.Log($"[Attak] {amount} -> Attack : {attack}");
    }

    public void IncreaseDefense(int amount)
    {
        defense += amount;
        Debug.Log($"[Defense] {amount} -> Defense : {defense}");
    }

    public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log($"[Gold] {amount} -> Gold : {gold}");
    }
}
