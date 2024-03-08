using TMPro;
using UnityEngine.UI;
using MenuManagement.Behaviours;
using UnityEngine;

namespace MenuManagement.Demos
{
    public class InventoryMenuItemPrefab : BaseItemPrefab<InventoryItem, InventoryMenu>
    {
        [SerializeField] private TextMeshProUGUI nameField;
        [SerializeField] private Image iconField;
        [SerializeField] private TextMeshProUGUI countField;

        public override void OnSetup(InventoryItem data)
        {
            nameField.text = data.name;
            iconField.sprite = data.icon;
            countField.text = data.count.ToString();
        }
    }
}