using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManangerItem : MonoBehaviour
{
    public Item myItem;
    public GameObject ShelfPrefab;
    public GameObject shelfParent;
    public GameObject ShowDetail;
    public List<Text> title;
    public List<Text> price;
    public List<Image> imageItemList;
    public Object[] spItem;
    public List<Button> itemBtn;

    public Text nameItem;
    public Text Profile;
    public Image imageItem;

    private GameObject newShelf;
    private int number = 333;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < number; i++)
        {
            newShelf = Instantiate(ShelfPrefab, shelfParent.transform);

            int number = newShelf.transform.childCount;
            for (int j = 0; j < number; j++)
            {
                price.Add(newShelf.transform.GetChild(j).transform.GetChild(2).GetComponent<Text>());   // tìm đến vị trí của giá tiền của item và add vào list price
                title.Add(newShelf.transform.GetChild(j).transform.GetChild(1).GetComponent<Text>());   // tìm đến vị trí của tên item  và add vào list title
                imageItemList.Add(newShelf.transform.GetChild(j).transform.GetChild(0).GetComponent<Image>());  //tìm đến vị trí của image item và add vào list imageItemList
                itemBtn.Add(newShelf.transform.GetChild(j).GetComponent<Button>());                     //add tất cả button con của gameObjec trong prefab vào list itemBtn
            }
        }

        HandlingJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandlingJson()
    {
        for (int i = 0; i < itemBtn.Count; i++) // add Onclick vao button
        {
            int levelItem = i;
            itemBtn[i].onClick.AddListener(() => ShowItem(levelItem));
        }

        string texPath = "ShopItems"; // tim kiem duong dan den sprite
        spItem = Resources.LoadAll(texPath, typeof(Sprite));


        for (int i = 0; i < spItem.Length; i++)     //show item
        {
            price[i].text = myItem.item.items[i].price.ToString();
            title[i].text = myItem.item.items[i].title;
            imageItemList[i].sprite =(Sprite) spItem[i];
        }
    }


    public void ShowItem(int n)
    {
        ShowDetail.SetActive(true);
        imageItem.sprite =(Sprite) spItem[n];
        nameItem.text = myItem.item.items[n].title;
        Profile.text = myItem.item.items[n].desc;
    }
}
