using System;
using Movement;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ColorShooter : MonoBehaviour
{
    [SerializeField] private float TimeDownMax;

    [SerializeField] private float Force;

    [SerializeField] private GameObject ProjectilePrefab;

    [SerializeField] private float spawnInterval = 0.5f;
    
    [SerializeField] private float baseColorCost = 5f;

    [SerializeField] private Color baseColor = Color.green;

    private Inputs input;

    private ThirdPersonController thirdPersonController;
    
    private Vector3 targetPoint;

    private float timeSinceLastSpawn = 0f;

    private PaintBar paintBar;

    private void Start()
    {
        input = FindObjectOfType<Inputs>();
        thirdPersonController = FindObjectOfType<ThirdPersonController>();
        paintBar = FindObjectOfType<PaintBar>();
        baseColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        paintBar.SetColor(baseColor);
    }

    private void FixedUpdate()
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
            if (input.cursorDown && timeSinceLastSpawn >= spawnInterval && paintBar.CanShoot(baseColorCost))
            {
                paintBar.Shoot(baseColorCost);
                Transform thisTrans = transform;
                Vector3 force = direction * Force;
                GameObject instantiated = Instantiate(ProjectilePrefab);
                instantiated.transform.SetPositionAndRotation(thisTrans.position, thisTrans.rotation);
                instantiated.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
                instantiated.GetComponent<Renderer>().material.color = baseColor;
                timeSinceLastSpawn = 0;
            }

            direction.y = thirdPersonController.transform.forward.y;
            thirdPersonController.transform.forward = Vector3.Lerp(thirdPersonController.transform.forward, direction, Time.deltaTime * 20f);
        }
    }
}
