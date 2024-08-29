using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Management_script : MonoBehaviour
{
    public void LoadLvl(int n) => SceneManager.LoadScene(n);
}
