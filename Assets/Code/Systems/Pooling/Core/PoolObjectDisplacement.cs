using UnityEngine;

namespace Unity.Pool
{
    [RequireComponent(typeof(IPoolManagerObjects))]
    public sealed class PoolObjectDisplacement : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _curve;
        
        private GameManager _gameManager;
        private IPoolManagerObjects _manager;

        private void Awake()
        {
            _gameManager = GameManager.Instance;
            _manager = GetComponent<IPoolManagerObjects>();
        }

        private void Update() => Translate(_gameManager.Speed);
        private void Translate(float speed) => Move(speed, Time.deltaTime);

        //public void Move(float speed)
        //{
        //    if (speed == 0) return;

        //    //Vector2 distance = speed * _direction;
        //    //_onDisplaceAmount.Invoke(distance.magnitude);
        //    //Translate(distance);
        //}
        //public void MoveUnit() => Move(1f);
        //public void SimpleMove(float speed)
        //{
        //    if (speed == 0) return;

        //    //Vector2 smoothDistance = speed * Time.deltaTime * _direction;
        //    //_onDisplaceAmount.Invoke(smoothDistance.magnitude);
        //    //Translate(smoothDistance);
        //}

        public void Move(float speed, float delta = 1f)
        {
            if (speed == 0) return;

            foreach (var item in _manager.Spawned)
            {
                float step = _curve.Evaluate(Mathf.Max(0.01f, item.CurrentTime));
                item.AddTime(step * speed * delta);
            }
        }
    }
}