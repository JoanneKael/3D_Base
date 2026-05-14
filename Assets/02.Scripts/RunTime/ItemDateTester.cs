using UnityEngine;

public class ItemDateTester : MonoBehaviour
{
    [SerializeField] private ItemData itemData;

    private void Start()
    {
        if(itemData == null)
        {
            Debug.LogWarning("ItemData 연결 문제");
            return;
        }

        Debug.Log($"Item ID : {itemData.itemId}");
        Debug.Log($"Item Name : {itemData.itemType}");
        Debug.Log($"Item Type : {itemData.itemType}");
        Debug.Log($"Item Buy Price : {itemData.buyPrice}");
        Debug.Log($"Item Sell Price : {itemData.sellPrice}");
        Debug.Log($"Item Stackable : {itemData.canStack}");
    }
}
