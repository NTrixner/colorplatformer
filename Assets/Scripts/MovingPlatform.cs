using System;
using Movement;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3[] waypoints;
    [SerializeField] private float movementSpeed = 1f;

    private int currentTargetIndex = 0;

    private ThirdPersonController thirdPersonController;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (waypoints.Length >= 2)
        {
            Vector3 currentTarget = waypoints[(currentTargetIndex) % waypoints.Length];
            Vector3 step = (currentTarget - transform.position).normalized * movementSpeed * Time.deltaTime;
            //transform.localPosition = Vector3.MoveTowards(transform.localPosition, currentTarget, step.magnitude);
            if (Vector3.Distance(transform.position + step, currentTarget) <= 0.01f)
            {
                step = currentTarget - transform.position;
            }
            transform.Translate(step);
            if (transform.position == currentTarget)
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