using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager2 : MonoBehaviour
{
    public GameObject Object;
    public Text text;
    public GameObject[] MapButton;
    public GameObject[] Stars;

    private void Start()
    {
        Object.SetActive(false);
    }
    public void Map2Button()
    {
        if(End.count >= 1)
        {
            Object.SetActive(true);
            MapButton[1].SetActive(true);
            Stars[1].SetActive(true);
            text.text = "�� ���� �������� ���踦 ��� �� �� �ֽ��ϴ�\n������ �������� ������ �� �� ���� �߷��� spaceŰ�� �ٲ� �� �ֽ��ϴ�";
        }
    }
    public void Map3Button()
    {
        if(End.count >= 2)
        {
            Object.SetActive(true);
            MapButton[2].SetActive(true);
            Stars[2].SetActive(true);
            text.text = "�� ���� ��ģ����� ���踦 ��� �� �� �ֽ��ϴ�\n������ Ű�� ���׹��� �ٲ����� shiftŰ�� �����̰� altŰ�� ������ �� �� �ֽ��ϴ�";
        }
    }
    public void Map4Button()
    {
        if (End.count >= 3)
        {
            Object.SetActive(true);
            MapButton[3].SetActive(true);
            Stars[3].SetActive(true);
            text.text = "�̸��� ���� ħħ�� �ε���� ���踦 ��� �� �� �ֽ��ϴ�\n������ ��ο��� �� �����̸� �׽��ϴ�";
        }
    }
    public void Map1Button()
    {
        Object.SetActive(true);
        MapButton[0].SetActive(true);
        Stars[0].SetActive(true);
        text.text = "�� ���� �������� ���踦 ��� �� �� �ֽ��ϴ�\n������ �������� ������� �̵��� �� �� ���� ������ �ؾ������� �̵��� �� �ֽ��ϴ�\n������ ������ �ð��� ���� ���̰� �޶����ϴ�";
    }
    public void XButton()
    {
        Object.SetActive(false);
        for(int i = 0;i< MapButton.Length; i++)
        {
            MapButton[i].SetActive(false);
        }
    }
}
