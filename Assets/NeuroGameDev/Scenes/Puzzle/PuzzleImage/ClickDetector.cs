using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDetector : MonoBehaviour
{
    public LayerMask uiLayer; // UI �ݶ��̴��� �ִ� ���̾ ����

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� Ŭ��
        {
            // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition = new Vector2(worldMousePos.x, worldMousePos.y);

            // �ݶ��̴��� ����
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0.1f, uiLayer);

            if (hit.collider != null)
            {
                Debug.Log("Ŭ���� UI �ݶ��̴�: " + hit.collider.gameObject.name);
            }
            else
            {
                Debug.Log("UI �ݶ��̴� ����");
            }
        }
    }
}
