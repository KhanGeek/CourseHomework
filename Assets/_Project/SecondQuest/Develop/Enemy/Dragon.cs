public class Dragon : EnemyType<DragonData>
{
    private int _stomachVolume;
    private float _sheepPerSecond;

    protected override string GetStatInfo() => $"объем желудка: {_stomachVolume}, поедает овец в секунду: {_sheepPerSecond}";

    protected override void Initial(DragonData typeData)
    {
        _stomachVolume = typeData.StomachVolume;
        _sheepPerSecond = typeData.SheepPerSecond;
    }
}