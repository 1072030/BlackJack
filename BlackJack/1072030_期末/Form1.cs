using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _1072030_期末
{
    /* 撲克牌 二十一點
     * 我設定雙方最多擁有6張牌(在結束的時候才發現二十一點只要過五關就贏了，我沒發現) 
     * 
     */
    public partial class Form1 : Form
    {
        byte[] lot = new byte[12]; //隨機數取11張
        byte[] caculate = new byte[12];//因為我們撲克牌的排序是亂的 把他排至1~13
        int playersum = 0;//玩家撲克牌點數總和
        int systemsum = 0;//系統撲克牌點數總和
        int times = 0;//玩家牌數
        int times2 = 6;//電腦牌數 (因為陣列為12個) 後6個為電腦的牌
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox7.Image = imageList1.Images[0];                   // 開始時電腦兩張牌為蓋著的
            pictureBox8.Image = imageList1.Images[0];                   // 開始時電腦兩張牌為蓋著的
            Random rn = new Random();
            int i = 0;
            while (i < 12)                                              //先把12張牌發好 但玩家不知道
            {
                lot[i] = (byte)(rn.Next(1, 53));                        //隨機數
                if (!Check(lot, i))                                     //確定沒有重複
                {
                    i++;
                }
            }
            for(i = 0;i<12;i++)
            {
                caculate[i] = lot[i];
            }
            pictureBox1.Image = imageList1.Images[lot[times]];          //玩家的第一張牌
            times++;                                                    //因為牌數增加所以++
            pictureBox2.Image = imageList1.Images[lot[times]];          //玩家的第二張牌
            checkfail(lot, times);                                      //先把兩張的和加起來
            label1.Visible = true;                                      //label1 用意 幫玩家計算總和
            label1.Text += Convert.ToString(playersum);                 //玩家總和顯示
            times++;    
        }
        static bool Check(byte[] array, int count)                      //確定12張牌沒重複
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i] == array[count]) 
                    return true;
            }
            return false;
        }
        public void gamehit()                                           //在玩家點選不拿牌時 兩個按鈕失效
        {
            button1.Enabled = false;
            button2.Enabled = false;

        }
        public bool checkfail(byte[] array , int count)                 //計算玩家點數總和
        {
            if(count == 1)//前兩張的和
            {
                for (int i = 0; i <= count; i++)
                {
                    if (lot[i] > 0 && lot[i] < 14)
                    {
                        if (lot[i] >= 10)
                        {
                            lot[i] = 10;
                            playersum += lot[i];
                        }
                        else if(lot[i] == 1)
                        {
                            playersum += 11;
                        }
                        else
                        {
                            playersum += (lot[i] % 13);
                        }
                    }
                    if (lot[i] >= 14 && lot[i] < 27)
                    {
                        if ((lot[i] % 13) >= 10 || (lot[i] % 13) == 0)
                        {
                            lot[i] = 10;
                            playersum += lot[i];
                        }
                        else if((lot[i] % 13) == 1)
                        {
                            playersum += 11;
                        }
                        else
                        {
                            playersum += (lot[i] % 13);
                        }
                    }
                    if (lot[i] >= 27 && lot[i] < 40)
                    {
                        if ((lot[i] % 13) >= 10 || (lot[i] % 13) == 0)
                        {
                            lot[i] = 10;
                            playersum += lot[i];
                        }
                        else if ((lot[i] % 13) == 1)
                        {
                            playersum += 11;
                        }
                        else
                        {
                            playersum += (lot[i] % 13);
                        }
                    }
                    if (lot[i] >= 40 && lot[i] < 53)
                    {
                        if ((lot[i] % 13) >= 10 || (lot[i] % 13) == 0)
                        {
                            lot[i] = 10;
                            playersum += lot[i];
                        }
                        else if ((lot[i] % 13) == 1)
                        {
                            playersum += 11;
                        }
                        else
                        {
                            playersum += (lot[i] % 13);
                        }
                    }

                }
            }
            else//後面幾張的和
            {
                if (lot[count] > 0 && lot[count] < 14)
                {
                    if (lot[count] >= 10)
                    {
                        lot[count] = 10;
                        playersum += lot[count];
                    }
                    else if((lot[count] %13) == 1)
                    {
                        playersum += 11;
                    }
                    else
                    {
                        playersum += (lot[count] % 13);
                    }
                }
                if (lot[count] >= 14 && lot[count] < 27)
                {
                    if ((lot[count] % 13) >= 10 || (lot[count] % 13) == 0)
                    {
                        lot[count] = 10;
                        playersum += lot[count];
                    }
                    else if ((lot[count] % 13) == 1)
                    {
                        playersum += 11;
                    }
                    else
                    {
                        playersum += (lot[count] % 13);
                    }
                }
                if (lot[count] >= 27 && lot[count] < 40)
                {
                    if ((lot[count] % 13) >= 10 || (lot[count] % 13) == 0)
                    {
                        lot[count] = 10;
                        playersum += lot[count];
                    }
                    else if ((lot[count] % 13) == 1)
                    {
                        playersum += 11;
                    }
                    else
                    {
                        playersum += (lot[count] % 13);
                    }
                }
                if (lot[count] >= 40 && lot[count] < 53)
                {
                    if ((lot[count] % 13) >= 10 || (lot[count] % 13) == 0)
                    {
                        lot[count] = 10;
                        playersum += lot[count];
                    }
                    else if ((lot[count] % 13) == 1)
                    {
                        playersum += 11;
                    }
                    else
                    {
                        playersum += (lot[count] % 13);
                    }
                }
            }
            if(playersum > 21)
            {
                for(int i =0;i<count;i++)
                {
                    if((lot[i]%13) == 1)
                    {
                        playersum -= 10;
                    }
                }
            }
            if (playersum > 21)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool checksystemfail(byte[]array,int count)              //總和電腦點數
        {
            if (count == 7)
            {
                for (int i = 6; i <= count; i++)
                {
                    if (lot[i] > 0 && lot[i] < 14)
                    {
                        if (lot[i] >= 10)
                        {
                            lot[i] = 10;
                            systemsum += lot[i];
                        }
                        else if ((lot[i] % 13) == 1)
                        {
                            systemsum += 11;
                        }
                        else
                        {
                            systemsum += (lot[i] % 13);
                        }
                    }
                    if (lot[i] >= 14 && lot[i] < 27)
                    {
                        if ((lot[i] % 13) >= 10 || (lot[i] % 13) == 0)
                        {
                            lot[i] = 10;
                            systemsum += lot[i];
                        }
                        else if ((lot[i] % 13) == 1)
                        {
                            systemsum += 11;
                        }
                        else
                        {
                            systemsum += (lot[i] % 13);
                        }
                    }
                    if (lot[i] >= 27 && lot[i] < 40)
                    {
                        if ((lot[i] % 13) >= 10 || (lot[i] % 13) == 0)
                        {
                            lot[i] = 10;
                            systemsum += lot[i];
                        }
                        else if ((lot[i] % 13) == 1)
                        {
                            systemsum += 11;
                        }
                        else
                        {
                            systemsum += (lot[i] % 13);
                        }
                    }
                    if (lot[i] >= 40 && lot[i] < 53)
                    {
                        if ((lot[i] % 13) >= 10 || (lot[i] % 13) == 0)
                        {
                            lot[i] = 10;
                            systemsum += lot[i];
                        }
                        else if ((lot[i] % 13) == 1)
                        {
                            systemsum += 11;
                        }
                        else
                        {
                            systemsum += (lot[i] % 13);
                        }
                    }

                }
            }
            else
            {
                if (lot[count] > 0 && lot[count] < 14)
                {
                    if (lot[count] >= 10)
                    {
                        lot[count] = 10;
                        systemsum += lot[count];
                    }
                    else if((lot[count] %13) == 1)
                    {
                        systemsum += 11;
                    }
                    else
                    {
                        systemsum+= (lot[count] % 13);
                    }
                }
                if (lot[count] >= 14 && lot[count] < 27)
                {
                    if ((lot[count] % 13) >= 10 || (lot[count] % 13) == 0)
                    {
                        lot[count] = 10;
                        systemsum += lot[count];
                    }
                    else if ((lot[count] % 13) == 1)
                    {
                        systemsum += 11;
                    }
                    else
                    {
                        systemsum += (lot[count] % 13);
                    }
                }
                if (lot[count] >= 27 && lot[count] < 40)
                {
                    if ((lot[count] % 13) >= 10 || (lot[count] % 13) == 0)
                    {
                        lot[count] = 10;
                        systemsum += lot[count];
                    }
                    else if ((lot[count] % 13) == 1)
                    {
                        systemsum += 11;
                    }
                    else
                    {
                        systemsum += (lot[count] % 13);
                    }
                }
                if (lot[count] >= 40 && lot[count] < 53)
                {
                    if ((lot[count] % 13) >= 10 || (lot[count] % 13) == 0)
                    {
                        lot[count] = 10;
                        systemsum += lot[count];
                    }
                    else if ((lot[count] % 13) == 1)
                    {
                        systemsum += 11;
                    }
                    else
                    {
                        systemsum += (lot[count] % 13);
                    }
                }
            }
            if(systemsum > 21)
            {
                for(int j = 0;j<count;j++)
                {
                    if(lot[j] % 13 == 1)
                    {
                        systemsum -= 10;
                    }
                }
            }
            if(systemsum>16 && systemsum <=21)                          //預設 電腦撲克牌總和到16~21 之間會自己停止
            {
                return true;
            }
            else //超過21點
            {
                return false;               
            }
            
            
        }
        private void Systemcard()                                       //電腦的牌組
        {
            pictureBox7.Image = imageList1.Images[lot[times2]];
            times2++;
            pictureBox8.Image = imageList1.Images[lot[times2]];
            if (times2 == 7)                                            //前兩張總和
            { 
                if (!checksystemfail(lot, times2))                      //判斷電腦是否超過21點
                {
                    if(systemsum >21)                                   //如果超過則顯示
                    {
                        MessageBox.Show("電腦超過21點，你獲得勝利", "你贏了");
                        gamehit();
                    }
                }
                if(systemsum <16)                                       //如果電腦撲克牌總和仍小於16 則繼續抽牌
                {
                    times2++;
                }
            }
            if (times2 == 8)                                            //前三張總和
            {
                pictureBox9.Image = imageList1.Images[lot[times2]];
                if (!checksystemfail(lot, times2))
                {
                    if (systemsum > 21)
                    {
                        MessageBox.Show("電腦超過21點，你獲得勝利", "你贏了");
                        gamehit();
                    }
                }
                if (systemsum < 16)
                {
                    times2++;
                }
            }
            if(times2 == 9)                                             //前四張總和
            {
                pictureBox10.Image = imageList1.Images[lot[times2]];
                if (!checksystemfail(lot, times2))
                {
                    if (systemsum > 21)
                    {
                        MessageBox.Show("電腦超過21點，你獲得勝利", "你贏了");
                        gamehit();
                    }
                }
                if (systemsum < 16)
                {
                    times2++;
                }

            }
            if (times2 == 10)                                           //前五張總和
            {
                pictureBox11.Image = imageList1.Images[lot[times2]];
                if (!checksystemfail(lot, times2))
                {
                    if (systemsum > 21)
                    {
                        MessageBox.Show("電腦超過21點，你獲得勝利", "你贏了");
                        gamehit();
                    }
                    if(systemsum <= 21 )
                    {
                        MessageBox.Show("電腦過五關，你輸了", "你輸了");//如果電腦過五關 變成你輸
                        gamehit();
                    }
                }
                
            }
            label2.Visible = true;
            label2.Text+= Convert.ToString(systemsum);                  //顯示電腦撲克牌總和
        }
        public void wins()                                              //判斷勝利條件
        {
            if(times <=4 && times2 <10)                                 //如果你的牌小於等於4張 點腦的牌小於5張
            {
                if(playersum > systemsum && playersum <=21)             //判斷點數大小
                {
                    MessageBox.Show("你的點數比較大，你贏了!!", "你贏了");
                }
                else if(playersum == systemsum && playersum <=21)
                {
                    MessageBox.Show("你的點數與電腦點數相同，平手!");
                }
                else if(playersum < systemsum && systemsum <= 21)
                {
                    MessageBox.Show("你的點數比電腦小，你輸了", "你輸了");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)          //再抽牌的按鈕
        {
            if(times == 2)                                              //抽第3張
            {
                pictureBox3.Image = imageList1.Images[lot[times]];      //顯示第三張
                if (!checkfail(lot, times))                             //判斷是否超過21點
                {
                    MessageBox.Show("超過21點，你輸了", "你輸了"); 
                    gamehit();
                }
                times++;
            }
            else if(times == 3)                                         //顯示第四張
            {
                pictureBox4.Image = imageList1.Images[lot[times]];
                if (!checkfail(lot, times))
                {
                    
                    MessageBox.Show("超過21點，你輸了","你輸了");
                    gamehit();
                }
                times++;
            }
            else if (times == 4)                                        //顯示第五張
            {
                pictureBox5.Image = imageList1.Images[lot[times]];
                if (!checkfail(lot, times))
                {
                    MessageBox.Show("超過21點，你輸了", "你輸了");
                    gamehit();
                }
                else
                {
                    MessageBox.Show("過五關 獲勝!!");                    //過五關則獲勝
                    gamehit();
                }
                times++;
            }
            label1.Text = "當前點數: "+Convert.ToString(playersum);      //顯示點數
        }

        private void button2_Click(object sender, EventArgs e)           //停止拿牌
        {
            button1.Enabled = false;
            button2.Enabled = false;                                    //使抽牌與停止抽牌無法使用
            Systemcard();                                               //換電腦抽牌
            wins();                                                     //判斷輸贏
        }

        private void button3_Click(object sender, EventArgs e)          //重新開始
        {
            times = 0;                                                  //玩家撲克牌重抽
            times2 = 0;                                                 //電腦撲克牌重抽
            Application.Restart();
        }

        private void button4_Click(object sender, EventArgs e)          //關閉按鈕
        {
            this.Close();
        }
    }
}
