using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance;

    public static Managers GetInstance() 
    { 
        Init(); 
        return instance; 
    }

    void Start()
    {
        Init();
    }

    static void Init()
    {
        if (instance == null)
        {
            // @Managers가 존재하는지 확인
            GameObject manager = GameObject.Find("@Managers");

            // 존재하지 않는다면 생성
            if (manager == null)
                manager = new GameObject { name = "@Managers" };

            if (manager.GetComponent<Managers>() == null)
                manager.AddComponent<Managers>();

            // 사라지지 않도록 설정
            DontDestroyOnLoad(manager);

            // instance 할당
            instance = manager.GetComponent<Managers>();
        }
    }
}
