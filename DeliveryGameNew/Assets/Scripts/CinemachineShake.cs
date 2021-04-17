using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    private CinemachineVirtualCamera CVC;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startIntesnsity;
    private void Awake()
    {
        Instance = this;
        CVC = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin CBMCP = CVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        CBMCP.m_AmplitudeGain = intensity;

        startIntesnsity = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer<= 0f)
            {
                CinemachineBasicMultiChannelPerlin CBMCP = CVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                CBMCP.m_AmplitudeGain = Mathf.Lerp(startIntesnsity, 0f, 1-(shakeTimer / shakeTimerTotal));

                
            }
        }
    }
}
