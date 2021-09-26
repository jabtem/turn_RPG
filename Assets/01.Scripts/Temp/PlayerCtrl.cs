using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 유니티 네비게이션 활용을 위한 선언
using UnityEngine.AI;
// 유니티 UI 사용을 위한 선언
using UnityEngine.UI;


/* 
    스크립트에서 의존하고 있는 Rigidbody 컴포넌트를 어트리뷰트로 등록하여 최초 게임오브젝트에 스크립트 추가시
    Rigidbody 컴포넌트 자동 생성 및 프로그래머의 실수로 인한 삭제되는것을 방지  
*/
[RequireComponent(typeof(Rigidbody))]
public class PlayerCtrl : MonoBehaviour {

    //NavMeshAgent 컴포넌트 할당 레퍼런스 
    private NavMeshAgent myTraceAgent;

    //이동가능여부
    public bool canMove = false;

    //케릭이 이동할 목적지 좌표
    Vector3 movePoint = Vector3.zero;

    //Ray 정보 저장 구조체 
    Ray ray;

    // Ray에 맞은 오브젝트 정보를 저장 할 구조체
    RaycastHit hitInfo1;

    // public 멤버 인스펙터에 노출을 막는 어트리뷰트
    // 인스펙터에 노출은 막고 외부 노출은 원하는 경우 사용
    [HideInInspector]
    //죽었는지 상태변수 
    public bool isDie;


    //자신의 Transform 참조 변수  
    private Transform myTr;

    //Ray 센서를 위한 변수
    bool check;

    //케릭터 센서 Idle 방향
    private bool turnRight;
    //케릭터 센서 각도
    private float turnValue;

    //플레이어 데미지


