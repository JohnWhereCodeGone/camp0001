using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoDisplay : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 itemOffset;
    public Vector2 visualizerStartPos;
    public GameObject itemCard;
    public List<Metal> itemCC;
    private List<Transform> SpawnedItems;
    public int columnCount;

    void Start()
    {
        visualizerStartPos = transform.position;
        SpawnedItems = new List<Transform>();
        for (int i = 0; i < itemCC.Count; i++)
        {
            Transform NEW_INSTANCE = Instantiate(itemCard, transform).transform;
            createItem(itemCC[i], NEW_INSTANCE);
            moveItem(NEW_INSTANCE, i);
            SpawnedItems.Add(NEW_INSTANCE);
        }


    }
    public void OnValidate()
    {
        if(Application.isPlaying == false)
        {
            return;
        }
        for (int i = 0; i < SpawnedItems.Count; i++)
        {
            moveItem(SpawnedItems[i], i);
        }
    }

    private void createItem(Item _info, Transform _itemTransform)
    {
        _itemTransform.transform.GetChild(0).GetComponent<Image>().sprite = _info.itemImage;
        _itemTransform.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _info.GetDescription();
        _itemTransform.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = _info.itemName;
        _itemTransform.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = _info.itemID;

    }
    private void moveItem(Transform _info, int _index)
    {
        int ROW = _index % columnCount;
        int COLUMN = Mathf.FloorToInt(_index / (float)columnCount);
        Vector2 NEW_POSITION = startPos;
        NEW_POSITION += new Vector2(itemOffset.x * ROW, itemOffset.y * COLUMN);
        _info.localPosition = NEW_POSITION;
    }

}
