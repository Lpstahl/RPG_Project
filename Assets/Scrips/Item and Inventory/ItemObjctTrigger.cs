using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjctTrigger : MonoBehaviour
{
    private ItemObject myItemObject => GetComponentInParent<ItemObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            if (collision.GetComponent<CharacterStats>() != null)
                return;

            myItemObject.PickUpItem();
        }
    }
}