    void Awake()
    {
        //자기 자신의 Transform 연결 (추가)
        myTr = GetComponent<Transform>();

        //NavMeshAgent 컴포넌트를 해당 레퍼런스에 연결
        myTraceAgent = GetComponent<NavMeshAgent>();
        //nvAgent.velocity = Vector3.zero; //네비게이션 멈춤    
    }

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {

        ////////////////////////////////////////////

        if (canMove)
            myTraceAgent.isStopped = false;
        else if (!canMove)
        {
            myTraceAgent.isStopped = true;
            myTraceAgent.velocity = Vector3.zero;
            myTraceAgent.destination = myTr.position;
        }



        //Main Camera 에서 마우스 커서(Vector3 타입이지만 Z값 무시한 값 (0~1280,0~800,0) )의 위치로 캐스팅되는 Ray를 생성함
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Scene 뷰에만 시각적으로 표현함
        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.blue);

#if UNITY_EDITOR
        //마우스 왼쪽 버튼을 클릭시 Ray를 캐스팅  
        if (Input.GetMouseButtonDown(0) && !isDie)
        {
            //위에서 미리 생성한 ray를 인자로 전달, out(메서드 안에서 메서드 밖으로 데이타를 전달 할때 사용)hit, ray 거리, 레이어 마스크 값(레이어가 Ground 일때만 충돌)
            // Mathf.Infinity 이 값은 무한한 값이라고 생각하면 된다. 따라서 거리가 무한~~~
            if (Physics.Raycast(ray, out hitInfo1, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground") )&& canMove)
            {
                //ray에 맞은 위치를 이동할 목표지점으로 설정
                movePoint = hitInfo1.point;

                //NavMeshAgent 컴포넌트의 목적지 설정
                myTraceAgent.destination = movePoint;
                myTraceAgent.stoppingDistance = 0.0f;

            }
        }
#endif

#if UNITY_STANDALONE_WIN
        //마우스 왼쪽 버튼을 클릭시 Ray를 캐스팅  
        if (Input.GetMouseButtonDown(0) && !isDie)
        {
            //위에서 미리 생성한 ray를 인자로 전달, out(메서드 안에서 메서드 밖으로 데이타를 전달 할때 사용)hit, ray 거리, 레이어 마스크 값(레이어가 Barrel 일때만 충돌)
            // Mathf.Infinity 이 값은 무한한 값이라고 생각하면 된다. 따라서 거리가 무한~~~
            if (Physics.Raycast(ray, out hitInfo1, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
            {
                //ray에 맞은 위치를 이동할 목표지점으로 설정
                movePoint = hitInfo1.point;

                //NavMeshAgent 컴포넌트의 목적지 설정
                myTraceAgent.destination = movePoint;
                myTraceAgent.stoppingDistance = 0.0f;

            }
        }
#endif

#if UNITY_ANDROID
        //스크린에 터치가 이루어진 상태에서 첫 번째 손가락 터치가 시작됐는지 비교
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isDie)
        {
            //Main Camera에서 손가락 터치 위치로 캐스팅되는 Ray를 생성 함
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

            //위에서 미리 생성한 ray를 인자로 전달, out(메서드 안에서 메서드 밖으로 데이타를 전달 할때 사용)hit, ray 거리, 레이어 마스크 값(레이어가 Barrel 일때만 충돌)
            // Mathf.Infinity 이 값은 무한한 값이라고 생각하면 된다. 따라서 거리가 무한~~~
            if (Physics.Raycast(ray, out hitInfo1, Mathf.Infinity, 1 << LayerMask.NameToLayer("Barrel")))
            {
                //ray에 맞은 위치를 이동할 목표지점으로 설정
                movePoint = hitInfo1.point;

                //NavMeshAgent 컴포넌트의 목적지 설정
                myTraceAgent.destination = movePoint;
                myTraceAgent.stoppingDistance = 25.0f;
            }
            //위에서 미리 생성한 ray를 인자로 전달, out(메서드 안에서 메서드 밖으로 데이타를 전달 할때 사용)hit, ray 거리, 레이어 마스크 값(레이어가 Ground 일때만 충돌)
            // Mathf.Infinity 이 값은 무한한 값이라고 생각하면 된다. 따라서 거리가 무한~~~
            else if (Physics.Raycast(ray, out hitInfo1, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
            {
                //ray에 맞은 위치를 이동할 목표지점으로 설정
                movePoint = hitInfo1.point;

                //NavMeshAgent 컴포넌트의 목적지 설정
                myTraceAgent.destination = movePoint;
                myTraceAgent.stoppingDistance = 0.0f;

            }

        }
#endif
    }

    // 추가////////////////////////////////////////
    /*
        position : 월드좌표(절대좌표)
        localPosition : 로컬좌표(상대좌표)

        만약 부모객체가 (1, 1, 0) 에 있다고 가정하고
        자식객체가 localPosition 이 (1, 1, 0) 이라면
        자식객체의 position 은 (2, 2, 0) 이 됩니다.
        position은 실제 절대 좌표를 말하고 localPosition은
        해당 부모객체기준의 좌표를 말합니다.
        만약 부모-자식 관계를 해제하게되면
        자식객체의 position, localPosition 모두 (2, 2, 0) 이 됩니다.
    */


}


// https://docs.unity3d.com/kr/current/Manual/class-NavMeshAgent.html
// https://docs.unity3d.com/kr/current/Manual/class-NavMeshObstacle.html
// https://docs.unity3d.com/kr/current/Manual/class-OffMeshLink.html


/* SendMessage,SendMessageUpwards,BroadcastMessage
                                                                        
    SendMessage :원하는 GameObject에 붙어있는 한개 이상의 Script에 구현되어있는 메소드를 
    호출하는 방법. 이 방법을 사용하면 해당 GameObject에 실행하고자 하는 메소드를 
    가진 스크립트가 컴포넌트로 존재하는지 아닌지를 크게 신경쓰지 않고도 호출하는 것이 가능하다
    SendMessage 함수는 현재 스크립트가 실행중인 GameObject에 붙어있는 
    모든 MonoBehaviour 스크립트의 원하는 함수를 호출해 줍니다.

    원형)
    public void SendMessage(string methodName, object value = null,
    SendMessageOptions options = SendMessageOptions.RequireReceiver);

    ex1)
    SendMessage는 GameObject에 추가되어있는 모든 Script 컴포넌트들에 전달이 되게 된다.
    그중에 같은 이름을 가지고 있는 메소드가 있다면 그것이 실행되게 됨. 
    해당 이름의 메소드가 호출하는 스크립트 내부에 선언되어 있다면 그것이 최우선 순위로 실행이 되고 
    이후에는 컴포넌트에 등록되어있는 순서대로 메시지가 전달된다.

    public class ExampleClass1 : MonoBehaviour {
 
	    void Start () {
		    gameObject.SendMessage("ApplyDamage", 5.0f);
	    }
 
	    void ApplyDamage(float damage) {
		    Debug.Log ("ExampleClass1 Damage: " + damage);
	    }
    }
 
    public class ExampleClass2 : MonoBehaviour {
 
	    void Start () {
		
	    }
 
	    void ApplyDamage(float damage) {
		    Debug.Log ("ExampleClass2 Damage: " + damage);
	    }
    }
 
//=> 
ExampleClass1 Damage: 5
ExampleClass2 Damage: 5

    ex2)
    SendMessage를 호출할때는 파라미터를 가지고 있더라도 수신하는 메소드는 파라미터를 받지 않음으로써 
    넘어올 파라미터를 무시할 수 있다. 다음의 코드는 문제 없이 ApplyDamage() 메소드가 호출된다.
    SendMessage는 .Net 리플렉션을 통하여 구현된다. 때문에 처음 찾게 되는 같은 이름을 가진 메소드를 
    실행하게 되며 만약 메소드 오버로딩이 되어있는 상태라면 정상적으로 동작하지 않게 된다.
    아래 코드는 Damage: Ignored 를 출력. 추가로 SetActive(false)와 같은 방법으로 비활성화 
    되어있는 GameObject는 메시지를 수신하지 않는다.

    void Start () {
	    gameObject.SendMessage("ApplyDamage", 5.0f);
    }
 
    void ApplyDamage() {
	    Debug.Log ("Damage: Ignored");
    }
 
    void ApplyDamage(float damage) {
	    Debug.Log ("Damage: " + damage);
    }

    //=> 
    Damage: Ignored



    SendMessageUpwards : 기본적으로 SendMessage 와 동일하게 동작하지만 자신(GameObject)를 포함하여 
    부모 GameObject까지 메시지를 전달한다
    기타 비활성화 되어있는 GameObject는 이벤트를 받을 수 없다거나 오버로딩에 정상적으로 대응하지 못하는 
    특성은 SendMessage와 동일.

    원형)
    public void SendMessageUpwards(string methodName, object value = null,
    SendMessageOptions options = SendMessageOptions.RequireReceiver);

    ex1) 두개의 GameObject를 부모 자식 형태로 배치를 했을경우...(RyanParent/RyanChild)

    public class RyanParent : MonoBehaviour {
 
	    void Start () {
	
	    }
 
	    void ApplyDamage(float damage) {
		    Debug.Log ("RyanParent Damage: " + damage);
	    }
    }
 
    public class RyanChild : MonoBehaviour {
 
	    void Start () {
		    gameObject.SendMessageUpwards ("ApplyDamage", 5.0f);
	    }
 
	    void ApplyDamage(float damage) {
		    Debug.Log ("RyanChild Damage: " + damage);
	    }
    }

    //=> 
    RyanChild Damage: 5
    RyanParent Damage: 5


    이 코드의 실행 결과는 RyanChild로 시작하여 부모인 RyanParent까지 전달이 된다.


    BroadcastMessage :SendMessageUpwards와 반대로 동작하는 메소드. 
    BroadcastMessage를 통해 메소드를 호출하게 되면 자기 자신의 GameObject를 포함하여 
    그의 모든 자식 객체들에게 메시지가 전달된다.

    (원형)
    public void BroadcastMessage(string methodName, object parameter = null,
    SendMessageOptions options = SendMessageOptions.RequireReceiver);

    ex) 위와 반대로 부모 GameObject에서 BroadcastMessage를 실행

    public class RyanParent : MonoBehaviour {
 
	    void Start () {
		    gameObject.BroadcastMessage ("ApplyDamage", 5.0f);
	    }
 
	    void ApplyDamage(float damage) {
		    Debug.Log ("RyanParent Damage: " + damage);
	    }
    }
 
    public class RyanChild : MonoBehaviour {
 
	    void Start () {
		
	    }
 
	    void ApplyDamage(float damage) {
		    Debug.Log ("RyanChild Damage: " + damage);
	    }
    }

    //=> 
    RyanParent Damage: 5
    RyanChild Damage: 5

    부모의ApplyDamage가 호출되고 그 다음에 자식의 ApplyDamage가 호출된다.

    SendMessageOptions :위에서 설명한 모든 메소드들의 3번째 인자로 SendMessageOptions 가 있습니다. 
    enum 타입이며 다음과 같은 두가지 타입을 선택할 수 있습니다.

    •RequireReceiver : SendMessage에 대응할 수 있는 수신자가 반드시 있어야 한다.
    •DontRequireReceiver : SendMessage에 대응할 수 있는 수신자가 없어도 괜찮음.

    3번째 파라미터를 지정하지 않아도 기본 값은 RequireReceiver이며 이는 한번 메시지 호출이 발생하면 
    누군가는 그것을 받아서 처리를 해주어야 한다는것을 의미. 만약에 대응되는 메소드가 존재하지 않는다면
    오류가 발생.
    하지만 DontRequireReceiver 는 아무도 처리하지 않아도 문제가 되지 않는다. 
    Optional한 처리를 하는 경우 쓸만한 옵션이다.


 */
