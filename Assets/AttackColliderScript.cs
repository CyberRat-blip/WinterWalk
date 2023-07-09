using System.Collections;
using UnityEngine;

public class AttackColliderScript : MonoBehaviour
{
    private Collider collider;

    private void Start()
    {
        // Получаем компонент Collider объекта
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        // Проверяем нажатие левой кнопки мыши
        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Включаем коллайдер
                collider.enabled = true;
                // Запускаем корутину, которая будет выключать коллайдер через 1 секунду
                StartCoroutine(DisableCollider());
            }
        }
    }

    private IEnumerator DisableCollider()
    {
        // Ждем 1 секунду
        yield return new WaitForSeconds(1f);
        // Выключаем коллайдер
        collider.enabled = false;
    }
}