using UnityEngine;

public class Items : MonoBehaviour
{
    public Item1[] _items;

    public void Init()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            _items[i].Init();
        }
    }
}
