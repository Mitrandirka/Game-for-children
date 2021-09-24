using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platfotm : MonoBehaviour
{
    public GameController GameController;
    public static bool stage;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        startMatirialStage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void startMatirialStage()
    {
        int stageMatirial = Random.Range(0, 2);
        if (stageMatirial == 0)
        {
            stage = false;
            GetComponent<Renderer>().material = GameController.MaterialOne;
        }
        else if (stageMatirial == 1)
        {
            stage = true;
            GetComponent<Renderer>().material = GameController.MaterialTwo;
        }

    }   

    private void OnMouseDown()
    {
        Debug.Log("Нажат");
        if (!stage)
        {
            GetComponent<Renderer>().material = GameController.MaterialTwo;
            stage = true;
        }            
        else
        {
            stage = false;
            GetComponent<Renderer>().material = GameController.MaterialOne;
        }
    }
}
