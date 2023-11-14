using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonAndDemons.UI
{
    public class MenuController : MonoBehaviour
    {
        public Vector2 HidePosition;
        public Vector2 ShowPosition;

        [SerializeField]
        private List<Menu> _menus = new List<Menu>();

        [SerializeField]
        private Button _backButton;

        private void Start()
        {
            SetStartMenusPositions();
        }

        public void EnableMenuByIndex(int index)
        {
            int currentMenuIndex = _menus.IndexOf(_menus.Find((menu) => menu.gameObject.activeInHierarchy));
            _menus[currentMenuIndex].SetPosition(HidePosition, false, () => ActivateNewMenuAndDisableOld(_menus[index], _menus[currentMenuIndex]));
            _backButton.gameObject.SetActive(_menus[index].PreviousMenu != null);
        }

        public void Back()
        {
            Menu menu = _menus.Find((menu) => menu.gameObject.activeInHierarchy);
            menu.SetPosition(HidePosition, false, () => ActivateNewMenuAndDisableOld(menu.PreviousMenu, menu));

            _backButton.gameObject.SetActive(menu.PreviousMenu.PreviousMenu != null);
        }

        private void ActivateNewMenuAndDisableOld(Menu activateMenu, Menu disableMenu)
        {
            activateMenu.gameObject.SetActive(true);
            activateMenu.SetPosition(ShowPosition, false);
            disableMenu.gameObject.SetActive(false);
        }

        private void SetStartMenusPositions()
        {
            foreach (Menu menu in _menus)
            {
                menu.gameObject.SetActive(true);
                menu.SetPosition(HidePosition, true);
                menu.gameObject.SetActive(false);
            }

            _menus[0].gameObject.SetActive(true);
            _menus[0].SetPosition(ShowPosition, true);
        }
    }
}