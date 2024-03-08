using TMPro;
using UnityEngine.UI;
using MenuManagement.Behaviours;
using UnityEngine;

namespace MyMagicSpace
{
    public class TournamentItemPrefab : BaseItemPrefab<TournamentInfo, TournamentMenu>
    {
        [SerializeField] private TextMeshProUGUI nameField;
        [SerializeField] private TextMeshProUGUI descriptionField;
        [SerializeField] private TextMeshProUGUI idField;
        [SerializeField] private TextMeshProUGUI entryFeesField;
        [SerializeField] private TextMeshProUGUI startTimeField;
        [SerializeField] private TextMeshProUGUI endTimeField;
        [SerializeField] private Toggle isActiveField;
    
    
        public override void OnSetup(TournamentInfo data)
        {
                    nameField.text = data.name;
            descriptionField.text = data.description;
            idField.text = data.id.ToString();
            entryFeesField.text = data.entryFees.ToString();
            startTimeField.text = data.startTime.ToString();
            endTimeField.text = data.endTime.ToString();
            isActiveField.isOn = data.isActive;
    
        }
        
    
    }
}
