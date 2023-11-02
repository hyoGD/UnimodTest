using SuperScrollView;
using UnityEngine;
using UnityEngine.UI;

public class Item1 : MonoBehaviour
{
    public items Data;
    [SerializeField] Text _nameTxt;
    [SerializeField] Text _priceTxt;
    [SerializeField] Image _avarImg;

    public Sprite GetAvar()
    {
        return _avarImg.sprite;
    }

    public void Init()
    {
        ClickEventListener listener = ClickEventListener.Get(this.gameObject);
        listener.SetClickEventHandler(ShowItem);
    }

    public void SetItem(items data, Sprite avar)
    {
        this.Data = data;
        _nameTxt.text = data.title;
        _priceTxt.text = data.price.ToString();
        _avarImg.sprite = avar;

    }

    public void ShowItem(GameObject obj)
    {
        if (Data == null) return;
        ManangerItem.Instance.ShowItem(this);
    }

    public void OnDisable()
    {
        Data = null;
    }
}
