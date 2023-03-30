using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    public float timeToDisable = 0.8f;
    float timer;

    private void OnEnable()
    {
        timer = timeToDisable;
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0) this.gameObject.SetActive(false);
    }
}
