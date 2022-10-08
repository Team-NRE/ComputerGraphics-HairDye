using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorPicker : MonoBehaviour
{
    #region 변수 목록
    [Header ("- Image Objects")]
    public Image palette;
    public Image picker;
    private Texture2D paletteTexture;

    [Header ("- Rect Transform Components")]
    public RectTransform uiRect;
    private RectTransform paletteRect, pickerRect;

    [Header ("- Picker Selected Color")]
    public Color selectedColor;

    private Vector2 sizeOfPalette;
    #endregion

    void Start()
    {
        // Rect Transform 불러오기
        paletteRect = palette.GetComponent<RectTransform>();
        pickerRect = picker.GetComponent<RectTransform>();

        // Palette의 Texture 이미지 불러오기
        paletteTexture = palette.mainTexture as Texture2D;

        // Palette 크기 초기화
        sizeOfPalette = new Vector2(
            paletteRect.rect.width,
            paletteRect.rect.height
        );

        // Picker 및 Selected Color 초기화
        getColor();
    }

    public void getColor()
    {
        // Picker의 중앙을 Palette의 중앙으로 변환
        Vector2 colorPosition = pickerRect.anchoredPosition + sizeOfPalette * 0.5f;
        
        // Vector2 원소를 0.0f ~ 1.0f 사이의 값으로 정규화
        Vector2 normalized = new Vector2(
            (colorPosition.x / sizeOfPalette.x),
            (colorPosition.y / sizeOfPalette.y)
        );

        // 픽셀의 색깔 추출
        selectedColor = paletteTexture.GetPixelBilinear(normalized.x, normalized.y);

        // Picker의 색깔 변환
        picker.color = selectedColor;
    }

    private void movePickerPos()
    {
        /*
            Palette 위의 Picker 위치 이동 함수
        */

        // palette 위의 마우스 위치 계산
        Vector2 offset = (Input.mousePosition - palette.transform.position);
        
        // picker Rect Transform 의 Position 설정
        // 화면 배율로 인한 마우스 위치 변화를 처리하기 위해 uiRect.localScale(크기 배율)로 나눔
        pickerRect.anchoredPosition = new Vector3(
            Mathf.Clamp(offset.x / uiRect.localScale.x, -sizeOfPalette.x / 2, sizeOfPalette.x / 2),
            Mathf.Clamp(offset.y / uiRect.localScale.y, -sizeOfPalette.y / 2, sizeOfPalette.y / 2),
            0
        );
    }

    public void selectColor()
    {
        /*
            마우스를 이용한 Picker 컬러 선택 함수
        */

        // Picker 이동 함수
        movePickerPos();

        // Color 선택 함수
        getColor();
    }
}
