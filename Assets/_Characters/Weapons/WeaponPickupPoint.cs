﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    [ExecuteInEditMode]
    public class WeaponPickupPoint : MonoBehaviour
    {
        [SerializeField] Weapon weaponConfig;
        [SerializeField] AudioClip pickUpSFX;


        void DestroyChildren()
        {
            foreach(Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }

        private void Update()
        {
            if (!Application.isPlaying)
            {
                DestroyChildren();
                InstantiateWeapon();
            }
        }

        void InstantiateWeapon()
        {
            var weapon = weaponConfig.GetWeaponPrefab();
            weapon.transform.position = Vector3.zero;
            Instantiate(weapon, gameObject.transform);
        }

        private void OnTriggerEnter()
        {
            FindObjectOfType<PlayerMovement>().PutWeaponInHand(weaponConfig);
            var audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(pickUpSFX);
        }
    }
}

