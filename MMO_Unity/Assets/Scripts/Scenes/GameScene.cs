using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameScene : BaseScene
{
    //코루틴 : 함수의 상태를 저장/복원 가능
    //-> 엄청 오래걸리는 작업을 잠시 끊거나, 원하는 타이밍에 함수를 임시적으로 멈추고 복원하는경우
    //-> return : 우리가 원하는 타입으러 가능(class도 가능)
    /*
    class Test
    {
        public int id = 0;
    }
    
    class CoroutineTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new Test() { id = 1 };
            yield return new Test() { id = 2 };
            yield return null; //임시정지
            yield return new Test() { id = 3 };
            yield return new Test() { id = 4 };
            yield break; //종료
        }
    }*/

    Coroutine co;

    void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Inven>();
        Dictionary<int,Stat> dict = Managers.Data.StatDict;
        
    }

    //추상클래스 구현
    public override void Clear()
    {
        
    }
}
