using System;
using Movement;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3[] waypoints;
    [SerializeField] private float movementSpeed = 1f;

    public int currentTargetIndex = 0;
    public Vector3 currentTarget;

    private ThirdPersonController thirdPersonController;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (waypoints.Length >= 2)
        {
            currentTarget = waypoints[(currentTargetIndex) % waypoints.Length];
            Vector3 step = (currentTarget - transform.position).normalized * movementSpeed * Time.deltaTime;
            //transform.localPosition = Vector3.MoveTowards(transform.localPosition, currentTarget, step.magnitude);
            transform.Translate(step);
            if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
            {
                currentTargetIndex = (currentTargetIndex + 1) % waypoints.Length;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<ThirdPersonController>())
            collision.transform.parent = transform;

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<ThirdPersonController>() != null)
            collision.transform.parent = null;
    }
}