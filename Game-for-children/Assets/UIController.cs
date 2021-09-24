using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameController GameController;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGameButton()
    {

    }
}
