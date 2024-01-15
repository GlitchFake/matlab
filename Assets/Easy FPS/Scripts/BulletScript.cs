using UnityEngine;
using System.Collections;
using static UnityEditor.PlayerSettings;
using TMPro;

public class BulletScript : MonoBehaviour {

	[Tooltip("Furthest distance bullet will look for target")]
	public float maxDistance = 1000000;
	RaycastHit hit;
	[Tooltip("Prefab of wall damange hit. The object needs 'LevelPart' tag to create decal on it.")]
	public GameObject decalHitWall;
	[Tooltip("Decal will need to be sligtly infront of the wall so it doesnt cause rendeing problems so for best feel put from 0.01-0.1.")]
	public float floatInfrontOfWall;
	[Tooltip("Blood prefab particle this bullet will create upoon hitting enemy")]
	public GameObject bloodEffect;
	[Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]
	public LayerMask ignoreLayer;
    public TextMeshProUGUI puanText;
	int puan = 0;
    /*
	* Uppon bullet creation with this script attatched,
	* bullet creates a raycast which searches for corresponding tags.
	* If raycast finds somethig it will create a decal of corresponding tag.
	*/
    void Start()
    {
        // PuanText'i bul ve puanText değişkenine atama yap
        puanText = GameObject.Find("PuanText").GetComponent<TextMeshProUGUI>();
        puan = PlayerPrefs.GetInt("OyuncuPuan", 0);

        if (puanText == null)
        {
            Debug.LogError("PuanText bulunamadı!");
        }
    }
    void Update () 
	{

        if (Physics.Raycast(transform.position, transform.forward,out hit, maxDistance, ~ignoreLayer)){
			if(decalHitWall){
				if(hit.transform.tag == "dogru"){
					Instantiate(bloodEffect, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));
					Destroy(gameObject);
					Destroy(hit.transform.gameObject);
					puan += 100;
                    puanText.text = $"puan = {puan}";
                    PlayerPrefs.SetInt("OyuncuPuan", puan);
                    PlayerPrefs.Save();
                }
				if(hit.transform.tag == "yanlis"){
					Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
					Destroy(gameObject);
					Destroy(hit.transform.gameObject);
                    puan -= 50;
                    puanText.text = $"puan = {puan}";
                    PlayerPrefs.SetInt("OyuncuPuan", puan);
                    PlayerPrefs.Save();
                }
			}		
			Destroy(gameObject);
		}
		Destroy(gameObject, 0.1f);
	}

}
