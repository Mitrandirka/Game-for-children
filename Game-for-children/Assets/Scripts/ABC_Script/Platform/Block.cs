using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public Game_Controller_ABC Game_Controller_ABC;
    void Start()
    {
        Game_Controller_ABC = GameObject.FindWithTag("GameController").GetComponent<Game_Controller_ABC>();
    }
}
