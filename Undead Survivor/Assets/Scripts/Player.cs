using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //이름은 데이터가  지닌 의미를 파악할 수 있도록 짓기
    //public : 다른 스크립트에게 '공개한다'라고 선언하는 키워드
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;

    //시작할 때 한번만 실행되는 생명주기 Awake에 실행
    void Awake()
    {
        //GetComponent<> : 오브젝트에서 컴포넌트를 가져오는 함수
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 유니티에서 받는 모든 입력을 관리하는 클래스
        // GetAxisRaw로 더욱 명확한 컨트롤 구현 
        inputVec.x = Input.GetAxisRaw("Horizontal");   //수평 x축
        inputVec.y = Input.GetAxisRaw("Vertical");     //수직 y축
    }

    //FixedUpdate : 물리 연산 프레임마다 호출되는 생명주기 함수
    void FixedUpdate()
    {
        // normalized : 벡터 값의 크기가 1이 되도록 좌표가 수정된 값'
        // fixedDeltaTime : 물리 프레임 하나가 소비한 시간(FixedUpdate에서 사용)
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        // 위치 이동 MovePosition
        // MovePosition은 위치 이동이라 현재 위치도 더해주어야함
        rigid.MovePosition(rigid.position + nextVec);
    }
}
