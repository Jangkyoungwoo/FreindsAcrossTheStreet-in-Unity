using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target; // 타겟설정
    public float Smooth = 5f;  //부드럽게 움직이는 것을 위해 설정

    Vector3 m_OffsetVal;
    // Start is called before the first frame update
    void Start()
    {
        m_OffsetVal = transform.position - Target.position; //얼만큼 떨어졌는지 알기위해서 설정
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetCameraPos = new Vector3(Target.position.x, 0, Target.position.z) + m_OffsetVal; // player가 떨어지는 것을 쫒아가지 않기 위해 y축 고정
        transform.position = Vector3.Lerp(transform.position, targetCameraPos, Smooth * Time.deltaTime); //두 벡터 사이의 시간에 따른 위치를 구하기 위해 Lerp사용
    }
}
