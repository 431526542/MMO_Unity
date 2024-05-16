using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Util
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }
   public static GameObject FindChild(GameObject go, string name = null, bool recurslve = false)
   {
        Transform transform = FindChild<Transform>(go, name, recurslve);
        if(transform == null)
            return null;
        return transform.gameObject;
   }
   public static T FindChild<T>(GameObject go, string name = null, bool recurslve = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if(recurslve==false)
        {
            for(int i =0;i<go.transform.childCount;i++)
            {
                //���� ������ �ִ� �ڽ��� �ϳ��� ��ĵ�ϸ鼭
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    //������Ʈ�� ������ �ִ��� Ȯ��
                    T component = transform.GetComponent<T>();
                    if(component != null)
                        return component; //������ ��ȯ�Ѵ�.
                }
            } 
        }
        else
        {
            foreach(T component in go.GetComponentsInChildren<T>())
            {
                if(string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }
}