public class FeatureController : Controller
{
    private IFeature _feature;
    private IFeatureActivator _featureActivator;

    public FeatureController(IFeatureActivator featureActivator, Character character) : base(character)
    {
        _featureActivator = featureActivator;
        _character = character;
    }

    public void SetFeature(IFeature feature) => _feature = feature;

    public override void Update(float deltaTime)
    {
        if (_featureActivator.Activate())
            _feature?.Activate(_character.transform);
    }
}
