using UnityEngine;
using TMPro;

public class Bitis : MonoBehaviour
{
    public TextMeshProUGUI bitisText;

    // Start is called before the first frame update
    void Start()
    {
        // Ba�lang��ta biti� metnini gizle
        bitisText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncu belirli bir b�lgeye girdi�inde biti� metnini g�ster
            bitisText.gameObject.SetActive(true);
            bitisText.text = "Tebrikler!\nKazand�n�z!!!";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncu belirli bir b�lgeden ayr�ld���nda biti� metnini gizle
            bitisText.gameObject.SetActive(false);
        }
    }
}
