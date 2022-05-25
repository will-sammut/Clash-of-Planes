using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementScript : MonoBehaviour, ILandable
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
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int maxLinePoints = 100;

    [Header("Other")]
    [SerializeField] private GameMangement gameMangement;

    private List<Vector2> points = new List<Vector2>();
    private Vector2 lastPoint;
    private Vector2 velocityDirection = new Vector2(0f, 1f);
    private bool isFollowing = false;

    private void Start()
    {
        // Load data from Scriptable Object
        if (plane != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = plane.sprite;
            speed = plane.speed;
            transform.localScale = new Vector3(plane.size, plane.size, plane.size);
        }

        // Start Up
        RandomDirection();
    }

    private void Update()
    {
        // This happens if drawing line
        if (points.Count > 0)
        {
            isFollowing = true;
            // Turn Vector2 List into Vector3 Array for LineRenderer
            List<Vector3> newPos = new List<Vector3>();
            newPos.Add(transform.position);
            foreach (Vector2 point in points)
            {
                newPos.Add(point);
            }

            lineRenderer.positionCount = newPos.Count;
            lineRenderer.SetPositions(newPos.ToArray());

            // Follow points and remove them
            ChangeDirection(points[0]);
            if (Vector2.Distance(transform.position, points[0]) < followDistance)
            {
                points.RemoveAt(0);
            }
        }
        else
        {
            isFollowing = false;
            // Clean up LineRenderer
            lineRenderer.positionCount = 0;
        }

        // Move and rotate to target direction 
        Vector2 target = velocityDirection;
        float rotZ = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);

        rb.velocity = velocityDirection * speed;
    }

    #region Interface
    public bool IsLanding()
    {
        return isFollowing;
    }
    #endregion

    #region Movement Interactions 
    private void OnMouseDown()
    {
        // Setup draw.
        lastPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Clear();
        gameMangement.planeSelected = plane;
    }

    private void OnMouseDrag()
    {
        // Draws and stores points.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPoint, mousePos) > minDrawDistance && points.Count < maxLinePoints)
        {
            points.Add(mousePos);
            lastPoint = mousePos;
        }
    }
    #endregion

    private void RandomDirection()
    {
        velocityDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void ChangeDirection(Vector2 target)
    {
        velocityDirection = ((Vector2)transform.position - target).normalized * -1;
    }

    #region Gizmos
    private void OnDrawGizmos()
    {
        if (points == null) return;
        Gizmos.color = Color.red;
        foreach (Vector2 point in points)
        {
            Gizmos.DrawSphere(point, 0.1f);
        }

        //Gizmos.color = Color.yellow;
        //Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Gizmos.DrawLine(transform.position, target);
    }
    #endregion
}
