
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Random_slot_script : MonoBehaviour
{
    public Sprite[] sprites;
    public Image[] images;
    void Start()
    {
        Fullfill();
    }

    private void Fullfill()
    {
        do
        {
            Sprite sprt = sprites[Random.Range(0, sprites.Length)];
            for (int i = 0; i < 2; ++i)
            {
                Image img = images[Random.Range(0, images.Length)];
                img.sprite = sprt;
                images = images.Where(x => x != img).ToArray();
            }
            sprites = sprites.Where(x => x != sprt).ToArray();

        } while (images.Length > 0);
    }
}
