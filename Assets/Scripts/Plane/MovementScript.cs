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
    [SerializeField] private Landing planeLanding;

    private Vector2 velocityDirection = new Vector2(0f, 1f);
    private Vector2 lastVelocityDirection = Vector2.zero;
    private bool isFollowing = false;
    private List<Vector2> points = new List<Vector2>();
    private Vector2 lastPoint;
    private Vector2 myLastReached = Vector2.zero;
    private bool canDraw = true;

    private void Start()
    {
        // Load data from Scriptable Object
        if (plane != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = plane.sprite;
            speed = plane.speed;
            transform.localScale = new Vector3(plane.size, plane.size, plane.size);
            if (!string.IsNullOrEmpty(plane.tag))
            {
                gameObject.tag = plane.tag;
            }
        }

        // Start Up
        // RandomDirection();
    }

    private void Update()
    {
        Vector2 target;

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

            target = AngleSmoother();

            // Follow points and remove them
            ChangeDirection(points[0]);
            if (Vector2.Distance(transform.position, points[0]) < followDistance)
            {
                myLastReached = transform.position;
                lastVelocityDirection = velocityDirection;
                points.RemoveAt(0);
            }
        }
        else
        {
            isFollowing = false;

            target = velocityDirection;

            // Clean up LineRenderer
            lineRenderer.positionCount = 0;
        }

        // Move and rotate to target direction
        float rotZ = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);

        rb.velocity = velocityDirection * speed;
    }

    private void OnDestroy()
    {
        if (planeLanding == null)
        {
            Debug.LogWarning($"<color=cyan>MovementScript.cs</color> : No planeLanding set!");
            gameMangement.EndGame();
            return;
        }

        if (planeLanding.landing)
        {
            gameMangement.AmendScore(plane.pointScore);
        }
        else
        {
            gameMangement.EndGame();
        }
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
        if (gameMangement.isPaused) return;
        // Setup draw.
        lastPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Clear();
        canDraw = true;
        if (gameMangement != null)
        {
            gameMangement.planeSelected = plane;
        }
        else
        {
            Debug.LogWarning($"<color=cyan>MovementScript.cs</color> : No game mangement set!", gameObject);
        }
    }

    private void OnMouseDrag()
    {
        if (gameMangement.isPaused)
        {
            canDraw = false;
            return;
        }
        // Draws and stores points.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (canDraw && Vector2.Distance(lastPoint, mousePos) > minDrawDistance && points.Count < maxLinePoints)
        {
            points.Add(mousePos);
            lastPoint = mousePos;

            if (points.Count >= maxLinePoints)
            {
                canDraw = false;
            }
        }
    }
    #endregion

    private void RandomDirection()
    {
        velocityDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    public void ChangeDirection(Vector2 target)
    {
        velocityDirection = ((Vector2)transform.position - target).normalized * -1;
    }

    public void SetPlaneObject(PlaneObject p)
    {
        plane = p;
    }

    public void BounceHorizontal()
    {
        points.Clear();
        canDraw = false;
        velocityDirection.x *= -1;
    }
    public void BounceVertical()
    {
        points.Clear();
        canDraw = false;
        velocityDirection.y *= -1;
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

        //if (points.Count > 0)
        //{
        //    Gizmos.color = Color.yellow;
        //    Gizmos.DrawLine(myLastReached, points[0]);

        //    Gizmos.color = Color.blue;
        //    Gizmos.DrawLine(transform.position, points[0]);

        //    Gizmos.color = Color.magenta;
        //    Vector2 target = AngleSmoother();
        //    Gizmos.DrawLine(transform.position, target);

        //    Gizmos.color = Color.white;
        //    Gizmos.DrawLine(transform.position, velocityDirection);
        //}
    }
    #endregion

    private Vector2 AngleSmoother()
    {
        float max = Vector2.Distance(myLastReached, points[0]) - followDistance;
        float current = Vector2.Distance(transform.position, points[0]) - followDistance;
        float time = Mathf.Clamp01(((max - current) / max));
        //Debug.Log($"{lastVelocityDirection} -> {velocityDirection}");
        return Vector2.Lerp(lastVelocityDirection, velocityDirection, time);
    }
}
