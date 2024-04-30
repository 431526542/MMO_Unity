using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //���ϼ� ����
    static Managers Instance { get { Init(); return s_instance; } } // ������ �Ŵ����� ����´�.

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    public static InputManager Input { get { return Instance._input;} }
    public static ResourceManager Resource { get { return Instance._resource; } }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _input.OnUpdate();
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
