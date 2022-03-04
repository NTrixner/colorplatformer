using System;
using System.Collections;
using System.Collections.Generic;
using Movement;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorShooter : MonoBehaviour
{
    public float TimeDown;

    public bool IsMouseDown;
    
    [SerializeField] private float TimeDownMax;

    [SerializeField] private float MinimumForce;

    [SerializeField] private float MaximumForce;

    [SerializeField] private GameObject ProjectilePrefab;

    private Inputs input;

    private void Start()
    {
        input = FindObjectOfType<Inputs>();
    }

    private void OnPointerDown()
    {
        IsMouseDown = true;
        TimeDown = 0;
    }

    private void OnPointerUp()
    {
        IsMouseDown = false;
        Transform thisTrans = transform;
        Vector3 force = Vector3.Lerp(thisTrans.forward, thisTrans.up, 0.3f) 
                        * (Mathf.Lerp( MinimumForce, MaximumForce,TimeDown / TimeDownMax) + 0.5f);
        GameObject instantiated = Instantiate(ProjectilePrefab);
        instantiated.transform.SetPositionAndRotation(thisTrans.position, thisTrans.rotation);
        Debug.Log("Spawning new Projectile with force " + force);
        instantiated.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }

    private void Update()
    {
        if (input.cursorDown && !IsMouseDown)
        {
            OnPointerDown();
        }
        else if(!input.cursorDown && IsMouseDown)
        {
            OnPointerUp();
        }
        if (IsMouseDown)
        {
            TimeDown = Math.Min(TimeDown + Time.deltaTime, TimeDownMax);
        }
    }
}
