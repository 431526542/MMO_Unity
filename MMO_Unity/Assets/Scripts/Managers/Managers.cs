using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //유일성 보장
    public static Managers Instance { get { return s_instance; } } // 유일한 매니저를 갖고온다.

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject Go = GameObject.Find("@Managers");
            if(Go == null) 
            {
                Go = new GameObject { name = "@Managers" };
                Go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(Go); //다시는 삭제되지 않도록 하기 위한 함수
            s_instance = Go.GetComponent<Managers>();
        }
    }
}
