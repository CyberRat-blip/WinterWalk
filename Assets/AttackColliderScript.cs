using System.Collections;
using UnityEngine;

public class AttackColliderScript : MonoBehaviour
{
    private Collider collider;

    private void Start()
    {
        // �������� ��������� Collider �������
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        // ��������� ������� ����� ������ ����
        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButtonDown(0))
            {
                // �������� ���������
                collider.enabled = true;
                // ��������� ��������, ������� ����� ��������� ��������� ����� 1 �������
                StartCoroutine(DisableCollider());
            }
        }
    }

    private IEnumerator DisableCollider()
    {
        // ���� 1 �������
        yield return new WaitForSeconds(1f);
        // ��������� ���������
        collider.enabled = false;
    }
}