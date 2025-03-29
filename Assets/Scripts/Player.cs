using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // �÷��̾� �̵� �ӵ� (���� ����)

    // ������ �� ȣ��Ǵ� �Լ�
    void Start()
    {
        // �ʱ� ������ �ʿ��ϸ� ���⼭ ����
        // (��: Rigidbody�� Component �������� ��)
    }

    // �� ������(frame)���� ȣ��Ǵ� ������Ʈ �Լ�
    void Update()
    {
        // 1. �Է�(Input) �� ���
        float moveX = Input.GetAxis("Horizontal"); // �¿� ���� Ű �Է� (-1.0 ~ 1.0)
        float moveZ = Input.GetAxis("Vertical");   // �յ� ���� Ű �Է� (-1.0 ~ 1.0)

        // 2. �̵� ���� ���
        Vector3 movement = new Vector3(moveX, 0, moveZ);
        // �������� X������ �¿�, Z������ �յ� �������� ����. Y���� 0���� ���� (���� ����).

        // 3. ����ȭ �� �ӵ� ����
        if (movement.magnitude > 1)
            movement = movement.normalized;
        // movement ������ ���̰� 1���� ũ�ٸ�(normalized�Ͽ�) ���⸸ ����� ũ�⸦ 1�� ����.
        // �̷��� �ϸ� �밢�� �̵��� �ӵ��� �������� �ʵ��� ����.

        movement *= speed * Time.deltaTime;
        // �̵� ���Ϳ� �ӵ��� Time.deltaTime�� ���ؼ�, �����Ӱ� ������� ������ �ӵ��� �̵��ϰ� ��.

        // 4. ���� �̵� ����
        transform.Translate(movement, Space.World);
        // Space.World �������� �̵��Ͽ�, ���� ��ǥ�迡�� �����̵��� ��.
        // (���� ĳ���Ͱ� ���� ���� �������� �̵��Ϸ��� Space.Self ��� �Ǵ� ī�޶� ������ ����ؾ� ��)
    }
}