[System.Serializable]
public class items
{
    public int id;
    public string title;
    public string desc;
    public int price;

    public items() { }
    public items(int id, string title, string desc, int price)
    {
        this.id = id;
        this.title = title;
        this.desc = desc;
        this.price = price;
    }
}

[System.Serializable]
public class MyItem
{
    public items[] items;
}
