using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetSetting : MonoBehaviour
{
    /*
    [초기화 목록]
    
    - 헤어 모델 초기화
    - 헤어 색상 초기화
    - Undo 버튼 Color 리스트 초기화
    - 염색 모드 Picker 위치 초기화
    - 탈색 모드로 초기화
    - 탈색 모드 레벨 초기화
    - 탈색 모드 Picker 위치 초기화
    - 카메라 위치 초기화
    */

    [Header ("- 초기화 할 게임오브젝트")]
    public GameObject Model;
    public GameObject Camera;
    public GameObject UI;

    private modelHairChange hairModel;
    private modelHairColorChange hairColor;
    private paletteMode paletteUI;

    public GameObject applyButton;

    void Start()
    {
        // - 헤어 모델 초기화용 modelHairChange 스크립트
        hairModel       = Model.GetComponent<modelHairChange>();
        
        // - 헤어 색상 초기화용 modelHairColorChange 스크립트
        hairColor       = Model.GetComponent<modelHairColorChange>();
        
        // - 탈색 모드로 초기화용   paletteMode 스크립트
        paletteUI       = UI.GetComponent<paletteMode>();
    }

    public void reset()
    {
        // - 헤어 모델 초기화
        hairModel.changeHair(0);    // 헤어 모델 인덱스 0번으로 초기화

        // - 헤어 색상 초기화
        hairColor.afterColor = Color.black; // 바뀔 컬러 검은색으로 설정
        hairColor.hairColorChange(true);    // 헤어 컬러 즉시 변환
        
        // - Undo 버튼 Color 리스트 초기화
        hairColor.recordClear();            // Color 리스트 초기화

        // - 염색 모드 Picker 위치 초기화
        paletteUI.setBleachingMode(false);  // Palette를 염색 모드로 설정

        // - 탈색 모드로 초기화
        paletteUI.setBleachingMode(true);   // Palette를 탈색 모드로 설정

        // - 탈색 모드 레벨 초기화
        GameObject bleaching = GameObject.Find("Bleaching");    // 현재 Active 되어 있는 탈색 모드 Bleaching 선택
        bleaching.GetComponent<bleachingLevel>().setLevel(5);   // 컬러 레벨 6(5 + 1)으로 초기화
        bleaching.GetComponent<colorPicker>().getColor();       // Picker 및 selectedColor 초기화

        // - 탈색 모드 Picker 위치 초기화
        GameObject picker = GameObject.Find("Picker");  // 현재 Active 되어 있는 탈색 모드 Picker 선택
        picker.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;   // Rect Transform의 Pos를 모두 0으로 초기화

        // - 카메라 위치 초기화
        Camera.transform.rotation = Quaternion.Euler(0, 0, 0);

        //버튼 초기화
        applyButton.gameObject.SetActive(true);
    }
}
