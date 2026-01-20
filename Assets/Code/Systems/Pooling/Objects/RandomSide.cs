using UnityEngine;

namespace Unity.Pool
{
    public class RandomSide : PoolObjectOnSpline
    {
        [SerializeField] private GameObject _left, _right;

        public override void Enable()
        {
            base.Enable();

            _left.SetActive(Random.value > 0.5f);
            _right.SetActive(Random.value > 0.5f);

            if (!_left.activeSelf && !_right.activeSelf)
            {
                _left.SetActive(true);
                _right.SetActive(true);
            }
        }
    }
}