using System;
using MenuManagement.Base;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MenuManagement.Behaviours
{
    public abstract class BaseItemPrefab<TData, TCommonObject> : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private IDynamicMenu<TData> parentMenu;
        protected TCommonObject Common { get; private set; }
        [SerializeField, Tooltip("Can Be Null. Toggle that represents state of this menu item.")] protected Toggle toggle;
        [NonSerialized] protected TData myData;
        public bool IsSelected { get; private set; }
       
        internal void SetupSelf(IDynamicMenu<TData> menu, TCommonObject commonObject, TData data, bool isSelected)
        {
            parentMenu = menu;
            Common = commonObject;
            myData = data;
            IsSelected = isSelected;
            if (toggle)
            {
                toggle.isOn = isSelected;
                toggle.interactable = menu.Behaviour != DynamicMenuBehaviour.NotInteractable;
            }
            
            OnSetup(data);
            if (isSelected) OnSelect();
        }

        internal void SetSelectedState(bool state)
        {
            IsSelected = state;
            if (toggle) toggle.isOn = state;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (parentMenu.Behaviour == DynamicMenuBehaviour.QuickSelect)
            {
                parentMenu.SelectItem(myData);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (parentMenu.Behaviour == DynamicMenuBehaviour.QuickSelect)
            {
                parentMenu.DeselectItem();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            switch (parentMenu.Behaviour)
            {
                case DynamicMenuBehaviour.NotInteractable:
                    break;
                case DynamicMenuBehaviour.PeekIn:
                    if (IsSelected) parentMenu.DeselectItem();
                    else parentMenu.SelectItem(myData);
                    break;
                case DynamicMenuBehaviour.QuickSelect:
                    parentMenu.ConfirmItem(myData);
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }


        /// <summary> Setup the bindings (AddListener) for this item. </summary>
        /// <remarks> The data can change, prefer global callback listeners </remarks>
        public virtual void SetBindings()
        {

        }

        /// <summary> Setup this item in UI </summary>
        /// <remarks> 
        /// This method can be called multiple times on same item. Thus do not set binding (AddListener) to any of the child component of this object in this method. 
        /// Use <see cref="SetBindings"/> instead. 
        /// </remarks>
        /// <param name="data"></param>
        public virtual void OnSetup(TData data)
        {
        }

        public virtual void OnSelect()
        {
            IsSelected = true;
            if (toggle) toggle.isOn = true;
        }

        public virtual void OnDeselect()
        {
            IsSelected = false;
            if (toggle) toggle.isOn = false;
        }

        public virtual void OnConfirm()
        {
        }
    }
}