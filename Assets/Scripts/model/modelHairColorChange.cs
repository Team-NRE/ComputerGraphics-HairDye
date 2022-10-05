using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelHairColorChange : MonoBehaviour
{
    #region 변수 목록
    [Header ("- 헤어 모델")]
    public GameObject hair;         // 헤어 오브젝트
    private Material hairMaterial;  // 헤어 메터리얼

    [Header ("- 컬러 값")]
    public Color beforeColor;   // 바뀌기 전 컬러
    public Color afterColor;    // 바뀐 후 컬러
    
    [Header ("- 점층적 변화 시간")]
    public float changeTime;    // 걸리는 시간 (단위 초)
    private float nowTime;      // 현재 바뀐 시간 저장용

    [Header ("- 컬러 변환 기록")]
    
    #endregion

    void Start()
    {
        // 초기화
        hairMaterial = hair.GetComponent<SkinnedMeshRenderer>()?.materials[0];  // 헤어 메테리얼 초기화
        beforeColor = afterColor = hairMaterial.color; // 헤어 컬러 초기화
        nowTime = changeTime;   // 걸리는 시간 초기화
    }

    void FixedUpdate()
    {
        #region 점층적 헤어 컬러 변환
        // 현재 시간이 바뀌는 데 걸리는 시간보다 작을 경우 실행
        if (nowTime < changeTime) {
            nowTime += Time.deltaTime;
            hairMaterial.color = Color.Lerp(beforeColor, afterColor, nowTime / changeTime);
        }
        
        // 헤어 모델 변환 완료 시, 바뀌기 전 컬러를 바뀐 후 컬러로 변환
        if (hairMaterial.color == afterColor)
            beforeColor = afterColor;
        #endregion
    }

    public void hairColorChange(bool isInstant = true)
    {
        /*
            헤어 컬러 변환 함수
            
            bool    isInstant   : 즉시 바꿀지 여부 (default : true)
                true  : 헤어 색을 바로 바꿈
                false : changeTime 변수 초 만큼 점층적으로 변환
        */

        if (isInstant)
            hairMaterial.color = afterColor;
        else 
            nowTime = 0;
    }
}
