using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Item1[] _items;

    public void Init(List<items> data, List<Sprite> sprites)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            _items[i].Init(data[i], sprites[i]);
        }
    }
}
