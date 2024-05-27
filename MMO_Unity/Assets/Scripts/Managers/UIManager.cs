using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//만든이유 : UI창의 Sort Order를 관리하기위함
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

    //외부에서 팝업UI가 켜지면 UI매니저한테 SetCanvas요청해 _order를 채움
    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true; //캔버스가 중첩해서 있을때 그 부모가 어떤 값을 가지던 나는 무조건 내 소팅오더를 가지겠다.
        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            //Popup이랑 상관없는 일반 UI
            canvas.sortingOrder = 0;
        }
        //->Scene, Popup에 호출해줌
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
        //name = Prefabs/UI/... name, T = Scripts와 연관이 있다.
    {
        // T 타입과 name을 맞춰주는 것을 우선으로 한다. 옵션으로 이름을 추가로 넣고 이름을 입력하지 않으면 T의 이름을 그대로 사용
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");

        //go의 컴포넌트 추출
        T popup = Util.GetOrAddComponent<T>(go);

        //_popupStack에 넣어준다.
        _popupStack.Push(popup);

        go.transform.SetParent(Root.transform);

        return popup;
    }

    //안전한 버전
    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0)
            return;
        //Peek = 마지막 연 UI을 옅보는 기능
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

        //가장최근에 띄운 팝업
        UI_Popup popup = _popupStack.Pop();
        //popup이라는 컴포넌트가 물고있는 부모를 지울 수 있다.
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
