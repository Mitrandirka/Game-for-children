using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Transform Platform;
    public Transform PlatformPrefab;
    private Vector3 defoltPosition;
    private float y, z;


    public Material MaterialOne;
    public Material MaterialTwo;

    public int valuePlatform;
    // Start is called before the first frame update
    void Start()
    {
        spavner(valuePlatform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void spavner(int value)
    {
        if (value <= 11)
            transform.position += new Vector3(-value / 2, 0, 2);
        else if (value <= 22)
        {
            transform.position += new Vector3(-value / 4, 0, 1);
            defoltPosition = transform.position;
            value = value - (value % 2);
        }
        else if (value <= 34)
        {
            transform.position += new Vector3(-value / 8, 0, 0);
            defoltPosition = transform.position;
            value = value - (value % 3);
        }            
        for (int i = 0; i < value; i++)
        {
            if (value <= 11)
            {                
                Platform = Instantiate(PlatformPrefab, transform.position + new Vector3(i, 0, 0), Quaternion.identity);
            }
            else if (value <= 22)
            {
                if (i < value / 2)
                {
                    Platform = Instantiate(PlatformPrefab, transform.position + new Vector3(i, 0, 0), Quaternion.identity);
                }
                else
                {
                    transform.position = defoltPosition + new Vector3(0, 1, 0);
                    Platform = Instantiate(PlatformPrefab, transform.position + new Vector3(y, 0, 0), Quaternion.identity);
                    y++;
                }
            }
            else if (value <= 33)
            {
                if (i < value / 3)
                {
                    Platform = Instantiate(PlatformPrefab, transform.position + new Vector3(i, 0, 0), Quaternion.identity);
                }
                else if (i > value / 3 && i <= value / 3 * 2)
                {
                    transform.position = defoltPosition + new Vector3(0, 1, 0);
                    Platform = Instantiate(PlatformPrefab, transform.position + new Vector3(y, 0, 0), Quaternion.identity);
                    y++;
                }
                else 
                {
                    transform.position = defoltPosition + new Vector3(0, 2, 0);
                    Platform = Instantiate(PlatformPrefab, transform.position + new Vector3(z, 0, 0), Quaternion.identity);
                    z++;
                }
            }
        }
    }
}
