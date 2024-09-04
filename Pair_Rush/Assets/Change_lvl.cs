using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Change_lvl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] texts;
    private void Start()
    {
        texts[0].text = "Level " + Level_info.level_num + 1;
        TimeSpan time = TimeSpan.FromMinutes(1 / (Level_info.level_num + 1));
        texts[1].text = '0' + time.Minutes.ToString() + ":0" + time.Seconds.ToString();
    }
}
