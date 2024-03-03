using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TopDown2D_Demo.Movement;

namespace TopDown2D_Demo.Animations
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private List<PlayerPartAnimation> _playerParts = new List<PlayerPartAnimation>();
        private MovementController _movementController;

        private void Start()
        {
            _movementController = GetComponent<MovementController>();
        }

        private void Update()
        {
            for (int i = 0; i < _playerParts.Count; ++i)
            {
                _playerParts[i].MovementDirection = _movementController.MovementDirection;
            }
        }

        public void AddPlayerPart(GameObject partPrefab)
        {
            GameObject partInstance = Instantiate(partPrefab, transform.position, transform.rotation, transform);
            PlayerPartAnimation playerPart = partInstance.GetComponent<PlayerPartAnimation>();

            for (int i = 0; i < _playerParts.Count; ++i)
            {
                if (_playerParts[i].Type == playerPart.Type)
                {
                    GameObject objToDestroy = _playerParts[i].gameObject;
                    _playerParts.RemoveAt(i);
                    Destroy(objToDestroy);
                    break;
                }
            }
            
            _playerParts.Add(playerPart);
        }

        public void RemovePlayerPart(GameObject partPrefab)
        {
            for (int i = 0; i < _playerParts.Count; ++i)
            {
                if (_playerParts[i].gameObject == partPrefab)
                {
                    GameObject objToDestroy = _playerParts[i].gameObject;
                    _playerParts.RemoveAt(i);
                    Destroy(objToDestroy);
                    return;                        
                }
            }
        }
    }
}
