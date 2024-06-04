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

        co = StartCoroutine("ExplodeAfterSeconds", 4.0f);
        StartCoroutine("StopExplode", 2.0f);
    }

    IEnumerator StopExplode(float seconds)
    {
        Debug.Log("Stop Enter");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Stop Execute!!");
        if(co!=null)
        {
            StopCoroutine(co);
            co = null;
        }
    }

    IEnumerator ExplodeAfterSeconds(float seconds)
    {
        Debug.Log("Explode Enter");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Explode Execute!!");
        co = null;
    }

    //�߻�Ŭ���� ����
    public override void Clear()
    {
        
    }
}
