using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Diagnostics;
using WpfApplication1;

namespace WpfApplication1
{
    /// <summary>
    /// Page16.xaml 的交互逻辑
    /// </summary>
    public partial class Page16 : Page
    {
         public Page16()
        {
            InitializeComponent();
            FocusManager.SetFocusedElement(this,Genius);
        }
         string[] stone = { "stone1", "stone2", "stone3", "stone4", "stone5", "stone6", "stone7", "stone8", "stone9", "stone10", "stone11", "stone12", "stone13", "stone14" };
         string[] box = { "box1", "box2", "box3", "box4", "box5", "box6", "box7", "box8" };
         string[] box_position = { "b1", "b2", "b3", "b4", "b5", "b6", "b7", "b8" };
         string[] aim = { "aim1", "aim2", "aim3", "aim4", "aim5", "aim6", "aim7", "aim8" };
        bool[] ISWIN =new bool[8];
        bool[] Z = new bool[1];
        List<positiondata> Saving = new List<positiondata>();

        public struct my_positon
        {
            public double x;
            public double y;
        }
        public class positiondata
        {
            public my_positon person;
            public List<my_positon> save_box = new List<my_positon>();
        }
         
        bool CheckWin()
        {
            int i;
            for (i = 0; i < 8; i++)
            {
                if (ISWIN[i] == false)
                    return false;
            }
            MessageBox.Show("You finished this level!");
            NavigationService.Navigate(new Uri("Page17.xaml", UriKind.Relative));
            return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page1.xaml", UriKind.Relative));                             
        }

