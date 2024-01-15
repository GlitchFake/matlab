using UnityEngine;
using TMPro;

public class Bitis : MonoBehaviour
{
    public TextMeshProUGUI bitisText;

    // Start is called before the first frame update
    void Start()
    {
        // Baþlangýçta bitiþ metnini gizle
        bitisText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncu belirli bir bölgeye girdiðinde bitiþ metnini göster
            bitisText.gameObject.SetActive(true);
            bitisText.text = "Tebrikler!\nKazandýnýz!!!";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncu belirli bir bölgeden ayrýldýðýnda bitiþ metnini gizle
            bitisText.gameObject.SetActive(false);
        }
    }
}
