using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker_Squre : MonoBehaviour
{
    #region 변수 목록
    public Image palette;
    public Image picker;

    private RectTransform paletteRect, pickerRect;

    public Color selectedColor;
    public Texture2D paletteTexture;

    private Vector2 sizeOfPalette;
    #endregion

    void Start()
    {
        paletteRect = palette.GetComponent<RectTransform>();
        pickerRect = picker.GetComponent<RectTransform>();

        sizeOfPalette = new Vector2(
            paletteRect.rect.width,
            paletteRect.rect.height
        );

        paletteTexture = palette.mainTexture as Texture2D;
    }

    public void MousePointerDown()
    {
        SelectColor();
    }

    public void MouseDrag()
    {
        SelectColor();
    }

    private Color GetColor()
    {
        Vector2 colorPosition = pickerRect.anchoredPosition + sizeOfPalette * 0.5f;
        
        Vector2 normalized = new Vector2(
            (colorPosition.x / sizeOfPalette.x),
            (colorPosition.y / sizeOfPalette.y)
        );

        return paletteTexture.GetPixelBilinear(normalized.x, normalized.y);
    }

    private void SelectColor()
    {
        Vector2 offset = Input.mousePosition - palette.transform.position;
        
        // picker Rect Transform 의 Position 설정
        pickerRect.anchoredPosition = new Vector3(
            Mathf.Clamp(offset.x * 2, -sizeOfPalette.x / 2, sizeOfPalette.x / 2),
            Mathf.Clamp(offset.y * 2, -sizeOfPalette.y / 2, sizeOfPalette.y / 2),
            0
        );

        selectedColor = GetColor();
        picker.color = selectedColor;
    }
}
