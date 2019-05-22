using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IMarioState
{
    void MoveLeft();
    void MoreRight();
    void Jump();
    void Crouch();
    void Stop();
    void Move();
    void Die();
    void Update();
}

public class Mario
{
    public IMarioState state;
    public Mario()
    {

    }
}

public class RightMovingMario : IMarioState
{
    private Mario mario;
    public void RightMovingMario(Mario mario)
    {
        this.mario = mario;
    }
    public void MoveLeft()
    {
        this.mario.state = new LeftMovingMario(mario);
    }
    public void MoveRight()
    {

    }
    public void Jump()
    {
        this.mario.state = new JumpingMario(Mario);
    }
    public void Crouch()
    {
    }
    public void Stop();
    public void Move();
    public void Die();
    public void Update();
}
public class LeftMovingMario : IMarioState
{
    private Mario mario;
    public void LeftMovingMario(Mario mario)
    {
        this.mario = mario;
    }
    public void MoveRight()
    {
        this.mario.state = new RightMovingMario(mario);
    }
    public void MoveLeft();
    public void Jump();
    public void Crouch();
    public void Stop();
    public void Move();
    public void Die();
    public void Update();
}
