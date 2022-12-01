using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControl : MonoBehaviour
{
    //este es el panel dnde aparece la vida
    public GameObject life;
    MovementMain player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovementMain>();


    }

    // Update is called once per frame
    void Update()
    {
        life.GetComponent<Text>().text = player.lifePlayer + " puntos";
    }
}
