using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private float position = 5.0f;
    private float rotationMaxSpeed = 5.0f;
    private float rotationMinSpeed = 1.0f;

    void Start()
    {
        InvokeRepeating("ChangePosition", 1.0f, 3.0f);
        InvokeRepeating("ChangeColor", 1.0f, 3.0f);
    }
    
    void Update()
    {
        ChangeScale();

        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine("RotationCourotine");
        }
    }

    void ChangePosition()
    {
        float randomPosition = Random.Range(-position, position);
        transform.position = new Vector3(randomPosition, randomPosition, randomPosition);
    }

    void ChangeScale()
    {
        transform.localScale = Vector3.one * 2f * Mathf.Sin(Time.time);
    }

    IEnumerator RotationCourotine()
    {
        //Rotate at X Axis
        transform.Rotate(Random.Range(rotationMinSpeed, rotationMaxSpeed), 0.0f, 0.0f);
        yield return new WaitForSeconds(6);
        //Rotate at Y Axis
        transform.Rotate(0.0f, Random.Range(rotationMinSpeed, rotationMaxSpeed), 0.0f);
        yield return new WaitForSeconds(6);
        //Rotate at Z Axis
        transform.Rotate(0.0f, 0.0f, Random.Range(rotationMinSpeed, rotationMaxSpeed));
    }

    void ChangeColor()
    {
        Material material = Renderer.material;

        float randomRed = Random.Range(0.1f, 1.0f);
        float randomGreen = Random.Range(0.1f, 1.0f);
        float randomBlue = Random.Range(0.1f, 1.0f);
        float randomAlpha = Random.Range(0.1f, 1.0f);

        material.color = new Color(randomRed, randomGreen, randomBlue, randomAlpha);
        Invoke("ChangeColor", 3.0f);
    }
}
