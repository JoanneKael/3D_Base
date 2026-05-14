using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemUseTester : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerSatus;
    [SerializeField] private ItemData itemToUse;
    [SerializeField] private InputAction useItemAction = new InputAction("UseItem", InputActionType.Button, "<Keyboard>/u");

    private void OnEnable()
    {
        useItemAction.performed += OnUseItemPerformed;
        useItemAction.Enable();
    }

    private void OnDisable()
    {
        useItemAction.performed -= OnUseItemPerformed;
        useItemAction.Disable();
    }

    private void OnUseItemPerformed(InputAction.CallbackContext context)
    {
        useItem(itemToUse);
    }

    private void useItem(ItemData itemData)
    {
        if(itemData == null)
        {
            Debug.LogWarning("No Item Data to Use");
            return;
        }

        if (!itemData.canUse)
        {
            Debug.LogWarning("Can Not Use");
            return;
        }

        foreach (ItemEffect effect in itemData.effects)
        {
            ApplyEffect(effect);
        }
    }

    private void ApplyEffect(ItemEffect effect)
    {
        switch (effect.effectType)
        {
            case ItemEffectType.HealHp: playerSatus.HealHP(10);
                break;
            case ItemEffectType.HealMp:playerSatus.HealMP(10);
                break;
            case ItemEffectType.IncreaseAttack: playerSatus.IncreaseAttack(100);
                break;
            case ItemEffectType.IncreaseDefense:playerSatus.IncreaseDefense(50);
                break;
            case ItemEffectType.AddGold:playerSatus.AddGold(100);
                break;
        }
    }
}
