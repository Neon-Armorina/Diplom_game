using FSM.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetection : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Character character;

    private bool _canDetect = true;

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            _canDetect = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            _canDetect = true;
    }

    private void Update()
    {
        if (_canDetect == true)
            character.LedgeDetected = Physics2D.OverlapCircle(transform.position, _radius, _whatIsGround);
        else
            character.LedgeDetected = false;
    }
}
