using System;
using Movement;
using UnityEngine;
using UnityEngine.UI;

public class ColorShooter : MonoBehaviour
{
    [SerializeField] private float TimeDownMax;

    [SerializeField] private float Force;

    [SerializeField] private GameObject ProjectilePrefab;

    [SerializeField] private float spawnInterval = 0.5f;

    private Inputs input;

    private ThirdPersonController thirdPersonController;
    
    private Vector3 targetPoint;

    private float timeSinceLastSpawn = 0f;

    private void Start()
    {
        input = FindObjectOfType<Inputs>();
        thirdPersonController = FindObjectOfType<ThirdPersonController>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            targetPoint = raycastHit.point;
        }
        
        timeSinceLastSpawn += Time.deltaTime;
        
        if (input.aim)
        {
            Vector3 direction = Vector3.Normalize(targetPoint - transform.position);
            if (input.cursorDown && timeSinceLastSpawn >= spawnInterval)
            {
                Transform thisTrans = transform;
                Vector3 force = Vector3.Lerp(direction, thisTrans.up, 0.3f) * Force;
                GameObject instantiated = Instantiate(ProjectilePrefab);
                instantiated.transform.SetPositionAndRotation(thisTrans.position + direction, thisTrans.rotation);
                instantiated.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
                timeSinceLastSpawn = 0;
            }

            direction.y = thirdPersonController.transform.position.y;
            thirdPersonController.transform.forward = Vector3.Lerp(thirdPersonController.transform.forward, direction, Time.deltaTime * 20f);
        }
    }
}
