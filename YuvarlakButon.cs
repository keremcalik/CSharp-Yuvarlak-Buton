using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Yuvarlak_Buton
{
    class YuvarlakButon:Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            int radius = 50; // Çemberin çapı
            Point center = new Point(50, 50); // Çemberi ortalamak için konum değerleri
            Rectangle circleRect = new Rectangle(center.X - radius, center.Y - radius, radius * 2, radius * 2); // Çember için alan oluşturma
            GraphicsPath gp = new GraphicsPath(); // Grafik Dizini sınıfı türetir
            Graphics g = pevent.Graphics; // Grafik sınıfı türetir
            g.SmoothingMode = SmoothingMode.AntiAlias; // Kenar yumuşatma modu - Değer: Kenarları yumuşatır
            g.CompositingQuality = CompositingQuality.HighQuality; // Birleştirme kalitesi - Değer: Yüksek kalite
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; // Piksel dengeleme modu - Değer: Yüksek kalite
            g.InterpolationMode = InterpolationMode.HighQualityBilinear; // Ekleme yapma modu - Değer: Yüksek kalitede çift yönlü
            LinearGradientBrush brush = new LinearGradientBrush(circleRect, Color.GreenYellow, Color.Green, 90); // Çemberi boyamak için doğrusal gradyan fırça - Değerler: Boyanacak alan, Birinci geçiş rengi, İkinci geçiş rengi, geçiş açısı
            gp.AddEllipse(circleRect); // Alana çember ekler
            StringFormat format = new StringFormat(); // Yazı Biçimlendirme sınıfı türetir
            format.Alignment = StringAlignment.Center; // Yazıyı yatay eksende ortalar 
            format.LineAlignment = StringAlignment.Center; // Yazıyı dikey eksende ortalar
            g.FillPath(brush, gp); // Butonun içini boyar
            g.DrawString(this.Text, new Font("Verdana", 20, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.White, circleRect, format); // Buton üzerine yazı ekler - Değerler: Eklenecek yazı, Yazı tipi tanımlamaları, Yazı renk ayarı, Yazının ekleneceği alan, Yazı biçim ayarları
            gp.Dispose(); // Grafik Dizini sınıfını hafızadan çıkarır
            g = null; // Grafik sınıfını hafızadan çıkarır
        }
        private void Draw() 
        {
            this.BackColor = Color.Transparent;
            this.Width = 100;
            this.Height = 100;
            this.SetStyle(ControlStyles.FixedWidth, true);
            this.SetStyle(ControlStyles.FixedHeight, true);
            this.TabStop = false;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.CheckedBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.Update();
        } 
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Draw();
        }
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            Draw();
        }

    }
}
