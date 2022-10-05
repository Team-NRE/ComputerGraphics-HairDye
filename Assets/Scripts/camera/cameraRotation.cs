using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    #region 변수 목록
    // 마우스 정보 저장 Vector
    private Vector2 startMousePosition, endMousePosition;   // 마우스 시작 위치, 마우스 끝 위치
    [HideInInspector] public bool isCameraMoving; // 카메라 회전 가능 여부 (팔렛트 클릭시 잠그기용)

    [Header ("- 카메라 회전 속도")]
    public float horizontalRotateSpeed  = 25.0f;    // 수평 회전 속도
    public float verticalRotateSpeed    = 25.0f;    // 수직 회전 속도
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // 마우스 시작 위치, 끝 위치 초기화
        startMousePosition = endMousePosition = Vector2.zero;

        // 카메라 회전 가능 여부 초기화
        isCameraMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 카메라 회전 가능할 때만 실행
        if (isCameraMoving) {
            // 마우스 클릭 상호작용 처리
            if (Input.GetMouseButtonDown(0))
                startMousePosition = Input.mousePosition;   // 마우스 클릭 시 시작 마우스 위치 저장

            if (Input.GetMouseButton(0)) 
                clicking();
        }
    }

    // 카메라 회전 처리
    void clicking()
    {
        // 현재 마우스 위치 저장
        endMousePosition = Input.mousePosition;

        // 수평, 수직 마우스 위치 변화값 저장
        float horizontalAngle   = startMousePosition.x - endMousePosition.x;
        float verticalAngle     = startMousePosition.y - endMousePosition.y;

        // 카메라 앵글 변환
        transform.Rotate(
            new Vector3(
                verticalAngle * verticalRotateSpeed,     // 수직
                horizontalAngle * horizontalRotateSpeed, // 수평
                0                                        // Z 값 0
            ) * Time.deltaTime                           // 시간 변화
            , Space.World                                // 월드 기준 변화
        );

        // Rotation의 Z축을 0으로 만들어주기 위한 작업
        float z = transform.eulerAngles.z;
        transform.Rotate(0, 0, -z);

        // 끝 위치를 시작 위치로 변환 설정
        startMousePosition = endMousePosition;
    }

    public void setIsCameraMoving(bool state)
    {
        isCameraMoving = state;
    }
}
