using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;
    private GameObject defenderParent;
    private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
        defenderParent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");

        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Vector2 worldPos = SnapToGrid(CaculateWorldPointOfMouseClick());
        GameObject defender = Button.selectedDefender;
        int defenderCost = defender.GetComponent<Defender>().starCost;
        if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(worldPos, defender);
        }
        else
        {
            Debug.Log("Insufficient Stars!");
        }
        

    }

    private void SpawnDefender(Vector2 worldPos, GameObject defender)
    {
        Quaternion zeroRot = Quaternion.identity;
        GameObject newDef = Instantiate(defender, worldPos, zeroRot) as GameObject;
        newDef.transform.parent = defenderParent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float roundedX = Mathf.RoundToInt(rawWorldPos.x);
        float roundedY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(roundedX, roundedY);
    }

    Vector2 CaculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceToCamera = 10f;

        Vector3 weirdTripplet = new Vector3(mouseX, mouseY, distanceToCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTripplet);

        return worldPos;
    }
}
