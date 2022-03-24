[System.Serializable]
public class items
{
    public int id;
    public string icon;
    public string title;
    public string desc;
    public int price;
}

[System.Serializable]
public class MyItem
{
    public items[] items;
}
