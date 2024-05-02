using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject.name}!");   
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger @{other.gameObject.name}!");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Screen ��ǥ�� -> �ȼ���ǥ�������� ��ǥ�� ��Ÿ���ش�.
        //Debug.Log(Input.mousePosition);
        //Viewport -> ȭ���� ������ ǥ�õȴ�.
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));
        //World <-Ư�� ��ũ�� ��ǥ�� �˾��� �� ���� ��ǥ ���ϱ�
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          
            Debug.DrawRay(Camera.main.transform.position, ray.direction*100.0f, Color.red, 1.0f);
            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
            //int mask = (1 << 8) | (1 << 9);//8,9��° ��Ʈ�� Ų��. 768�̶�� �Է��ص� ������ �б� ���� �ϱ� ���� ������ ����Ѵ�.

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100.0f, mask)) //8,9���� �ɸ��� �����ɽ��� �����Ѱ�
            {
                Debug.Log($"RaycastCamera @ {hit.collider.gameObject.name}");
            }
        }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            //Camera.main.nearClipPlane -> Ŭ���� ���콺 ��ǥ�� 2D�̹Ƿ� Camera�� near���� �������� ����(����)�� �����Ѵ�.
            Vector3 dir = mousPos - Camera.main.transform.position; //ī�޶���� Camera�� near���� ���� ���� ���Ͱ� ���´�.
            dir = dir.normalized;
            Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, dir * 100.0f, out hit, 100.0f))
            {
                Debug.Log($"RaycastCamera @ {hit.collider.gameObject.name}");
            }
        }*/
    }
}
