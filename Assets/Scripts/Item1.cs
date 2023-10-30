using UnityEngine;
using UnityEngine.UI;

public class Item1 : MonoBehaviour
{
    public items Data;
    [SerializeField] Text _nameTxt;
    [SerializeField] Text _priceTxt;
    [SerializeField] Image _avarImg;

    public Button GetButton()
    {
        return this.GetComponent<Button>();
    }

    public Sprite GetAvar()
    {
        return _avarImg.sprite;
    }

    public void Init(items data, Sprite avar)
    {
        this.Data = data;

        _nameTxt.text = data.title;
        _priceTxt.text = data.price.ToString();
        _avarImg.sprite = avar;
    }
}
