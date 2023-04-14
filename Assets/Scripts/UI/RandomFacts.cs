using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomFacts : MonoBehaviour
{
    #region Inspector Variables

    [SerializeField] private TextMeshProUGUI randomFactsText;
    #endregion
    #region Public Variables
    #endregion
    #region Private Variables

    private List<String> randomFacts = new List<String>();
    #endregion
    #region Protected Variables
    #endregion
    
    #region Unity Methods
    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    #endregion

    #region Public Methods

    public void AddEWasteFact()
    {
        // Add or change e-waste facts as necessary
        randomFacts.Add("We generate around 40 million tons of electronic waste every year, worldwide. That’s like throwing 800 laptops every second.");
        randomFacts.Add("An average cellphone user replaces their unit once every 18 months.");
        randomFacts.Add("E-waste comprises 70% of our overall toxic waste.");
        randomFacts.Add("Only 12.5% of E-Waste is recycled.");
        randomFacts.Add("85% of our E-Waste are sent to landfills and incinerators are mostly burned, and release harmful toxins in the air!");
        randomFacts.Add("Electronics contain lead which can damage our central nervous system and kidneys.");
        randomFacts.Add("A child’s mental development can be affected by low level exposure to lead.");
        randomFacts.Add("The most common hazardous electronic items include LCD desktop monitors, LCD televisions, Plasma Televisions, TVs and computers with Cathode Ray Tubes.");
        randomFacts.Add("E-waste contains hundreds of substances, of which many are toxic. This includes mercury, lead, arsenic, cadmium, selenium, chromium, and flame retardants.");
        randomFacts.Add("80% of E-Waste in the US and most of other countries are transported to Asia.");
        randomFacts.Add("300 million computers and 1 billion cellphones go into production annually. It is expected to grow by 8% per year.");

        randomFactsText.text += randomFacts[UnityEngine.Random.Range(0, randomFacts.Count - 1)];
    }
    #endregion

    #region Private Methods
    #endregion

    #region Protected Methods
    #endregion
}
