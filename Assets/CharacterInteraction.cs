using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    // Переменная для хранения ссылки на UI панель с подсказкой
    public GameObject pickupUI;

    // Ссылка на персонажа
    public GameObject character;

    // Расстояние, на котором подсказка будет скрываться
    public float hideDistance = 2f;

    private void Update()
    {
        // Проверяем наличие предметов с тэгом "Pickup" рядом с персонажем
        Collider[] nearbyPickups = Physics.OverlapSphere(character.transform.position, hideDistance);
        bool foundPickup = false;

        foreach (Collider pickup in nearbyPickups)
        {
            if (pickup.CompareTag("Pickup"))
            {
                foundPickup = true;
                break;
            }
        }

        // Проверяем, нашелся ли предмет рядом с персонажем
        if (foundPickup)
        {
            // Предмет найден, скрываем подсказку
            pickupUI.SetActive(true);
        }
        else
        {
            // Предмет не найден, отображаем подсказку
            pickupUI.SetActive(false);
        }
    }
}



