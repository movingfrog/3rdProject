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
            text.text = "이 맵은 슬라임이 열쇠를 얻어 깰 수 있습니다\n하지만 슬라임은 점프를 할 수 없고 중력을 space키로 바꿀 수 있습니다";
        }
    }
    public void Map3Button()
    {
        if(End.count >= 2)
        {
            Object.SetActive(true);
            MapButton[2].SetActive(true);
            Stars[2].SetActive(true);
            text.text = "이 맵은 미친사람이 열쇠를 얻어 깰 수 있습니다\n하지만 키가 뒤죽박죽 바뀌어버려 shift키로 움직이고 alt키로 점프를 할 수 있습니다";
        }
    }
    public void Map4Button()
    {
        if (End.count >= 3)
        {
            Object.SetActive(true);
            MapButton[3].SetActive(true);
            Stars[3].SetActive(true);
            text.text = "이맵은 눈이 침침한 인디언이 열쇠를 얻어 깰 수 있습니다\n하지만 어두워질 때 움직이면 죽습니다";
        }
    }
    public void Map1Button()
    {
        Object.SetActive(true);
        MapButton[0].SetActive(true);
        Stars[0].SetActive(true);
        text.text = "이 맵은 개구리로 열쇠를 얻어 깰 수 있습니다\n하지만 개구리는 마음대로 이동을 할 수 없고 점프를 해야지만이 이동할 수 있습니다\n점프는 누르는 시간에 따라 높이가 달라집니다";
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
