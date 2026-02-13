using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using Unity.Pool;

namespace Gameplay.Slot
{
    public class SlotMachine : MonoBehaviour
    {
        [Serializable] private struct Slot
        {
            public PoolManagerObjectsByDistance spawner;
            public PoolObjectDisplacement displacement;
        }
        [Serializable] public struct WeightedIcon
        {
            public Sprite icon;
            [Range(0f, 1f)] public float probability;
            public bool useVideo;
        }

        [SerializeField] private float _traveledDistance, _speedMultiply;
        [SerializeField] private float _spaceInBetween;
        [SerializeField] private float _delay;

        [SerializeField] private AnimationCurve _bounce;
        [SerializeField] private Slot[] _slots;

        [Header("Rewards")]
        [SerializeField] private Button _button;
        [SerializeField] private WeightedIcon[] _icons;
        [SerializeField] private VideoEventHandler _player;
        [SerializeField] private UnityEvent<Sprite> _onResult;

        private WaitForSeconds _slotDelayEffect;
        private WaitWhile _isPlaying;

        private int _completedSlots;
        private int _selectedResult;

        private void Awake()
        {
            _slotDelayEffect = new(_delay);
            _isPlaying = new(() => _completedSlots < _slots.Length);
            _button.onClick.AddListener(Play);
        }

        private void Play()
        {
            _selectedResult = GetWeightedIcon();
            StartCoroutine(PlaySequence());
        }
        private int GetWeightedIcon()
        {
            float roll = Random.value;
            float acc = 0;
            int index = 0;

            foreach (var item in _icons) {
                acc += item.probability;
                if (roll <= acc) return index;
                index++;
            }

            return _icons.Length - 1;
        }

        private IEnumerator PlaySequence()
        {
            _button.interactable = false;
            _completedSlots = 0;

            foreach (var slot in _slots) {
                yield return _slotDelayEffect;
                StartCoroutine(AnimationEffect(slot));
            }

            yield return _isPlaying;
            yield return _slotDelayEffect;

            if (_icons[_selectedResult].useVideo) _player.Play();
            else _onResult?.Invoke(_icons[_selectedResult].icon);
            
            _button.interactable = true;
        }
        private IEnumerator AnimationEffect(Slot slot)
        {
            float moved = 0f;
            bool symbolInjected = false;

            while (moved < _traveledDistance)
            {
                float delta = _speedMultiply * Time.deltaTime;
                moved += delta;

                float normalized = moved / _traveledDistance;
                float speed = Mathf.Lerp(1f, 0.2f, normalized);

                slot.spawner.ForceDistance(speed * _speedMultiply);
                slot.displacement.MoveDistance(speed * _speedMultiply, Time.deltaTime);

                float remainingDistance = _traveledDistance - moved;
                int itemsRemaining = Mathf.CeilToInt(remainingDistance / _spaceInBetween);

                if (!symbolInjected && itemsRemaining <= 6)
                {
                    slot.spawner.ChangeLastItem(_icons[_selectedResult].icon);
                    symbolInjected = true;
                }

                yield return null;
            }

            slot.spawner.ResetDistanceTraveled();
            slot.displacement.SnapPosition();
            _completedSlots++;
        }
    }
}