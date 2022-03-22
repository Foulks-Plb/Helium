using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing_TEST : MonoBehaviour
{
    public Transform weaponPos;

    GameObject Projectile;
    Rigidbody2D Projectile_rb;
    Transform target;

    public float h = 2;
    public float gravity = -9.81f;

    private Vector2 startPos, launchPos, direction;


    public GameObject proj_test;

    public Animator arm_anim;

    public GameObject TrajectoryParent;
    public GameObject trajectoryPointPrefab;
    public int resolution = 15;

    bool isDragging;

    public Gameplay GameplayInfo;
    bool startToggle = false;
    public bool playing;

    // Start is called before the first frame update
    void Start()
    {
        launchPos = weaponPos.position;
        target = this.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            if (!startToggle)
            {
                startToggle = true;
                for (int i = 0; i < resolution; i++)
                {
                    Instantiate(trajectoryPointPrefab, TrajectoryParent.transform);
                }
            }

            if (Input.touchCount > 0)
            {

                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        isDragging = true;
                        OnDragStart();

                        break;

                    case TouchPhase.Moved:
                        OnDrag();

                        break;

                    case TouchPhase.Ended:
                        isDragging = false;
                        OnDragEnd();

                        break;
                }

            }

            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                OnDragEnd();
            }

            if (isDragging)
            {
                OnDrag();
            }

            DrawPath();
        }
        else
        {
            target.position = launchPos;

            for (int i = 0; i < TrajectoryParent.transform.childCount; i++)
            {
                Object.Destroy(TrajectoryParent.transform.GetChild(i).gameObject);
            }

            startToggle = false;
        }
    }

    void objTrow()
    {

        Physics.gravity = Vector2.up * gravity;
        Projectile_rb.velocity = CalculateLaunchData().initialVelocity;
        //print(CalculateLaunchVelocity());


    }

    //  ----=== Calcul de la trajectoire ===----

    Vector2 CalculateLaunchVelocity()
    {
        float displacementY = target.position.y - Projectile.transform.position.y;
        Vector2 displacementXZ = new Vector2(target.position.x - Projectile.transform.position.x, 0);

        Vector2 velocityY = Vector2.up * Mathf.Sqrt(Mathf.Abs(-2 * gravity * h));
        Vector2 velocityX = displacementXZ / (Mathf.Sqrt(Mathf.Abs(-2 * h / gravity)) + Mathf.Sqrt(Mathf.Abs(2 * (displacementY - h) / gravity)));

        return velocityX + velocityY;
    }

    launchData CalculateLaunchData()
    {
        float displacementY = target.position.y - launchPos.y;
        Vector2 displacementXZ = new Vector2(target.position.x - launchPos.x, 0);
        float time = Mathf.Sqrt(Mathf.Abs(-2 * h / gravity)) + Mathf.Sqrt(Mathf.Abs( 2 * (displacementY - h) / gravity));
        Vector2 velocityY = Vector2.up * Mathf.Sqrt(Mathf.Abs(-2 * gravity * h));
        Vector2 velocityX = displacementXZ / time;

        return new launchData(velocityX + velocityY, time);
    }

    private void DrawPath()
    {
        launchData LaunchData = CalculateLaunchData();
        Vector3 previousDrawPoint = launchPos;

        for (int i = 0; i < TrajectoryParent.transform.childCount ; i++)
        {
            float simulationTime = i / (float)resolution * .5f;
            Vector2 displacement = LaunchData.initialVelocity * simulationTime + Vector2.up * gravity * simulationTime * simulationTime / 2f;
            Vector3 drawPoint = new Vector3(launchPos.x, launchPos.y, 0) + new Vector3(displacement.x, displacement.y, 0);
            TrajectoryParent.transform.GetChild(i).position = drawPoint;
            TrajectoryParent.transform.GetChild(i).localScale = Vector3.one * ( Mathf.Pow(.92f, i + 2) / 1.5f);
        }


    }

    struct launchData
    {
        public readonly Vector2 initialVelocity;
        public readonly float timeToTarget;

        public launchData(Vector2 initialVelocity, float timeToTarget)
        {
            this.initialVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;
        }

    }

    void OnDragStart()
    {
        startPos = Camera.main.ScreenToWorldPoint( Input.mousePosition);

    }
    void OnDrag()
    {
        direction = (Vector2.one * Camera.main.ScreenToWorldPoint( Input.mousePosition) * 1.5f) - startPos;
        transform.position = launchPos + (direction) * -1;
        h = target.position.y - launchPos.y + ( Vector2.Distance(startPos, target.position) / 100);

        arm_anim.SetFloat("x", Mathf.Clamp(TrajectoryParent.transform.GetChild(TrajectoryParent.transform.childCount / 4).localPosition.x, -1, 1) * -1);
        arm_anim.SetFloat("y", Mathf.Clamp(TrajectoryParent.transform.GetChild(TrajectoryParent.transform.childCount / 4).localPosition.y, -1, 1) * -1);
    }
    void OnDragEnd()
    {
        Projectile = Instantiate(proj_test, weaponPos.position, Quaternion.Euler(Vector3.zero));
        Projectile_rb = Projectile.GetComponent<Rigidbody2D>();
        objTrow();

        arm_anim.SetFloat("x", arm_anim.GetFloat("x") * -1);
        arm_anim.SetFloat("y", arm_anim.GetFloat("y") * -1);
    }
}
