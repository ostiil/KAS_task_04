using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAS_Task_04
{
    class Program
    {
        static void Main()
        {
            int healthPlayer = 60;
            int bosshealth = 80;
            int hod; bool check = false;
            Console.WriteLine("Игра 'Победи Босса'");
            Console.WriteLine("Игрок: 60 хп \n Заклинания: \n 1. Рашамон - 15 урона \n 2. Разлом - +10 хп при хп < 10, нельзя нанести урон \n" +
                " 3. Хуганза - 30 урона. Возможно использование только после использования заклинания 'Рашамон' \n 4. Щит - урон по боссу 15 хп, урон по игроку 10 хп \n 5. Торавалло - пропускаешь 2 хода, но +25хп");
            Console.WriteLine("Босс: 80 хп");

            Random random = new Random();
            hod = random.Next(1, 3);

            if (hod == 1)
            {
                do
                {
                    Console.WriteLine("Ходит игрок");
                    StepPlayer();
                    Console.WriteLine("Ходит босс.");
                    StepBoss();

                }
                while (healthPlayer > 0 || bosshealth > 0);
            }

            if (hod == 2)
            {
                do
                {
                    Console.WriteLine("Ходит босс.");
                    StepBoss();
                    Console.WriteLine("Ходит игрок");
                    StepPlayer();
                }
                while (bosshealth > 0 || healthPlayer > 0);
            }

            int StepBoss()
            {

                Random rnd = new Random();
                int step = rnd.Next(1, 3);
                if (step == 1)
                {
                    Console.WriteLine("Босс использовал заклинание Аларте. Вам нанесено 15 урона");
                    healthPlayer -= 15;
                    ShowPlayerHealth();
                    ShowBossHelth();

                }
                else
                {
                    Console.WriteLine("Босс использовал заклинание Авис. Вам нанесено 10 урона.");
                    healthPlayer -= 10;
                    ShowPlayerHealth();
                    ShowBossHelth();

                }
                if (healthPlayer < 0)
                {
                    Console.WriteLine("Вы проиграли."); End();
                }
                if (bosshealth < 0) {
                    Console.WriteLine("Вы победили Босса.");
                    End();
                } 
                return healthPlayer;
            }
            void ShowBossHelth()
            {
                Console.WriteLine("Здоровье босса: {0}", bosshealth);
            }

            void ShowPlayerHealth()
            {
                Console.WriteLine($"Здоровье игрока: {healthPlayer}");
            }
            void StepPlayer()
            {
                string[] spell = new string[] { "Рашамон", "Разлом", "Хуганза", "Щит", "Торавассо" };
            again:
                Console.Write("Введите заклинание: ");
                try
                {
                    var step = Convert.ToInt32(Console.ReadLine());

                    switch (step)
                    {
                        case 1:
                            {
                                bosshealth -= 15;
                                Console.WriteLine("Урон по боссу 15");
                                check = true;
                                ShowPlayerHealth();
                                ShowBossHelth();
                            }

                            break;
                        case 2:
                            {
                                if (healthPlayer < 10)
                                {
                                    healthPlayer += 10;
                                    Console.WriteLine("Ваше здоровье увеличилось на 10 хп");
                                    ShowPlayerHealth();
                                    ShowBossHelth();

                                }
                                else
                                {
                                    ShowPlayerHealth();
                                    Console.WriteLine($"Заклинание можно применить, если у вас меньше 10 хп");
                                    goto again;
                                }
                            }
                            break;
                        case 3:
                            {
                                if (check)
                                {
                                    bosshealth -= 30;
                                    Console.WriteLine("Урон по боссу 30.");
                                    ShowPlayerHealth();
                                    ShowBossHelth();
                                }
                                else
                                {
                                    Console.WriteLine("Это заклинание можно использовать только если вы уже использовали заклинание 'Рашамон'");
                                    goto again;
                                }
                            }
                            break;
                        case 4:
                            healthPlayer -= 10;
                            bosshealth -= 20;
                            Console.WriteLine("Вы использовлли Щит. Урон по боссу 15 хп, урон по вам 10 хп.");
                            ShowPlayerHealth();
                            ShowBossHelth();
                            break;
                        case 5:
                            Console.WriteLine("Вы использовали заклинание Торовассо. Ваше хп увеличилось на 25, но вы пропускаете 2 хода");
                            healthPlayer += 25;
                            StepBoss();
                            StepBoss();
                            ShowPlayerHealth();
                            ShowBossHelth();
                            break;
                        default:
                            Console.WriteLine("Такого заклинания нет.");
                            goto again;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Введите Заклинание числом");
                    goto again;
                }
                if (healthPlayer < 0)
                {
                    Console.WriteLine("Вы проиграли."); End();
                }
                if (bosshealth < 0)
                {
                    Console.WriteLine("Вы победили Босса.");
                    End();
                }
            }
            void End()
            {
                Console.WriteLine("Игра закончена. Если хотите продолжить, то нажмите enter. Если хотите выйти, нажмите esc");
                ConsoleKeyInfo key;
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Main();
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else { End(); }
            }
        }

    }
}


