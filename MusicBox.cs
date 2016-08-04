using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour
{
    public float number;
    private Player player;

    void Awake()
    {
        player = GameObject.Find("Albert2").GetComponent<Player>();
        player.bgm.st();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.bgm.ambient.setValue(number);
        }
    }

    /*void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            player.bgm.ambient.setValue(number);
        }
    }*/
}
