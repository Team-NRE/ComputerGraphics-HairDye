using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelHairChange : MonoBehaviour
{
    #region 변수 목록
    // 헤어 모델
    public GameObject hair;                         // 헤어 오브젝트
    private SkinnedMeshRenderer hairMeshRenderer;   // 헤어 렌더러

    // 헤어 목록
    public Mesh [] hairList;
    #endregion

    void Start()
    {
        // 초기화
        hairMeshRenderer = hair?.GetComponent<SkinnedMeshRenderer>();   // 헤어 렌더러 초기화
    }

    public void changeHair(int num)
    {
        /*
            헤어 모델 변환 함수

            int num : 바꿀 헤어 인덱스
        */

        hairMeshRenderer.sharedMesh = hairList[num];
    }
}
