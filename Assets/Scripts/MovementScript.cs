using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementScript : MonoBehaviour
{
    [Header("Plane Settings")]
    [Range(1f, 20f)]
    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlaneObject plane;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Path Settings")]
    [SerializeField] private float minDrawDistance = 1f;
    [SerializeField] private float followDistance = 1f;

    private List<Vector2> points = new List<Vector2>();
    private Vector2 lastPoint;
    // private Vector2 lastPositionReatched;

    private Vector2 velocityDirection = new Vector2(0f, 1f);

    // private Vector2 target;

    private void OnMouseDown()
    {
        //Debug.Log("Start Drag");
        lastPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Clear();
    }

    private void OnMouseDrag()
    {
        Debug.Log("Drag");
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPoint, mousePos) > minDrawDistance)
        {
            points.Add(mousePos);
            lastPoint = mousePos;
        }
    }

    private void Start()
    {
        if (plane != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = plane.sprite;
            speed = plane.speed;
        }

        RandomDirection();
    }

    private void RandomDirection()
    {
        velocityDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void Update()
    {
        if (points.Count > 0)
        {
            ChangeDirection(points[0]);
            if (Vector2.Distance(transform.position, points[0]) < followDistance)
            {
                // lastPositionReatched = points[0];
                points.RemoveAt(0);
            }

        }
        Vector2 target = velocityDirection;
        float rotZ = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);

        rb.velocity = velocityDirection * speed;
    }

    public static float Angle(Vector2 vector2)
    {
        return 360 - (Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg * Mathf.Sign(vector2.x));
    }

    private void ChangeDirection(Vector2 target)
    {
        velocityDirection = ((Vector2)transform.position - target).normalized * -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.DrawLine(transform.position, target);

        if (points == null) return;
        Gizmos.color = Color.red;
        foreach (Vector2 point in points)
        {
            Gizmos.DrawSphere(point, 0.1f);
        }
    }
}
