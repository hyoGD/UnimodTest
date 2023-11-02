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
        InitData();

        SpwanItem();

        CreateFpsDisplyObj();
    }

    private void InitData()
    {
        string texPath = "ShopItems"; // tim kiem duong dan den sprite
        spItem = Resources.LoadAll(texPath, typeof(Sprite));

        for (int i = 0; i < _totalCount; i++)
        {
            items dataItem = new items(myItem.item.items[i].id, myItem.item.items[i].title, myItem.item.items[i].desc, myItem.item.items[i].price);
            mItems.Add(dataItem);

        }
    }

    private void SpwanItem()
    {
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
    private void CreateFpsDisplyObj()
    {
        FPSDisplay fpsObj = FindObjectOfType<FPSDisplay>();
        if (fpsObj != null)
        {
            return;
        }
        GameObject go = new GameObject();
        go.name = "FPSDisplay";
        go.AddComponent<FPSDisplay>();
        DontDestroyOnLoad(go);
    }
}
