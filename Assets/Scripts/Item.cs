using UnityEngine;

public class Item : MonoBehaviour
{
    public TextAsset ShopItem;

    public MyItem item = new MyItem();

    private void Awake()
    {
        item = JsonUtility.FromJson<MyItem>(ShopItem.text);
    }
}
