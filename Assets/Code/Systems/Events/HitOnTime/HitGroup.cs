namespace Unity.Events
{
    public class HitGroup : ElementGroup
    {
        public override bool Compare(Element element) => true;
        public override void OnSuccess() => _onSuccess.Invoke();
        public override void OnFailure() => _onFailure.Invoke();
    }
}