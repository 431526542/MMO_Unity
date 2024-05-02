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
        //Screen 좌표계 -> 픽셀죄표기준으로 좌표를 나타내준다.
        //Debug.Log(Input.mousePosition);
        //Viewport -> 화면의 비율로 표시된다.
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));
        //World <-특정 스크린 좌표를 알았을 때 월드 좌표 구하기
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          
            Debug.DrawRay(Camera.main.transform.position, ray.direction*100.0f, Color.red, 1.0f);
            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
            //int mask = (1 << 8) | (1 << 9);//8,9번째 비트를 킨다. 768이라고 입력해도 되지만 읽기 쉽게 하기 위해 다음을 사용한다.

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100.0f, mask)) //8,9번만 걸리는 레이케스팅 적용한것
            {
                Debug.Log($"RaycastCamera @ {hit.collider.gameObject.name}");
            }
        }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            //Camera.main.nearClipPlane -> 클릭한 마우스 좌표는 2D이므로 Camera의 near값을 기준으로 높이(깊이)를 측정한다.
            Vector3 dir = mousPos - Camera.main.transform.position; //카메라부터 Camera의 near값을 빼는 방향 백터가 나온다.
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
