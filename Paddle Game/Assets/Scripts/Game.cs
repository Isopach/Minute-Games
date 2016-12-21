using GameCanvas;
public class Game : GameBase
{
    int player_x = 304;
    int player_y = 448;
    int player_speed = 5;
    int player_w = 32;
    int player_h = 32;
    int player_dir = 1;
    const int BALL_NUM = 30;
    int[] ball_x = new int[BALL_NUM];
    int[] ball_y = new int[BALL_NUM];
    int[] ball_col = new int[BALL_NUM];
    int[] ball_speed = new int[BALL_NUM];
    int ball_w = 24;
    int ball_h = 24;
    int time;
    int score;
    int i;
    int j = 150;

    override public void Start()
    {
        resetValue();
    }

    override public void Calc()
    {
        time = time - 1;
        for (int i = 0; i < BALL_NUM; i++)
        {
            ball_y[i] = ball_y[i] + ball_speed[i];
            if (ball_y[i] > 480)
            {
                ball_x[i] = gc.Random(0, 616);
                ball_y[i] = -gc.Random(24, 480);
                ball_speed[i] = gc.Random(3, 6);
                ball_col[i] = gc.Random(1, 3);
            }
        }
        for (int i = 0; i < BALL_NUM; i++)
        {
            if (gc.CheckHitRect(player_x, player_y, player_w, player_h, ball_x[i], ball_y[i], ball_w, ball_h))
            {
                if (time >= 0)
                {
                    if (ball_speed[i] > 0)
                    {
                        score += ball_col[i];
                        ball_speed[i] = -ball_speed[i];
                    }
                }
                else
                {
                    Invoke("resetValue", 5);
                }
            }
        }

        if (gc.isTouch)
        {
            if (gc.touchX > 320)
            {
                player_x += player_speed;
                player_dir = 1;
            }
            else
            {
                player_x -= player_speed;
                player_dir = -1;
            }
        }

    }

    override public void Draw()
    {
        gc.ClearScreen();
        
        for (int i = 0; i < BALL_NUM; i++)
        {
            gc.DrawImage(ball_col[i], ball_x[i], ball_y[i]);
        }

        if (time >= 0)
        {
            gc.DrawString(0, 0, "time:" + time);
        }
        else if (time < 0)
        {
            GameOver();
        }
        gc.DrawClippedImage(4, player_x, player_y, 0, 32 * 3, 32 * 3, 0);
        gc.DrawString(0, 30, "score:" + score);

    }
    void resetValue()
    {
        score = 0;
        time = 600;
        for (int i = 0; i < BALL_NUM; i++)
        {
            ball_x[i] = gc.Random(0, 616);
            ball_y[i] = -gc.Random(24, 480);
            ball_speed[i] = gc.Random(3, 6);
            ball_col[i] = gc.Random(1, 3);
        }
    }
    void GameOver()
    {
        gc.DrawString(0, 0, "finished!!");
        j -= 1;
        if (j <= 0)
        { j = 0; }
        gc.DrawString(90, 90, "Restart in..." + j);
    }
}
