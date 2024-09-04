using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Slot_script : MonoBehaviour
{
    static float time = 2;
    [SerializeField] Button[] Buttons;
    public bool Paired = false;
    private void OnEnable()
    {
        StartCoroutine(Closing());
        if (GameObject.FindGameObjectsWithTag("Slot").Length >= 2)
        {
            foreach (Button btn in Buttons)
                btn.interactable = false;
            Sprite slot1 = GetComponent<Image>().sprite;
            foreach (GameObject slot0 in GameObject.FindGameObjectsWithTag("Slot").
                Where(x => x.gameObject != gameObject))
                if (slot0.GetComponent<Image>().sprite == slot1)
                {
                    Paired = true;
                    slot0.GetComponent<Slot_script>().Paired = true;
                }
        }
    }
    private IEnumerator Closing()
    {
        yield return new WaitForSeconds(time);
        foreach (Button btn in Buttons.
            Where(x => !x.GetComponentInChildren<Slot_script>(true).Paired))
            btn.interactable = true;
        if (!Paired)
            gameObject.SetActive(false);

    }
}