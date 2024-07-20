using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float healthPoints = 100f;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private GameObject explodePrefab;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with: " + other.name);
        
        if (other.CompareTag("Obstacle"))
        {
            Instantiate(explodePrefab, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            healthPoints -= 10f;
            if (healthPoints <= 0)
            {
                SceneManager.LoadScene("Lose");
            }
            healthText.SetText(healthPoints + "");
        }
    }
}
