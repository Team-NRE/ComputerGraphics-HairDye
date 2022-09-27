using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelHairColorChange : MonoBehaviour
{
    #region 변수 목록
    // 헤어 모델
    public GameObject hair;         // 헤어 오브젝트
    public Material hairMaterial;  // 헤어 메터리얼

    // 컬러값
    public Color beforeColor;  // 바뀌기 전 컬러
    public Color afterColor;    // 바뀐 후 컬러
    
    // 점층적 변화 시간
    public float changeTime;    // 걸리는 시간 (단위 초)
    public float nowTime;      // 현재 바뀐 시간 저장용
    #endregion

    void Start()
    {
        // 초기화
        hairMaterial = hair.GetComponent<SkinnedMeshRenderer>()?.materials[0];  // 헤어 메테리얼 초기화
        beforeColor = afterColor = hairMaterial.color; // 헤어 컬러 초기화
        nowTime = changeTime;
    }

    void FixedUpdate()
    {
        #region 점층적 헤어 컬러 변환
        if (nowTime < changeTime) {
            nowTime += Time.deltaTime;
            hairMaterial.color = Color.Lerp(beforeColor, afterColor, nowTime / changeTime);
        }
        
        // 헤어 모델 변환 완료 시, 바뀌기 전 컬러를 바뀐 후 컬러로 변환
        if (hairMaterial.color == afterColor)
            beforeColor = afterColor;
        #endregion
    }

    public void hairColorChange(Color newColor, bool isInstant = true)
    {
        /*
            헤어 컬러 변환 함수

            Color   newColor    : 바꿀 헤어 색
            bool    isInstant   : 즉시 바꿀지 여부 (default : true)
                true  : 헤어 색을 바로 바꿈
                false : changeTime 변수 초 만큼 점층적으로 변환
        */

        if (isInstant)
        {
            hairMaterial.color = newColor;
        }
        else 
        {
            afterColor = newColor;
            nowTime = 0;
        }
    }
}
