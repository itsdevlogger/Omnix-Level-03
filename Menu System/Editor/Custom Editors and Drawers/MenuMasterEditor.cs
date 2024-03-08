using MenuManagement.Base;
using MenuManagement.Perception;
using System;
using UnityEditor;
using UnityEngine;

namespace MenuManagement.Editor
{
    [CustomEditor(typeof(MenuMaster))]
    public class MenuMasterEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Disable All Child Menus"))
            {
                DisableAllMenus();
            }

            if (GUILayout.Button("Enable All Child Menus"))
            {
                EnableAllMenus();
            }
        }

        private void EnableAllMenus()
        {
            MonoBehaviour targetMono = (MonoBehaviour)target;

            foreach (var menu in targetMono.GetComponentsInChildren<BaseMenu>(true))
            {
                ActivateInHierarchy(menu.transform);
            }

            foreach (var manager in targetMono.GetComponentsInChildren<MenuScreenManager>(true))
            {
                ActivateInHierarchy(manager.transform);
            }

            foreach (var menu in targetMono.GetComponentsInChildren<PopupMenuSettings>(true))
            {
                ActivateInHierarchy(menu.transform);
            }
            EditorUtility.SetDirty(target);
        }

        private void DisableAllMenus()
        {
            MonoBehaviour targetMono = (MonoBehaviour)target;

            foreach (BaseMenu menu in targetMono.GetComponentsInChildren<BaseMenu>())
            {
                menu.gameObject.SetActive(false);
            }

            foreach (MenuScreenManager menu in targetMono.GetComponentsInChildren<MenuScreenManager>())
            {
                menu.gameObject.SetActive(false);
            }

            foreach (var menu in targetMono.GetComponentsInChildren<PopupMenuSettings>(true))
            {
                menu.gameObject.SetActive(false);
            }
            EditorUtility.SetDirty(target);
        }


        private static void ActivateInHierarchy(Transform target)
        {
            if (target == null)
            {
                Debug.LogWarning("Target transform is null.");
                return;
            }

            target.gameObject.SetActive(true);

            Transform current = target.parent;
            while (current != null)
            {
                current.gameObject.SetActive(true);
                current = current.parent;
            }
        }
    }
}