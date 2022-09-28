using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bleachingLevel : MonoBehaviour
{
    #region 변수 설정
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI levelNameText;
    public RectTransform paletteRect;
    public RectTransform pickerRect;

    public int level = 0;
    public string [] levelName = {
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

    void FixedUpdate()
    {
        level= (int)((pickerRect.anchoredPosition.y + paletteRect.rect.height / 2 - 0.001f) / (paletteRect.rect.height / 12));
        
        levelText.text = (level + 1).ToString();
        levelNameText.text = "- " + levelName[level] + " -";
    }

    void changeLevelUI()
    {
        pickerRect.anchoredPosition = new Vector3(
            0,
            (paletteRect.rect.height / 12) * (level - levelName.Length / 2 + 0.5f),
            0
        );
    }

    public void setLevel(int l)
    {
        if (level + l < 0 || level + l > 11) return;

        level += l;
        changeLevelUI();
    }
}
