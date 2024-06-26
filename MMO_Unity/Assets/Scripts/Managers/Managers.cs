using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //유일성 보장
    static Managers Instance { get { Init(); return s_instance; } } // 유일한 매니저를 갖고온다.

    DataManager _data = new DataManager();
    InputManager _input = new InputManager();
    PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();
    SceneManagerEX _Scene = new SceneManagerEX();
    SoundManager _sound = new SoundManager();
    UIManager _ui = new UIManager();
    
    public static DataManager Data { get { return Instance._data; } }   
    public static InputManager Input { get { return Instance._input;} }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static SceneManagerEX Scene { get { return Instance._Scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static UIManager UI { get { return Instance._ui; } }
     

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
            DontDestroyOnLoad(Go); //다시는 삭제되지 않도록 하기 위한 함수
            s_instance = Go.GetComponent<Managers>();
            s_instance._data.Init();
            s_instance._pool.Init();
            s_instance._sound.Init();
        }
    }
    public static void Clear()
    {
        Sound.Clear();
        Input.Clear();
        Scene.Clear();
        UI.clear();

        Pool.Clear();
    }
}
