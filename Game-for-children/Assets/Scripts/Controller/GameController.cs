using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{ 
    [Header("Main")]
    public Material MaterialOne;
    public Material MaterialTwo;

    [Header("Spawn")]
    private Transform Platform;
    public Transform PlatformPrefab;
    private Vector3 defoltPosition;
    private float y, z;
    public int valuePlatform;
    private GameObject[] Platforms;

    [Header("Timer")]
    public float StartTime;
    private float timer;
    public Text GameTimer;


    void Start()
    {
        timer = StartTime;
        spavner(valuePlatform);
    }

    void Update()
    {
        Timer();
    }
    private void spavner(int value) // функция для спафна платформ в зависимости от их количества
    {
        //проверяем количество платформ и выставляем изначальную точку спавна 
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
        //спавним платформы
        for (int i = 0; i < value; i++)
        {
            // если платформ меньше или равно 11 то каждую итерацию мы спавним платформу правее начала с шагом 1
            if (value <= 11)
            {                
                Platform = Instantiate(PlatformPrefab, transform.position + new Vector3(i, 0, 0), Quaternion.identity);
            }
            else if (value <= 22)
            {
                // если платформ меньше или равно 22 то каждую итерацию мы спавним платформу правее начала с шагом 1 до
                // того как дойдём до середины
                if (i < value / 2)
                {
                    Platform = Instantiate(PlatformPrefab, transform.position + new Vector3(i, 0, 0), Quaternion.identity);
                }
                else
                {
                    // после делаем шаг наверх и спавним поновой
                    transform.position = defoltPosition + new Vector3(0, 1, 0);
                    Platform = Instantiate(PlatformPrefab, transform.position + new Vector3(y, 0, 0), Quaternion.identity);
                    y++;
                }
            }
            // аналогично предыдущему, но с тремя этажами
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
        Platforms[] = GameObject.FindGameObjectsWithTag("Platform");
    }

    public void Timer()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
           // timer = StartTime;
        }
        GameTimer.text = Convert.ToString(Math.Round(timer, 2));
    }

    public void LevelController()
    {
        if (timer < 0)
        {
            Time.timeScale = 0;
        }
    }
}
