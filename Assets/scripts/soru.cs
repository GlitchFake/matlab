using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LabirentSoru : MonoBehaviour
{
    public TextMeshProUGUI soruText;
    public TextMeshProUGUI dogruCevapText;
    public TextMeshProUGUI yanlisCevapText;
 

    void Start()
    {
        // Diðer baþlangýç kodlarý...

        // Matematik sorusu ve cevaplarý rasgele üret
        MatematikSorusuVeCevaplariUret();
    }

    void MatematikSorusuVeCevaplariUret()
    {
        // Rasgele sayýlar üret
        int sayi1 = Random.Range(1, 10);
        int sayi2 = Random.Range(1, 10);

        // Matematik sorusunu oluþtur
        string matematikSorusu = $"{sayi1} + {sayi2} = ?";

        // Doðru cevap ve yanlýþ cevaplarý hesapla
        int dogruCevap = sayi1 + sayi2;
        int yanlisCevap = dogruCevap + Random.Range(1, 5); // Yanlýþ cevap biraz farklý olsun

        // Soru ve cevaplarý ekrana yazdýr
        soruText.text = matematikSorusu;
        dogruCevapText.text = dogruCevap.ToString();
        yanlisCevapText.text = yanlisCevap.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncu labirent sorusu ile karþýlaþtýðýnda matematik soru UI elemanlarýný aktifleþtir
            soruText.gameObject.SetActive(true);
            dogruCevapText.gameObject.SetActive(true);
            yanlisCevapText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncu labirent sorusunu geçtiðinde UI elemanlarýný deaktifleþtir
            soruText.gameObject.SetActive(false);
            dogruCevapText.gameObject.SetActive(false);
            yanlisCevapText.gameObject.SetActive(false);

            // Yeni bir soru üret
            MatematikSorusuVeCevaplariUret();
        }
    }

    // Diðer kodlar...
}