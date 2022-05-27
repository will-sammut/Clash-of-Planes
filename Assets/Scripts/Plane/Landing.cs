using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Landing : MonoBehaviour
{
    public bool landing { private set; get; } = false;
    public UnityEvent onLand;
    private SpriteRenderer spriteRenderer;
    private Transform planeTransform;

    private float timeElapsed;
    private float initScale;
    [SerializeField] private float landDuration;

    [SerializeField] private AudioSource landingSound;
    private bool Triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        planeTransform = GetComponent<Transform>();
        initScale = planeTransform.localScale.x;
        timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (landing)
        {
            if (!Triggered)
            {
                landingSound.Play();
                Triggered = true;
            }
            float lerpTime = timeElapsed / landDuration;
            spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, lerpTime));
            planeTransform.localScale = new Vector3(Mathf.Lerp(initScale, 0f, lerpTime), Mathf.Lerp(initScale, 0f, lerpTime), Mathf.Lerp(initScale, 0f, lerpTime));
            timeElapsed += Time.deltaTime;
            if (timeElapsed > landDuration)
            {
                Destroy(gameObject);
            }
        }
    }

    public void LandPlane()
    {
        landing = true;
    }

    private void Trigger() => onLand.Invoke();
}
