using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� : UIâ�� Sort Order�� �����ϱ�����
public class UIManager
{
    int _order = 10;
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _sceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" };
            return root;
        }
    }

    //�ܺο��� �˾�UI�� ������ UI�Ŵ������� SetCanvas��û�� _order�� ä��
    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true; //ĵ������ ��ø�ؼ� ������ �� �θ� � ���� ������ ���� ������ �� ���ÿ����� �����ڴ�.
        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            //Popup�̶� ������� �Ϲ� UI
            canvas.sortingOrder = 0;
        }
        //->Scene, Popup�� ȣ������
    }
    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/SubItem/{name}");
        if (parent != null)
            go.transform.SetParent(parent);

        return  Util.GetOrAddComponent<T>(go);
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;

        go.transform.SetParent(Root.transform);

        return sceneUI;
    }

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
        //name = Prefabs/UI/... name, T = Scripts�� ������ �ִ�.
    {
        // T Ÿ�԰� name�� �����ִ� ���� �켱���� �Ѵ�. �ɼ����� �̸��� �߰��� �ְ� �̸��� �Է����� ������ T�� �̸��� �״�� ���
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");

        //go�� ������Ʈ ����
        T popup = Util.GetOrAddComponent<T>(go);

        //_popupStack�� �־��ش�.
        _popupStack.Push(popup);

        go.transform.SetParent(Root.transform);

        return popup;
    }

    //������ ����
    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0)
            return;
        //Peek = ������ �� UI�� ������ ���
        if(_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed");
            return;
        }
        ClosePopupUI();
    }
    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        //�����ֱٿ� ��� �˾�
        UI_Popup popup = _popupStack.Pop();
        //popup�̶�� ������Ʈ�� �����ִ� �θ� ���� �� �ִ�.
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;
        _order--;
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }
    public void clear()
    {
        CloseAllPopupUI();
        _sceneUI = null;  
    }
}
