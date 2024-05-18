using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_counter : MonoBehaviour
{
    private Collider2D _floorCollider;

    private void Start()
    {
        _floorCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Character_Stats.Instance.AddFloor();
            _floorCollider.enabled = false;
        }
    }
}
