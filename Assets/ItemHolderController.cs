using UnityEngine;

public class ItemHolderController : MonoBehaviour
{
    public int selectedWeapon = 0;
    public PickUp amount;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            selectedWeapon = 0;
            SelectWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (amount.granades > 0)
            {
                selectedWeapon = 1;
                SelectWeapon();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedWeapon = 2;
            SelectWeapon();
        }
    }
    public void SelectWeapon() {
        int i = 0;
        foreach (Transform weapon in transform) {
            if (selectedWeapon == 0) {
                weapon.gameObject.SetActive(false); 
            }
            else
            {
                if (i == selectedWeapon)
                {
                    weapon.gameObject.SetActive(true);
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }
            }
            i++;            
        } 
    }
}
