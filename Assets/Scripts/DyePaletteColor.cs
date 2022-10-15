using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DyePaletteColor : MonoBehaviour
{
    [Header(" - 팔레트 상위 객체")]
    [SerializeField]
    private GameObject motherObject;    //팔레트 상위객체 : 묶어준 빈 오브젝트

    private Image[] paletteRenderer;    //팔레트 하위객체 : 색 블럭

    private Color listSelected;
    public static Image clickedColor;   //버튼팔레트에서 선택한 팔레트 색 전달을 위한 변수
    private GameObject reRender;
    int count = 0;

    Color[] colorArr = new Color[]
{
            new Color(100/255f, 15/255f,  44/255f),
            new Color(185/255f, 72/255f,  38/255f),
            new Color(150/255f, 56/255f,  30/255f),
            new Color(177/255f, 60/255f,  42/255f),
            new Color(95/255f,  10/255f,  13/255f),
            new Color(144/255f, 36/255f,  49/255f),
            new Color(54/255f,  73/255f,  142/255f),
            new Color(68/255f,  68/255f,  68/255f),
            new Color(2/255f,   140/255f, 186/255f),
            new Color(48/255f,  58/255f,  119/255f),
            new Color(131/255f, 150/255f, 157/255f),
            new Color(246/255f, 242/255f, 230/255f),
            new Color(236/255f, 163/255f, 58/255f),
            new Color(183/255f, 74/255f,  43/255f),
            new Color(160/255f, 75/255f,  47/255f),
            new Color(242/255f, 117/255f, 9/255f),
            new Color(184/255f, 72/255f,  34/255f),
            new Color(160/255f, 54/255f,  40/255f),
            new Color(0/255f,   88/255f,  76/255f),
            new Color(6/255f,   110/255f, 77/255f),
            new Color(246/255f, 241/255f, 28/255f),
            new Color(179/255f, 184/255f, 42/255f),
            new Color(98/255f,  157/255f, 63/255f),
            new Color(2/255f,   122/255f, 136/255f),
            new Color(211/255f, 95/255f,  132/255f),
            new Color(194/255f, 124/255f, 176/255f),
            new Color(174/255f, 160/255f, 211/255f),
            new Color(80/255f,  65/255f,  106/255f),
            new Color(80/255f,  65/255f,  106/255f),
            new Color(99/255f,  69/255f,  119/255f),
            new Color(157/255f, 57/255f,  93/255f),
            new Color(185/255f, 82/255f,  101/255f),
            new Color(228/255f, 136/255f, 123/255f),
            new Color(147/255f, 65/255f,  79/255f)
};

    void Start()
    {
        ColorMapping();
    }

    // n/255f를 안붙이면 적용이 안돼는 아주 화가나는 특성이 있음에 주의
    public void ColorMapping()
    {
        //자식객체의 컬러 컴포넌트
        paletteRenderer = motherObject.GetComponentsInChildren<Image>();
        RawImage[] checkRenderer = motherObject.GetComponentsInChildren<RawImage>();
        Debug.Log(paletteRenderer.Length);

        //자식객체에 모두 접근하여 Color값 할당
        for(int i = 0; i < colorArr.Length; i++)
        {
            //Debug.Log($"{paletteRenderer[i].name}, ({colorArr[i].r}, {colorArr[i].g}, {colorArr[i].b})");
            paletteRenderer[i].color = colorArr[i];
            checkRenderer[i].gameObject.SetActive(false);   //초기에 체크는 모두 
            //Debug.Log($"{ paletteRenderer[i]}");
        }

    }

    public void CheckMarkRefresh()
    {
        RawImage[] checkedRenderer = motherObject.GetComponentsInChildren<RawImage>();
        Debug.Log(colorArr.Length);
        Debug.Log(checkedRenderer.Length);
        for (int i = 0; i < colorArr.Length; i++)
        {
            if (checkedRenderer[0].gameObject.activeSelf == true) 
            {
                checkedRenderer[0].gameObject.SetActive(false);   //다시한번 비활성화
            }
        }
    }
    

    public void OnClickPalette()
    {
        if (count >= 1)
        {
            CheckMarkRefresh();
        }

        clickedColor = null;
        clickedColor = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        reRender = clickedColor.gameObject.transform.GetChild(0).gameObject;
        //Debug.Log(clickedColor.gameObject.transform.GetChild(0).gameObject.name);
        reRender.gameObject.SetActive(true);
        count++;
    }
}
