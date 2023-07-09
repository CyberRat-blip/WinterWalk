using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    // ���������� ��� �������� ������ �� UI ������ � ����������
    public GameObject pickupUI;

    // ������ �� ���������
    public GameObject character;

    // ����������, �� ������� ��������� ����� ����������
    public float hideDistance = 2f;

    private void Update()
    {
        // ��������� ������� ��������� � ����� "Pickup" ����� � ����������
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

        // ���������, ������� �� ������� ����� � ����������
        if (foundPickup)
        {
            // ������� ������, �������� ���������
            pickupUI.SetActive(true);
        }
        else
        {
            // ������� �� ������, ���������� ���������
            pickupUI.SetActive(false);
        }
    }
}



