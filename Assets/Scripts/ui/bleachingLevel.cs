using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bleachingLevel : MonoBehaviour
{
    #region 변수 설정
    [Header ("- Rect Transform Components")]
    public RectTransform paletteRect;
    public RectTransform pickerRect;

    [Header ("- UI Texts")]
    public Text levelText;
    public Text levelNameText;

    [Header ("- Level Data")]
    [SerializeField] private int level = 0;
    private string [] levelName = {
        "Black",
        "Very Dark Brown",
        "Dark Brown",
        "Medium Brown",
        "Light Brown",
        "Dark Blond",
        "Medium Blond",
        "Light Blond",
        "Very Light Blond",
        "Lightest Blond",
        "Super Light Blond",
        "Ultra Lightest Blond"
    };
    #endregion

    void Start()
    {
        changeLevelUI();
    }

    private void changePickerPos()
    {
        /*
            level 변화에 의한 Picker의 위치 재설정 함수
        */

        // level에 의한 Picker의 위치 재설정
        pickerRect.anchoredPosition = new Vector3(
            0,
            (paletteRect.rect.height / 12) * (level - levelName.Length / 2 + 0.5f),
            0
        );
    }

    public void changeLevelUI()
    {
        /*
            Picker의 위치에 의한 level 및 Text 재설정 함수
        */

        level = (int)((pickerRect.anchoredPosition.y + paletteRect.rect.height / 2 - 0.001f) / (paletteRect.rect.height / 12));
        
        levelText.text = (level + 1).ToString();
        levelNameText.text = "- " + levelName[level] + " -";
    }

    public void addLevel(int l)
    {
        /*
            level 증감 변화
        */

        if (level + l < 0 || level + l > 11) return;

        level += l;
        changePickerPos();
        changeLevelUI();
    }

    public void setLevel(int l)
    {
        /*
            level 고정 설정
        */

        if (l < 0 || l > 11) return;

        level = l;
        changePickerPos();
        changeLevelUI();
    }
}
