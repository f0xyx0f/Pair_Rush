using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class Level_script : MonoBehaviour
{
    [SerializeField] int n;
    [SerializeField] GameObject[] marks = new GameObject[3];
    private void Start()
    {
        SaveData.LoadGame();
        marksActive(SaveData.ActiveLevels[n]);
    }

    private void marksActive(int m)
    {
        marks[m].SetActive(true);
        foreach (GameObject go in marks.Where(g => Array.IndexOf(marks, g) != m))
            go.SetActive(false);
    }
    public void ChangwLvl(int n) => Level_info.level_num = n;
}
