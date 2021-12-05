using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game_Controller_ABC : MonoBehaviour
{
    [Header("Main")]
    private int startPositinon;
    private Transform Finish;
    public Transform FinishPref;
    public static bool vin;

    [Header("Player")]
    public Transform PlayerPrefab;
    private Transform Player;
    [SerializeField] public static float Speed;
    public static float Direction;

    [Header("Platfotm")]
    public Transform PlatformPrefab;
    private Transform Platform;
    public int LengthPlatform;

    [Header("Block")]
    private char[] Words;
    public string[] Dictionary;
    public Transform BlockPrefab;
    private Transform Block;
    public  GameObject[] BlockABS;
    private float waitTime = 0.5f;
    private int i, j, x = 0;// фигня для переборки массива

    [Header("UI")]
    public Transform WordUI;
    public float timer;

    [Header("Key")]
    TouchScreenKeyboard claviar;


    private void Awake()
    {
        WorldGenerator();
        PlayerMove();
        WordGenerator();
        //Player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        OpenKeyboard();
        vin = false;
        Speed = 2;
        BlockABS = GameObject.FindGameObjectsWithTag("ABC");
        Array.Reverse(BlockABS);
        i = Words.Length;
        j = 0;
        for (int i = 0; i < Dictionary.Length; i++)
        {
            x += Dictionary[i].ToCharArray().Length;
        } 
    }
    private void Update()
    {
        ReadSymbol();
        Timer();
    }

    public void OpenKeyboard()
    {
        claviar = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
    public void WordGenerator()
    {
        for (int i = 0; i < Dictionary.Length; i++)
        {
            Translitor(i);
            //задаём начальную координату 
            startPositinon += UnityEngine.Random.Range(7, 10) + Words.Length;
            for (int j = Words.Length; j > 0; j--)
            {
                //спавним и указываем тексту значение чара
                Block = Instantiate(BlockPrefab, transform.position + new Vector3(startPositinon, j, 0), Quaternion.identity);
                Block.transform.GetChild(0).GetComponent<TextMesh>().text = char.ToString(Words[j - 1]);
            }
            for (int x = 0; x < LengthPlatform; x++)
            {
                Platform = Instantiate(PlatformPrefab, transform.position + new Vector3(startPositinon + x, 0, 0), Quaternion.identity);
            }
        }
    }
    private void Translitor(int i)
    {
        //Берем слово из словоря и разбиваем н =а символе 
        if (i <= Dictionary.Length)
        {
            Words = Dictionary[i].ToCharArray();
            //Переворачиваем массив
            Array.Reverse(Words);
        }
    }
    public void PlayerMove()
    {
        //Создаём игрока на уровне 
        Player = Instantiate(PlayerPrefab, transform.position + new Vector3(0, 1.21f, 0), Quaternion.identity);
    }

    public void WorldGenerator()
    {
        //С колличеством задаваймым в инспекторе 
        for (int i = 0; i < LengthPlatform; i++)
        {
            //Создаём платформу
            Platform = Instantiate(PlatformPrefab, transform.position + new Vector3(i, 0, 0), Quaternion.identity);
        }
    }
    public void ReadSymbol()
    {
        if (i <= 0)
        {
            j++;
            if (j > Dictionary.Length)
            {
                Victory();
            }
            Translitor(j);
            i = Words.Length;
        }
        else
        {
            Translitor(j);
            PrintWordUi(j);
            var input = Input.inputString;
            if (!string.IsNullOrEmpty(input))
            {
                if (Input.inputString == char.ToString(Words[i - 1]))
                {
                    StartCoroutine(DestroyABS(waitTime, x));
                    BlockABS[x - 1].GetComponent<Renderer>().material.color = new Color(100, 0, 0);
                    Debug.Log("Destroy: " + BlockABS[x - 1]);
                    x--;
                    i--;
                }
                Debug.Log("Pressed char: " + Input.inputString);
            }
        }
    }
    IEnumerator DestroyABS(float waitTime, int i)
    {
        //удаляем блок 
        yield return new WaitForSeconds(waitTime);
        Destroy(BlockABS[i - 1]);
    }
    private void Victory()
    {
        Finish = Instantiate(FinishPref, Player.transform.position + new Vector3(32, 1, 0), Quaternion.identity);
        Finish.transform.Rotate(0, 0, 90); 
        WordUI.transform.GetChild(0).GetComponent<Text>().text = "Победа";
        Time.timeScale = 0.1f;
        vin = true;
    }

    public void PrintWordUi(int j)
    {
        if (j <= Dictionary.Length)
        {
            WordUI.transform.GetChild(0).GetComponent<Text>().text = Dictionary[j];
        }
    }
    public void Timer()
    {
        if (timer > 0 )
        {
            timer -= Time.deltaTime;
            if (timer < 10)
            {
                WordUI.transform.GetChild(1).GetComponent<Text>().color = Color.red;
            }
        }
        WordUI.transform.GetChild(1).GetComponent<Text>().text = Convert.ToString(Math.Round( timer, 0));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Time.timeScale = 0;
        }
    }
}
