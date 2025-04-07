using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Interaxon.Libmuse;

public class UIFollowMouse1 : MonoBehaviour
{
    private RectTransform rectTransform;
    public Vector2 offset = new Vector2(65f, -65f); // ���콺���� ��¦ ������ �Ʒ�
    public List<Sprite> spriteList; 
    public string MouseColor = "Red";
    public int Clicked = 0;
    private Renderer _eyeRenderer;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Cursor.visible = false; // �⺻ ���콺 Ŀ�� �����
        _eyeRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 mousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent as RectTransform,
            Input.mousePosition,
            null,
            out mousePosition);

        rectTransform.anchoredPosition = mousePosition + offset;

        if (InteraxonInterfacer.Instance.Artifacts.blink)
        {
            ChangeColor("Red");
        }
    }

    public void ChangeColor(string colored)
    {
        if (colored == "Red")
        {
            gameObject.GetComponent<Image>().sprite = spriteList[0];
        }
        if (colored == "Orange")
        {
            gameObject.GetComponent<Image>().sprite = spriteList[1];
        }
        if (colored == "Yellow")
        {
            gameObject.GetComponent<Image>().sprite = spriteList[2];
        }
        if (colored == "Green")
        {
            gameObject.GetComponent<Image>().sprite = spriteList[3];
        }
        if (colored == "Sky")
        {
            gameObject.GetComponent<Image>().sprite = spriteList[4];
        }
        if (colored == "Blue")
        {
            gameObject.GetComponent<Image>().sprite = spriteList[5];
        }
        if (colored == "Purple")
        {
            gameObject.GetComponent<Image>().sprite = spriteList[6];
        }
    }
}