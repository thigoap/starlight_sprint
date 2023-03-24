using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    float shakeDistance = 0.2f;
    float shakeSpeed = 10 ;
    float shakeTime = 0.25f;

    Vector3 initialPosition;
    Vector3 shakeOffset;

    bool isShaking = false;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Update()
    {
        if (isShaking)
        {
            Vector3 pos = transform.position;
            Vector3 offsetPos = pos + shakeOffset;
            float currentDistance = offsetPos.y - initialPosition.y;
            if (shakeSpeed >= 0)
            {
                if (currentDistance > shakeDistance)
                {
                    shakeSpeed *= -1;
                }
            }
            else
            {
                if (currentDistance < -shakeDistance)
                {
                    shakeSpeed *= -1;
                }
            }
            shakeOffset.y += shakeSpeed * Time.deltaTime;
            if (shakeOffset.y > shakeDistance) shakeOffset.y = shakeDistance;
            if (shakeOffset.y < -shakeDistance) shakeOffset.y = -shakeDistance;
            transform.position = initialPosition + shakeOffset;
        }
    }

    public void StartShaking()
    {
        isShaking = true;
        StartCoroutine(StopShaking());
    }

    IEnumerator StopShaking()
    {
        yield return new WaitForSeconds(shakeTime);
        isShaking = false;
        transform.position = initialPosition;
        if (GameManager.Instance.gameOver)
            Time.timeScale = 0.0f;
    }
    
}
