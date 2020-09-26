using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public enum DropDownOptions { Opt1, Opt2, Opt3, Pizza }
public class UITestScript : MonoBehaviour
{
    public Text titleText;
    public Image healtBar;
    public Toggle toggleField;
    public Dropdown myDropdown;
    float hpDrainPerSec = .1f;
    
    void Start()
    {
        titleText.text = "Zombu";
        myDropdown.ClearOptions();
        List<string> enumOptions = System.Enum.GetNames(typeof(DropDownOptions)).ToList();
        myDropdown.AddOptions(enumOptions);
    }

    // Update is called once per frame
    void Update()
    {
        

        healtBar.fillAmount = Mathf.Max(healtBar.fillAmount - hpDrainPerSec * Time.deltaTime,0);
        healtBar.color = Color.Lerp(Color.green, Color.red, 1 - healtBar.fillAmount);
    }

    public void WasToggled(bool isToggledOn)
    {
        healtBar.gameObject.SetActive(isToggledOn);
    }

    public void DropdownOptionSelected(int indexSelected)
    {
        
        Debug.Log("Selected: " + myDropdown.options[indexSelected].text);
        //System.Type myType = typeof(DropDownOptions);

        DropDownOptions enumSelected = (DropDownOptions)System.Enum.Parse(typeof(DropDownOptions), myDropdown.options[indexSelected].text);


    }
}