        private void Genius_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Down) && !Keyboard.IsKeyDown(Key.Left) && !Keyboard.IsKeyDown(Key.Right))
                {
                    save();
                    BitmapImage imagetemp = new BitmapImage(new Uri(@"MySource/正向移动.png", UriKind.Relative));
                    this.Genius.Source = imagetemp;
                    if (!CheckStone(this.Genius, this.aa, 0, 50) && CheckBound(this.Genius, this.aa, 0, 50) && !CheckBox(this.Genius, this.aa, 0, 50))
                    {
                        NPCMove(this.aa,0, 50);
                    }
                }
            if (Keyboard.IsKeyDown(Key.Up) && !Keyboard.IsKeyDown(Key.Left) && !Keyboard.IsKeyDown(Key.Right))
                {
                    save();
                    BitmapImage imagetemp = new BitmapImage(new Uri(@"MySource/背向移动.png", UriKind.Relative));
                    this.Genius.Source = imagetemp;
                    if (!CheckStone(this.Genius, this.aa, 0, -50) && CheckBound(this.Genius, this.aa, 0, -50) && !CheckBox(this.Genius, this.aa, 0, -50))
                    {
                        NPCMove(this.aa,0, -50);
                    }
                }
            if (Keyboard.IsKeyDown(Key.Left) && !Keyboard.IsKeyDown(Key.Up) && !Keyboard.IsKeyDown(Key.Down))
                {
                    save();
                    BitmapImage imagetemp = new BitmapImage(new Uri(@"MySource/左向移动.png", UriKind.Relative));
                    this.Genius.Source = imagetemp;
                    if (!CheckStone(this.Genius, this.aa, -50, 0) && CheckBound(this.Genius, this.aa, -50, 0) && !CheckBox(this.Genius, this.aa, -50, 0))
                    {
                        NPCMove(this.aa, -50, 0);
                    }
                }
            if (Keyboard.IsKeyDown(Key.Right) && !Keyboard.IsKeyDown(Key.Up) && !Keyboard.IsKeyDown(Key.Down))
                {
                    save();
                    BitmapImage imagetemp = new BitmapImage(new Uri(@"MySource/右向移动.png", UriKind.Relative));
                    this.Genius.Source = imagetemp;
                    if (!CheckStone(this.Genius, this.aa, 50, 0) && CheckBound(this.Genius, this.aa, 50, 0) &&!CheckBox(this.Genius, this.aa, 50, 0))
                    {    
                        NPCMove(this.aa,50,0);                        
                    }
                }
            if (Keyboard.IsKeyDown(Key.Z))
            {
                Z[0] = true;
                back();
            }
        }

        bool CheckBox(Image target, TranslateTransform target_position, double step_x, double step_y)
        {
            int i;
            for (i = 0; i < 8; i++)
            {
                TranslateTransform d = FindName(box_position[i]) as TranslateTransform;
                Image c = FindName(box[i]) as Image;
                if (BoxCollision(target, target_position, step_x, step_y, c,d))
                {
                    if (CheckStone(c, d, step_x, step_y)) return true;
                    if (!CheckBound(c, d, step_x, step_y)) return true;
                    if (BoxCheckBox(c, d, step_x, step_y)) return true;
                    if (!BoxCheckBox(c, d, step_x, step_y)) NPCMove(d, step_x, step_y);
                }
            }
            return false;
        }
        void CheckAim()
        {
            int i, j;
            for (i = 0; i < 8; i++)
            {
                Image c = FindName(aim[i]) as Image;
                ISWIN[i] = false;
                for (j = 0; j < 8; j++)
                {
                    Image d = FindName(box[j]) as Image;
                    TranslateTransform e = FindName(box_position[j]) as TranslateTransform;
                    if (AimCollision(d, e, c)) ISWIN[i] = true;
                }
            }
        }
        bool AimCollision(Image target, TranslateTransform target_position, Image target2)
        {
            var x1 = Canvas.GetLeft(target) + target_position.X;
            var y1 = Canvas.GetTop(target) + target_position.Y;
            Rect r1 = new Rect(x1, y1, target.Width - 1, target.Height - 1);
            var x2 = Canvas.GetLeft(target2);
            var y2 = Canvas.GetTop(target2);
            Rect r2 = new Rect(x2, y2, target2.Width - 1, target2.Height - 1);
            if (r1.IntersectsWith(r2)) return true;
            else return false;
        }
        bool BoxCheckBox(Image target, TranslateTransform target_position, double step_x, double step_y)
        {
            int i;
            for (i = 0; i < 8; i++)
            {
                Image c = FindName(box[i]) as Image;
                TranslateTransform d = FindName(box_position[i]) as TranslateTransform;
                if (c != target)
                {
                    if (BoxCollision(target, target_position, step_x, step_y, c, d))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        bool CheckStone(Image target, TranslateTransform target_position, double step_x, double step_y)
        {
            int i;
            for (i = 0; i < 14; i++)
            {
                Image b = FindName(stone[i]) as Image;
                if (StoneCollision(target, target_position, step_x, step_y, b))
                {
                    return true;
                }
            }
            return false;
        }
       

         bool StoneCollision(Image target, TranslateTransform target_position, double step_x, double step_y, Image target2)
        {
            var x1 = Canvas.GetLeft(target) + target_position.X + step_x;
            var y1 = Canvas.GetTop(target) + target_position.Y + step_y;
            Rect r1 = new Rect(x1, y1, target.Width - 1, target.Height - 1);
            var x2 = Canvas.GetLeft(target2);
            var y2 = Canvas.GetTop(target2);
            Rect r2 = new Rect(x2, y2, target2.Width - 1, target2.Height - 1);
            if(r1.IntersectsWith(r2)) return true;
            else return false;
        }
         bool BoxCollision(Image target, TranslateTransform target_position, double step_x, double step_y, Image target2, TranslateTransform target2_position)
         {
             var x1 = Canvas.GetLeft(target) + target_position.X + step_x;
             var y1 = Canvas.GetTop(target) + target_position.Y + step_y;
             Rect r1 = new Rect(x1, y1, target.Width - 1, target.Height - 1);
             var x2 = Canvas.GetLeft(target2)+ target2_position.X;
             var y2 = Canvas.GetTop(target2)+ target2_position.Y;
             Rect r2 = new Rect(x2, y2, target2.Width - 1, target2.Height - 1);
             if (r1.IntersectsWith(r2)) return true;
             else return false;
         }
        
         bool CheckBound(Image target, TranslateTransform target_position, double step_x, double step_y)
         {

             var x = Canvas.GetLeft(target) + target_position.X + step_x;
             var y = Canvas.GetTop(target) + target_position.Y + step_y;
             if(x<=400&&x>=0&&y<=250&&y>=0) return true;
             else return false;
        }
      
        void NPCMove(TranslateTransform target_position,Double X,Double Y)
         {
             var x = new DoubleAnimation();
             var y = new DoubleAnimation();
             x.From = target_position.X;
             y.From = target_position.Y;
             x.To = target_position.X + X;
             y.To = target_position.Y + Y;
             target_position.X += X;
             target_position.Y += Y;
             x.Duration = new Duration(TimeSpan.FromSeconds(0.005));
             y.Duration = new Duration(TimeSpan.FromSeconds(0.005));
             target_position.BeginAnimation(TranslateTransform.XProperty, x);
             target_position.BeginAnimation(TranslateTransform.YProperty, y);
         }

        private void Genius_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.Genius.Focus();
        }

        private void Genius_KeyUp(object sender, KeyEventArgs e)
        {
            CheckAim();
            CheckWin();
            if (Z[0] == true && Saving.Count != 0)
                Saving.Remove(Saving.Last());
            Z[0] = false; 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page2.xaml", UriKind.Relative));
        }
        void save()
        {
            positiondata data = new positiondata();
            data.person.x = this.aa.X;
            data.person.y = this.aa.Y;
            int i;
            for (i = 0; i < 8; i++)
            {
                TranslateTransform d = FindName(box_position[i]) as TranslateTransform;
                my_positon boxposition = new my_positon();
                boxposition.x = d.X;
                boxposition.y = d.Y;
                data.save_box.Add(boxposition);
            }
            Saving.Add(data);
        }
        void back()
        {
            if (Saving.Count != 0)
            {
                double x, y;
                x = Saving.Last().person.x - this.aa.X;
                y = Saving.Last().person.y - this.aa.Y;
                NPCMove(this.aa, x, y);
                int i;
                for (i = 0; i < 8; i++)
                {
                    TranslateTransform d = FindName(box_position[i]) as TranslateTransform;
                    x = Saving.Last().save_box[i].x - d.X;
                    y = Saving.Last().save_box[i].y - d.Y;
                    NPCMove(d, x, y);
                }
                BitmapImage imagetemp = new BitmapImage(new Uri(@"MySource/正向站立.png", UriKind.Relative));
                this.Genius.Source = imagetemp;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            double x, y;
            x = 0 - this.aa.X;
            y = 0 - this.aa.Y;
            NPCMove(this.aa, x, y);
            int i;
            for (i = 0; i < 8; i++)
            {
                TranslateTransform d = FindName(box_position[i]) as TranslateTransform;
                x = 0 - d.X;
                y = 0 - d.Y;
                NPCMove(d, x, y);
            }
            BitmapImage imagetemp = new BitmapImage(new Uri(@"MySource/正向站立.png", UriKind.Relative));
            this.Genius.Source = imagetemp;
            Saving.Clear();
        }
    }
}
