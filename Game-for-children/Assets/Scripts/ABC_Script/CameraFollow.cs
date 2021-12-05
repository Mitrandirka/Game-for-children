using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject Plauer;
    [SerializeField] private Vector3 Disttance;

    private void LateUpdate()
    {
        Plauer = GameObject.FindWithTag("Player");
        Vector3 positionToGo = Plauer.transform.position + Disttance;
        Vector3 smootPPosition = Vector3.Lerp(a: transform.position, b: positionToGo, t: 8f);
        transform.position = smootPPosition;
    }

}
