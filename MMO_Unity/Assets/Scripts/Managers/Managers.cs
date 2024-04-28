using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //���ϼ� ����
    public static Managers Instance { get { return s_instance; } } // ������ �Ŵ����� ����´�.

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
            DontDestroyOnLoad(Go); //�ٽô� �������� �ʵ��� �ϱ� ���� �Լ�
            s_instance = Go.GetComponent<Managers>();
        }
    }
}
