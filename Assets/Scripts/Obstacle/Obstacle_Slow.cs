
public class Obstacle_Slow : Obstacle
{
    protected override void Start()
    {
        minSpeed /= 2;
        base.Start();
    }
}
