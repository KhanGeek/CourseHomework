
public class Elf : EnemyType<ElfData>
{
    private float _speed;
    private float _earLenght;

    protected override string GetStatInfo() => $"скорость: {_speed}, длинна ушей: {_earLenght}";

    protected override void Initial(ElfData typeData)
    {
        _speed = typeData.Speed;
        _earLenght = typeData.EarLenght;
    }
}