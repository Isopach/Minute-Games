using GameCanvas;
public class Game : GameBase
{
    float player_x = 320;
    float player_y = 240;
    float player_speed = 10.0f;

    const int BLOCK_NUM = 10;
    int[] block_x = new int[BLOCK_NUM];
    int[] block_y = new int[BLOCK_NUM];
    bool[] block_alive_flag = new bool[BLOCK_NUM];
    int time;
    int next_block_num;
    bool isComplete;

    override public void Start()
    {
        player_x = 320.0f;
        player_y = 240.0f;
        player_speed = 10.0f;

        time = 0;
        next_block_num = 0;
        isComplete = false;

        for (int i = 0; i < BLOCK_NUM; i++)
        {
            block_x[i] = gc.Random(0, 610);
            block_y[i] = gc.Random(0, 450);
            block_alive_flag[i] = true;
        }


    }

    override public void Calc()
    {
        player_x += gc.acceX * player_speed;
        player_y += gc.acceY * player_speed;
        if (isComplete == false)
        {
            time = time + 1;
        }
        
        if (player_x < 0)
        {
            player_x = 0;
        }
        if (player_y < 0)
        {
            player_y = 0;
        }
        if (player_x > 610)
        {
            player_x = 610;
        }
        if (player_y > 450)
        {
            player_x = 450;
        }
        for (int i = 0; i < BLOCK_NUM; i++)
        {
            if (block_alive_flag[i] && next_block_num == i)
            {
                if (gc.CheckHitRect(
                        player_x, player_y, 24, 24, 
                        block_x[i], block_y[i], 30, 30)) {
                            block_alive_flag [i] = false;
                            next_block_num++;
                        
                    if (next_block_num == BLOCK_NUM)
                    {
                        isComplete = true;
                    }
                         }
            }
        }
    }
    

    override public void Draw()
    {
        gc.ClearScreen();

        gc.DrawImage(0, 0, 0); //Blue Sky

        gc.DrawString(0, 0, "accex:" + gc.acceX);
        gc.DrawString(0, 30, "accey:" + gc.acceY);
        gc.DrawString(0, 60, "accez:" + gc.acceZ);

        gc.DrawString(0, 90, "time:" + time);
        if (isComplete)
        {
            gc.DrawString(0, 120, "Clear!");
        }

        gc.DrawImage(1, player_x, player_y);

        for (int i = 0; i < BLOCK_NUM; i++)
        {
            if (block_alive_flag [i])
            { 
            gc.SetColor(0, 0, 0, 1);
            gc.FillRect(block_x [i], block_y [i], 30, 30);
            gc.SetColor(1, 1, 1, 1);
            gc.DrawString(block_x[i], block_y[i], "" + (i + 1));
            }
        }

    }
    
}
