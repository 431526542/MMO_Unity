using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameScene : BaseScene
{
    //�ڷ�ƾ : �Լ��� ���¸� ����/���� ����
    //-> ��û �����ɸ��� �۾��� ��� ���ų�, ���ϴ� Ÿ�ֿ̹� �Լ��� �ӽ������� ���߰� �����ϴ°��
    //-> return : �츮�� ���ϴ� Ÿ������ ����(class�� ����)
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
            yield return null; //�ӽ�����
            yield return new Test() { id = 3 };
            yield return new Test() { id = 4 };
            yield break; //����
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

    //�߻�Ŭ���� ����
    public override void Clear()
    {
        
    }
}
