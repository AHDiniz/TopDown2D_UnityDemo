using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDown2D_Demo.Interactions
{
    public class InteractionRequester : MonoBehaviour
    {
        [SerializeField] private LayerMask _interactionMask;

        private IInteractable _interactable;
        private bool _canInteract = false;

        public void OnInteract()
        {
            if (_canInteract)
            {
                _interactable.Interact();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_interactionMask == (_interactionMask | (1 << other.gameObject.layer)))
            {
                _interactable = other.GetComponent<IInteractable>();
                _canInteract = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_interactionMask == (_interactionMask | (1 << other.gameObject.layer)))
                _canInteract = false;
        }
    }
}
