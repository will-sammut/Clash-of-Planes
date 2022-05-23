using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementScript : MonoBehaviour
{
    [Header("Plane Settings")]
    [Range(1f, 20f)]
    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 test = new Vector2(0f, 1f);

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            test = new Vector2(transform.position.x - target.x, transform.position.y - target.y).normalized * -1;
        }
        
        rb.velocity = test * speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.DrawLine(transform.position, target);
    }
}
