using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class EmployeeVisualizer : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 cardOffset;
    public int columnCount;
    public List <EmployeeInformation> information;  
    public GameObject infoCard;

    public float scrollSpeed;
    private float curYPos;
    private Vector2 visualizerStartPos;
    public List<Transform> itemList;
    public static EmployeeVisualizer instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddAnItem(EmployeeInformation _employeeInfo)
    {

         Transform NEW_INSTANCE = Instantiate(infoCard, transform).transform;
        MakeACard(_employeeInfo, NEW_INSTANCE);
        itemList.Add(NEW_INSTANCE);

    }
    private void OnValidate()
    {
        if (itemList == null)
            return;
        for (int i = 0; i < itemList.Count; i++)
        {

            MoveCard(itemList[i].GetComponent<RectTransform>(), i);
        }
    }
    void Start()
    {
        itemList = new List<Transform> ();
        visualizerStartPos = transform.position;
        for (int i = 0; i < information.Count; i++)
        {
            AddAnItem(information[i]);
        }

    }
    private void Update()
    {
      float SCROLL_DIRECTION = Input.mouseScrollDelta.y;
        if (SCROLL_DIRECTION != 0)
        {
            Scroll(SCROLL_DIRECTION);
        }
    }
    private void MakeACard(EmployeeInformation _info, Transform _Cardtransform)
    {
        _Cardtransform.GetChild(0).GetComponent<Image>().sprite = _info.profilePicture;
        _Cardtransform.GetChild(1).GetComponent<TextMeshProUGUI>().color = _info.employeeFavouriteColor;
        _Cardtransform.GetChild(2).GetComponent<TextMeshProUGUI>().text = _info.employeeName;

    }
    private void MoveCard(RectTransform _CardRT, int _Index)
    {
        int ROW = _Index % columnCount;
        int COLUMN = Mathf.FloorToInt(_Index / (float)columnCount);
        Vector2 NEW_POSITION = startPos;
        NEW_POSITION += new Vector2(cardOffset.x * ROW, cardOffset.y * COLUMN);
        _CardRT.localPosition = NEW_POSITION;
    }

    private void Scroll(float _ScrollDirection)
    {
        curYPos += _ScrollDirection * scrollSpeed;
        Debug.Log(_ScrollDirection);
        transform.position = visualizerStartPos + new Vector2(0, curYPos);
    }

}
[System.Serializable]
public class EmployeeInformation
{
    public Sprite profilePicture;
    public string employeeName;
    public Color employeeFavouriteColor;

}

