using UnityEngine;
using System.Collections;
using UnityEngine.UI;


    public class MonsterHp : MonoBehaviour
    {
    public GameObject Monster;
    public Image Bar;
    public float Hp;

    void Update()
    {
        Hp = Monster.GetComponent<Boss.Raptor>().hp;
        Bar.fillAmount = Monster.GetComponent<Boss.Raptor>().hp / Hp;
    }


    }

