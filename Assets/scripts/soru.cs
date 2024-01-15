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
        // Di�er ba�lang�� kodlar�...

        // Matematik sorusu ve cevaplar� rasgele �ret
        MatematikSorusuVeCevaplariUret();
    }

    void MatematikSorusuVeCevaplariUret()
    {
        // Rasgele say�lar �ret
        int sayi1 = Random.Range(1, 10);
        int sayi2 = Random.Range(1, 10);

        // Matematik sorusunu olu�tur
        string matematikSorusu = $"{sayi1} + {sayi2} = ?";

        // Do�ru cevap ve yanl�� cevaplar� hesapla
        int dogruCevap = sayi1 + sayi2;
        int yanlisCevap = dogruCevap + Random.Range(1, 5); // Yanl�� cevap biraz farkl� olsun

        // Soru ve cevaplar� ekrana yazd�r
        soruText.text = matematikSorusu;
        dogruCevapText.text = dogruCevap.ToString();
        yanlisCevapText.text = yanlisCevap.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncu labirent sorusu ile kar��la�t���nda matematik soru UI elemanlar�n� aktifle�tir
            soruText.gameObject.SetActive(true);
            dogruCevapText.gameObject.SetActive(true);
            yanlisCevapText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncu labirent sorusunu ge�ti�inde UI elemanlar�n� deaktifle�tir
            soruText.gameObject.SetActive(false);
            dogruCevapText.gameObject.SetActive(false);
            yanlisCevapText.gameObject.SetActive(false);

            // Yeni bir soru �ret
            MatematikSorusuVeCevaplariUret();
        }
    }

    // Di�er kodlar...
}