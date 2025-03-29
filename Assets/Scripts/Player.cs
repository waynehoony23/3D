using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // 플레이어 이동 속도 (조절 가능)

    // 시작할 때 호출되는 함수
    void Start()
    {
        // 초기 설정이 필요하면 여기서 수행
        // (예: Rigidbody나 Component 가져오기 등)
    }

    // 매 프레임(frame)마다 호출되는 업데이트 함수
    void Update()
    {
        // 1. 입력(Input) 값 얻기
        float moveX = Input.GetAxis("Horizontal"); // 좌우 방향 키 입력 (-1.0 ~ 1.0)
        float moveZ = Input.GetAxis("Vertical");   // 앞뒤 방향 키 입력 (-1.0 ~ 1.0)

        // 2. 이동 벡터 계산
        Vector3 movement = new Vector3(moveX, 0, moveZ);
        // 위에서는 X축으로 좌우, Z축으로 앞뒤 움직임을 설정. Y축은 0으로 고정 (점프 없음).

        // 3. 정규화 및 속도 적용
        if (movement.magnitude > 1)
            movement = movement.normalized;
        // movement 벡터의 길이가 1보다 크다면(normalized하여) 방향만 남기고 크기를 1로 맞춤.
        // 이렇게 하면 대각선 이동시 속도가 빨라지지 않도록 조정.

        movement *= speed * Time.deltaTime;
        // 이동 벡터에 속도와 Time.deltaTime을 곱해서, 프레임과 관계없이 일정한 속도로 이동하게 함.

        // 4. 실제 이동 적용
        transform.Translate(movement, Space.World);
        // Space.World 기준으로 이동하여, 월드 좌표계에서 움직이도록 함.
        // (만약 캐릭터가 보는 방향 기준으로 이동하려면 Space.Self 사용 또는 카메라 방향을 고려해야 함)
    }
}