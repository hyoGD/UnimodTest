using SuperScrollView;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManangerItem : MonoBehaviour
{
    public static ManangerItem Instance;
    public Item myItem;
    public Items ShelfPrefab;
    public GameObject shelfParent;
    public LoopListView2 mLoopListView;
    public Object[] spItem;
    List<items> mItems = new List<items>();
    [Space(10)]
    [Header("Popup Infor Item")]
    public GameObject ShowDetail;
    public Text nameItem;
    public Text Profile;
    public Image imageItem;
    const int mItemCountPerRow = 3;
    private int _totalCount => myItem.item.items.Length;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        string texPath = "ShopItems"; // tim kiem duong dan den sprite
        spItem = Resources.LoadAll(texPath, typeof(Sprite));

        // int tmp = 0;
        for (int i = 0; i < _totalCount; i++)
        {
            //  Items item = Instantiate(ShelfPrefab, shelfParent.transform);
            //List<items> datas = new List<items>();
            //List<Sprite> sprites = new List<Sprite>();
            //for (int j = tmp; j < tmp + 3; j++)
            //{
            // Debug.Log(tmp);
            items dataItem = new items(myItem.item.items[i].id, myItem.item.items[i].title, myItem.item.items[i].desc, myItem.item.items[i].price);
            mItems.Add(dataItem);
            //datas.Add(dataItem);
            //sprites.Add((Sprite)spItem[j]);
            // }
            //  item.Init(datas, sprites);
            //foreach (var n in item._items)
            //{
            //    n.GetButton().onClick.AddListener(() =>
            //    {
            //        ShowItem(n);
            //    });
            //}
            //tmp += 3;
        }


        int count = _totalCount / mItemCountPerRow;
        if (_totalCount % mItemCountPerRow > 0)
        {
            count++;
        }
        mLoopListView.InitListView(count, OnGetItemByIndex);
    }

    public void ShowItem(Item1 item)
    {
        ShowDetail.SetActive(true);
        imageItem.sprite = item.GetAvar();
        nameItem.text = item.Data.title;
        Profile.text = item.Data.desc;
    }

    LoopListViewItem2 OnGetItemByIndex(LoopListView2 listView, int index)
    {
        if (index < 0)
        {
            return null;
        }
        LoopListViewItem2 item = listView.NewListViewItem("Items");
        Items itemScript = item.GetComponent<Items>();
        if (item.IsInitHandlerCalled == false)
        {
            item.IsInitHandlerCalled = true;
            itemScript.Init();
        }
        for (int i = 0; i < mItemCountPerRow; ++i)
        {
            int itemIndex = index * mItemCountPerRow + i;
            if (itemIndex >= _totalCount)
            {
                itemScript._items[i].gameObject.SetActive(false);
                continue;
            }
            items itemData = mItems[itemIndex];
            if (itemData != null)
            {
                itemScript._items[i].gameObject.SetActive(true);
                itemScript._items[i].SetItem(itemData, (Sprite)spItem[itemIndex]);
            }
            else
            {
                itemScript._items[i].gameObject.SetActive(false);
            }
        }
        return item;
    }
}
