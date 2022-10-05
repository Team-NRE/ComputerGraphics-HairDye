using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paletteMode : MonoBehaviour
{
    #region 변수 목록
    [Header ("- Palette UI")]
    public GameObject BleachingUI;  // 탈색 모드 UI
    public GameObject DyeingUI;     // 염색 모드 UI
    #endregion

    public void setBleachingMode(bool isBleachingMode = true)
    {
        /*
            Palette UI 변경 함수

            bool isBleachingMode : (default : true)
                true    일 경우 탈색 모드로 UI 변경
                false   일 경우 염색 모드로 UI 변경
        */

        // UI 변경 if문
        if (isBleachingMode)
        {
            BleachingUI.SetActive(true);
            DyeingUI.SetActive(false);
        }
        else
        {
            BleachingUI.SetActive(false);
            DyeingUI.SetActive(true);
        }
    }
}
