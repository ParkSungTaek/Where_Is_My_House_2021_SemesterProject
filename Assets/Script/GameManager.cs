﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    static GameManager _instance;         //이 클래스의 객체입니다. 우리는 이제부터 이 객체를 게임 매니저라고 생각하고 사용할 것입니다.
    public static GameManager instance { get { Init(); return _instance; } }         //이 클래스의 객체입니다. 우리는 이제부터 이 객체를 게임 매니저라고 생각하고 사용할 것입니다.

    public GameObject Fever;
    public bool GameOver = false;               //게임이 오버되었는지 알아보는 부울값입니다.
    public int Get_Point = 0;                   //게임 실행할 때 나타날 포인트입니다.
    public bool Is_Fever = false;               //피버상태인지 알아보는 부울값입니다.
    public int Twins_Count = 0;                 //Twins 큐브가 1번 쌓일때마다 1씩 증가하며 count가 2가 되면 2포인트를 획득합니다.
    public bool IsFuncTwice = false;
    public bool isPause = false;                        //퍼즈상태인가?
    public float Sound = 0f;
    
    int max_Point = 0;
    public int FeverCubeCount = 0;
    public int FeverMissCount = 0;


    public float firstHeight = 0; // first큐브 y값 입니다.
    public bool gameStop; //게임이 일시정지 상태인지 확인하는 부울값입니다.
    //PlayerPrefs
    string strMax_Point = "aenfl;sdkn4felknarvk8ld9fe";

    static void Init()
    {
        if (_instance == null)
        {
            GameObject GM = GameObject.Find("GameManager");
            if (GM == null)
            {
                GM = new GameObject { name = "GameManager" };
                GM.AddComponent<GameManager>();

            }

            DontDestroyOnLoad(GM);
            _instance = GM.GetComponent<GameManager>();
            

        }
    }

    private void Awake()                        //Scene 이동을 하더라도 이 객체는 부서지지 않습니다. Scene 이동을 통해 어떤 식으로 객체가 부서지지 않는지 확인해봅시다. 
    {

        Init();

        max_Point = PlayerPrefs.GetInt(strMax_Point, 0);

    }
    private void Start()
    {
        //Fever = GameObject.Find("Fever");
        Screen.SetResolution(1440, 2960, true);
        max_Point = PlayerPrefs.GetInt(strMax_Point,0);
    }

    public void SaveData()                                      //변수 저장 방법입니다.
    {
        PlayerPrefs.SetInt(strMax_Point, Get_Point);
        max_Point = Get_Point;
    }
    public int Get_Max_Point()                                       //저장한 변수를 불러오는 방법입니다.
    {
        return max_Point;
    }

    public void RE_Max_Point()
    {
        max_Point = 0;
    }
    public void FeverStart()
    {
        Fever.GetComponent<FeverSystem>().FeverStart();
        Is_Fever = true;
        FeverCubeCount = 0;
        FeverMissCount = 0;
    }
    public void FeverEnd()
    {
        Fever.GetComponent<FeverSystem>().FeverEnd();
        Is_Fever = false;
        FeverCubeCount = 0;
        FeverMissCount = 0;
    }
    public void SaveSound(float sound)
    {
        PlayerPrefs.SetFloat("SoundSave", sound);
    }
    public float GetSound()
    {
        return PlayerPrefs.GetFloat("SoundSave", 0f);
    }
}